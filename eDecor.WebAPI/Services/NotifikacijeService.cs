using AutoMapper;
using eDecor.Model.Requests;
using eDecor.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Services
{
    public class NotifikacijeService : BaseCRUDService<Model.Notifikacije, NotifikacijeSearchRequest, Database.Notifikacije, NotifikacijeUpsertRequest, NotifikacijeUpsertRequest>
    {
        public NotifikacijeService(eDecorContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Notifikacije> Get(NotifikacijeSearchRequest search)
        {
            var query = _context.Notifikacije.Include(x => x.Korisnik).Include(x=>x.Klijent).AsQueryable();

            if (!string.IsNullOrEmpty(search?.Korisnik))
            {
                query = query.Where(x => x.Korisnik.KorisnickoIme.StartsWith(search.Korisnik));
            }

            if (!string.IsNullOrEmpty(search?.Klijent))
            {
                query = query.Where(x => x.Klijent.KorisnickoIme.StartsWith(search.Klijent));
            }
            
            if (!string.IsNullOrEmpty(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
            }

            var list = query.OrderByDescending(x => x.DatumSlanja).ToList();

            return _mapper.Map<List<Model.Notifikacije>>(list);
        }
    }
}
