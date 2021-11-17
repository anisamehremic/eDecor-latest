using AutoMapper;
using eDecor.Model;
using eDecor.Model.Requests;
using eDecor.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Services
{
    public class PretplateService : BaseCRUDService<Model.Pretplate, PretplateSearchRequest, Database.Pretplate, PretplateUpsertRequest, PretplateUpsertRequest>
    {
        public PretplateService(eDecorContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Pretplate> Get(PretplateSearchRequest search)
        {
            var query = _context.Pretplate.Include(x => x.Klijent).Include(x=>x.Kategorija).AsQueryable();

            if (search.KategorijaID != 0 && search.KategorijaID.HasValue)
            {
                query = query.Where(x => x.KategorijaId == search.KategorijaID.Value);
            }

            if (!string.IsNullOrEmpty(search?.KorisnickoIme)) {
                query = query.Where(x => x.Klijent.KorisnickoIme.StartsWith(search.KorisnickoIme));
            }

            var list = query.OrderBy(x => x.Klijent.KorisnickoIme).ToList();

            return _mapper.Map<List<Model.Pretplate>>(list);
        }
    }
}
