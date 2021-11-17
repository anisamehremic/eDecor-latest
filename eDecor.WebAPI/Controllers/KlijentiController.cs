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
    [Route("api/[controller]")]
    [ApiController]
    public class KlijentiController : ControllerBase
    {
        private readonly IKlijentiService _service;
        public KlijentiController(IKlijentiService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Klijenti> Get([FromQuery] KlijentiSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize]
        [HttpGet("{id}")]
        public Model.Klijenti GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost]
        public Model.Klijenti Insert(KlijentiUpsertRequest request)
        {
            return _service.Insert(request);
        }
        [Authorize]
        [HttpPut("{id}")]
        public Model.Klijenti Update(int id, [FromBody] KlijentiUpsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
