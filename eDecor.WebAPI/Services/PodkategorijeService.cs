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
    public class PodkategorijeService : BaseCRUDService<Model.Podkategorije, PodkategorijeSearchRequest, Database.Podkategorije, PodkategorijeUpsertRequest, PodkategorijeUpsertRequest>
    {
        public PodkategorijeService(eDecorContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Podkategorije> Get(PodkategorijeSearchRequest search)
        {
            var query = _context.Podkategorije.Include(x => x.Kategorija).AsQueryable();

            if (search.KategorijaID != 0 && search.KategorijaID.HasValue)
            {
                query = query.Where(x => x.KategorijaId == search.KategorijaID.Value);
            }

            if (!string.IsNullOrEmpty(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
            }

            var list = query.OrderBy(x => x.Naziv).ToList();

            return _mapper.Map<List<Model.Podkategorije>>(list);
        }
    }
}
