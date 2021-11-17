using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDecor.Model.Requests;
using eDecor.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDecor.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PreporukeController : ControllerBase
    {
        private readonly IPreporukeService _service;
        public PreporukeController(IPreporukeService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Artikli> Get([FromQuery]PreporukeSearchRequest request)
        {
            return _service.Get(request);
        }
    }
}