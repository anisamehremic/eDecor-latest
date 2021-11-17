using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Services
{
    public interface IGradoviService
    {
        List<Model.Gradovi> Get(GradoviSearchRequest request);
        Model.Gradovi GetById(int id);
        Model.Gradovi Insert(GradoviUpsertRequest request);
        Model.Gradovi Update(int id, GradoviUpsertRequest request);
    }
}
