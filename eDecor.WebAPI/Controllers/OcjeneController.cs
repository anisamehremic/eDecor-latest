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
    public class OcjeneController : BaseCRUDController<Model.Ocjene, OcjeneSearchRequest, OcjeneUpsertRequest, OcjeneUpsertRequest>
    {
        public OcjeneController(IBaseCRUDService<Ocjene, OcjeneSearchRequest, OcjeneUpsertRequest, OcjeneUpsertRequest> service) : base(service)
        {
        }
    }
}
