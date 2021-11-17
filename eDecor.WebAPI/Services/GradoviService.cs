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
    public class GradoviService :IGradoviService
    {
        private readonly eDecorContext _context;
        private readonly IMapper _mapper;
        public GradoviService(eDecorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Gradovi> Get(GradoviSearchRequest search)
        {
            var query = _context.Gradovi.Include(x => x.Drzava).AsQueryable();

            if (search.DrzavaId != 0 && search.DrzavaId.HasValue)
            {
                query = query.Where(x => x.DrzavaId == search.DrzavaId);
            }

            var list = query.OrderBy(x => x.Drzava.Naziv).ToList();

            return _mapper.Map<List<Model.Gradovi>>(list);
        }

        public virtual Model.Gradovi GetById(int id)
        {
            var entity = _context.Gradovi.Find(id);
            return _mapper.Map<Model.Gradovi>(entity);
        }

        public virtual Model.Gradovi Insert(GradoviUpsertRequest request)
        {
            var entity = _mapper.Map<Gradovi>(request);
            _context.Gradovi.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Gradovi>(entity);
        }

        public Model.Gradovi Update(int id, GradoviUpsertRequest request)
        {
            var entity = _context.Gradovi.Find(id);
            _context.Gradovi.Attach(entity);
            _context.Gradovi.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Gradovi>(entity);
        }
        public Model.Gradovi Delete(int id)
        {
            var entity = _context.Gradovi.Find(id);
            _context.Gradovi.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Gradovi>(entity);
        }
    }
}
