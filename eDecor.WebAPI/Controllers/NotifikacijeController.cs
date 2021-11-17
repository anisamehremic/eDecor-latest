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
    public class NotifikacijeController : BaseCRUDController<Model.Notifikacije, NotifikacijeSearchRequest, NotifikacijeUpsertRequest, NotifikacijeUpsertRequest>
    {
        public NotifikacijeController(IBaseCRUDService<Notifikacije, NotifikacijeSearchRequest, NotifikacijeUpsertRequest, NotifikacijeUpsertRequest> service) : base(service)
        {
        }
    }
}
