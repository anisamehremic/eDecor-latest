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
    public class PopustiController : BaseCRUDController<Model.Popusti, object, PopustiUpsertRequest, PopustiUpsertRequest>
    {
        public PopustiController(IBaseCRUDService<Popusti, object, PopustiUpsertRequest, PopustiUpsertRequest> service) : base(service)
        {
        }
    }
}
