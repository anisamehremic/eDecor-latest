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
    public class DrzaveController : BaseCRUDController<Model.Drzave, object, DrzaveUpsertRequest, DrzaveUpsertRequest>
    {
        public DrzaveController(IBaseCRUDService<Drzave, object, DrzaveUpsertRequest, DrzaveUpsertRequest> service) : base(service)
        {
        }
    }
}
