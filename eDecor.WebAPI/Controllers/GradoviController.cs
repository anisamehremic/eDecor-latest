using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDecor.Model;
using eDecor.Model.Requests;
using eDecor.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eDecor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoviController : ControllerBase
    {
        private readonly IGradoviService _service;
        public GradoviController(IGradoviService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Gradovi> Get([FromQuery] GradoviSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize]
        [HttpGet("{id}")]
        public Model.Gradovi GetById(int id)
        {
            return _service.GetById(id);
        }
        [Authorize]
        [HttpPost]
        public Model.Gradovi Insert(GradoviUpsertRequest request)
        {
            return _service.Insert(request);
        }
        [Authorize]
        [HttpPut("{id}")]
        public Model.Gradovi Update(int id, [FromBody] GradoviUpsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
