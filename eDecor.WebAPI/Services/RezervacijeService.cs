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
    public class RezervacijeService : BaseCRUDService<Model.Rezervacije, RezervacijeSearchRequest, Database.Rezervacije, RezervacijeUpsertRequest, RezervacijeUpsertRequest>
    {
        public RezervacijeService(eDecorContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Model.Rezervacije GetById(int id)
        {
            var entity = _context.Rezervacije.Include(x => x.Grad).Include(x => x.Klijent).Include("RezervacijeArtikli.Artikal").Include(x => x.Korisnik).Include(x => x.Popust).Where(x=> x.RezervacijaId == id).FirstOrDefault();
            return _mapper.Map<Model.Rezervacije>(entity);
        }

        public override List<Model.Rezervacije> Get(RezervacijeSearchRequest search)
        {
            var query = _context.Rezervacije.Include(x => x.Grad).Include(x => x.Klijent).Include("RezervacijeArtikli.Artikal").Include(x => x.Korisnik).Include(x => x.Popust).AsQueryable();

            if (!string.IsNullOrEmpty(search?.Klijent))
            {
                query = query.Where(x => x.Klijent.KorisnickoIme.StartsWith(search.Klijent));
            }

            if (!string.IsNullOrEmpty(search?.Grad))
            {
                query = query.Where(x => x.Grad.Naziv.StartsWith(search.Grad));
            }

            var list = query.OrderByDescending(x => x.DatumKreiranja).ToList();

            return _mapper.Map<List<Model.Rezervacije>>(list);
        }
        public override Model.Rezervacije Insert(RezervacijeUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Rezervacije>(request);
            _context.Rezervacije.Add(entity);
            _context.SaveChanges();

            foreach (var item in request.Artikli)
            {
                _context.RezervacijeArtikli.Add(new RezervacijeArtikli() { Status = true, RezervacijaId = entity.RezervacijaId, ArtikalId = item.ArtikalId, Kolicina = item.Kolicina });
            }
            _context.SaveChanges();

            return _mapper.Map<Model.Rezervacije>(entity);
        }
        public override Model.Rezervacije Update(int id, RezervacijeUpsertRequest request)
        {
            var entity = _context.Rezervacije.Find(id);
            _context.Rezervacije.Attach(entity);
            _context.Rezervacije.Update(entity);
            //-----------------------------------brisi
            var listRezervacijeArtikli = _context.RezervacijeArtikli.Where(x => x.RezervacijaId == id).ToList();

            foreach (var item in listRezervacijeArtikli)
            {
                _context.RezervacijeArtikli.Remove(item);
            }
            _context.SaveChanges();
            //---
            foreach (var item in request.Artikli)
            {
                _context.RezervacijeArtikli.Add(new RezervacijeArtikli() { Status = true, RezervacijaId = entity.RezervacijaId, ArtikalId = item.ArtikalId, Kolicina = item.Kolicina });
            }
            _context.SaveChanges();
            //---------------------------
            _mapper.Map(request, entity);//source, destinaton
            _context.SaveChanges();
            return _mapper.Map<Model.Rezervacije>(entity);
        }
    }
}
