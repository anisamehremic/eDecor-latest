using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDecor.Model;
using eDecor.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDecor.WebAPI.Controllers
{
    public class UlogeController : BaseController<Model.Uloge, object>
    {
        public UlogeController(IBaseService<Uloge, object> service) : base(service)
        {
        }
    }
}
