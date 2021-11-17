using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDecor.Model;
using eDecor.Model.Requests;
using eDecor.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDecor.WebAPI.Controllers
{
    public class PretplateController : BaseCRUDController<Model.Pretplate, PretplateSearchRequest, PretplateUpsertRequest, PretplateUpsertRequest>
    {
        public PretplateController(IBaseCRUDService<Pretplate, PretplateSearchRequest, PretplateUpsertRequest, PretplateUpsertRequest> service) : base(service)
        {
        }
    }

}
