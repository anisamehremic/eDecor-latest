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
    public class OcjeneService : BaseCRUDService<Model.Ocjene, OcjeneSearchRequest, Database.Ocjene, OcjeneUpsertRequest, OcjeneUpsertRequest>
    {
        public OcjeneService(eDecorContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Ocjene> Get(OcjeneSearchRequest search)
        {
            var query = _context.Ocjene.Include(x => x.Artikal).Include(x => x.Klijent).AsQueryable();

            if (search.Ocjena != 0 && search.Ocjena.HasValue)
            {
                query = query.Where(x => x.Ocjena == search.Ocjena.Value);
            }
            if (search.ArtikalId.HasValue && search.ArtikalId != 0)
            {
                query = query.Where(x => x.ArtikalId == search.ArtikalId.Value);
            }
            if (search.KlijentId.HasValue && search.KlijentId != 0)
            {
                query = query.Where(x => x.KlijentId == search.KlijentId.Value);
            }
            if (!string.IsNullOrEmpty(search?.Artikal))
            {
                 query = query.Where(x => x.Artikal.Naziv.StartsWith(search.Artikal));
            }

            var list = query.OrderByDescending(x => x.Artikal.Naziv).ToList();

            return _mapper.Map<List<Model.Ocjene>>(list);
        }
    }
}
