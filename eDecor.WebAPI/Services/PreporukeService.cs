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
    public class PreporukeService : IPreporukeService
    {
        private readonly eDecorContext _context;
        private readonly IMapper _mapper;
        public PreporukeService(eDecorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Artikli> Get(PreporukeSearchRequest request)
        {
            var list = _context.Artikli.Where(x=> x.Status).ToList();
            List<Database.Artikli> artikliList = new List<Database.Artikli>();

            var preporuceniArtikliList = new List<Database.Artikli>();
            var predhodneRezervacijeList = _context.Rezervacije.Include("RezervacijeArtikli.Artikal").Where(x => x.Klijent.KorisnickoIme == request.KorisnickoIme).ToList();//&& x.Status -ako zelimo samo rezervacije koje su aktivne
            foreach (var item in artikliList)
            {
                foreach (var rezervacije in predhodneRezervacijeList) {
                    if (rezervacije.RezervacijeArtikli.Where(x=>x.ArtikalId == item.ArtikalId).Count()!= 0 && preporuceniArtikliList.Count != 2)//ako ga je prethodno rezervisao && preporucena ne prelaze broj povratnih vozila
                    {
                        preporuceniArtikliList.Add(item);
                    }
                }
            }
            if (preporuceniArtikliList.Count < 2 && list.Count != 0)//ako nema preporucenih vozila vratiti neko nasumicno odabrano
            {
                var prep = list.OrderBy(x => Guid.NewGuid()).ToList();
                foreach (var item in prep)
                    if(preporuceniArtikliList.Count < 2)
                       preporuceniArtikliList.Add(item);
            }

            return _mapper.Map<List<Model.Artikli>>(preporuceniArtikliList);
        }
    }
}
