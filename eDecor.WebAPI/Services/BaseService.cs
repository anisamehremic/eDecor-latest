using AutoMapper;
using eDecor.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Services
{
    public class BaseService<T, TSearch, TDatabase> : IBaseService<T, TSearch> where TDatabase : class
    {
        protected readonly eDecorContext _context;
        protected readonly IMapper _mapper;
        public BaseService(eDecorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual List<T> Get(TSearch search)
        {
            var list = _context.Set<TDatabase>().ToList();
            return _mapper.Map<List<T>>(list);
        }

        public virtual T GetById(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            return _mapper.Map<T>(entity);
        }
    }
}
