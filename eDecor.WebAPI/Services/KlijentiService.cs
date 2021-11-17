using AutoMapper;
using eDecor.Model.Requests;
using eDecor.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Services
{
    public class KlijentiService : IKlijentiService
    {
        private readonly eDecorContext _context;
        private readonly IMapper _mapper;
        public KlijentiService(eDecorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //-----------------------------------------------------------------------------------
        public Model.Klijenti AuthenticirajKupce(string username, string pass)
        {
            var user = _context.Klijenti.Where(x => x.KorisnickoIme == username).FirstOrDefault();

            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Klijenti>(user);
                }
            }
            return null;
        }
        //-----------------------------------------------------------------------------------
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        //-----------------------------------------------------------------------------------
        public List<Model.Klijenti> Get(KlijentiSearchRequest request)
        {
            var query = _context.Klijenti.Include(x=>x.Grad).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }

            if (!string.IsNullOrWhiteSpace(request?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.Equals(request.KorisnickoIme));
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Klijenti>>(list);
        }

        public Model.Klijenti GetById(int id)
        {
            var entity = _context.Klijenti.Find(id);
            return _mapper.Map<Model.Klijenti>(entity);
        }

        public Model.Klijenti Insert(KlijentiUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Klijenti>(request);

            if (request.Lozinka != request.PotvrdaLozinke)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            _context.Klijenti.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Klijenti>(entity);
        }
        public Model.Klijenti Update(int id, KlijentiUpsertRequest request)
        {
            var entity = _context.Klijenti.Find(id);
            _context.Klijenti.Attach(entity);
            _context.Klijenti.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Lozinka))
            {
                if (request.Lozinka != request.PotvrdaLozinke)
                {
                    throw new Exception("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }
            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Klijenti>(entity);
        }
    }
}
