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
    public class PodkategorijeController : BaseCRUDController<Model.Podkategorije, PodkategorijeSearchRequest, PodkategorijeUpsertRequest, PodkategorijeUpsertRequest>
    {
        public PodkategorijeController(IBaseCRUDService<Podkategorije, PodkategorijeSearchRequest, PodkategorijeUpsertRequest, PodkategorijeUpsertRequest> service) : base(service)
        {
        }
    }
}
