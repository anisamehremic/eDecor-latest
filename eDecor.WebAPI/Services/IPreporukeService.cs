using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Services
{
    public interface IPreporukeService
    {
        List<Model.Artikli> Get(PreporukeSearchRequest request);
    }
}
