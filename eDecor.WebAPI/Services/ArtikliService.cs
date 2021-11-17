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
    public class ArtikliService : BaseCRUDService<Model.Artikli, ArtikliSearchRequest, Database.Artikli, ArtikliUpsertRequest, ArtikliUpsertRequest>
    {
        public ArtikliService(eDecorContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Artikli> Get(ArtikliSearchRequest search)
        {
            var query = _context.Artikli.Include(x => x.Podkategorija).Include(x => x.Kategorija).AsQueryable();

            if (search.KategorijaID != 0 && search.KategorijaID.HasValue)
            {
                query = query.Where(x => x.KategorijaId == search.KategorijaID.Value);
            }

            if (search.PodkategorijaID != 0 && search.PodkategorijaID.HasValue)
            {
                query = query.Where(x => x.PodkategorijaId == search.PodkategorijaID.Value);
            }

            if (!string.IsNullOrEmpty(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
            }

            var list = query.OrderBy(x => x.Naziv).ToList();

            return _mapper.Map<List<Model.Artikli>>(list);
        }
    }
}
