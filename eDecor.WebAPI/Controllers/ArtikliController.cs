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
    public class ArtikliController : BaseCRUDController<Model.Artikli, ArtikliSearchRequest, ArtikliUpsertRequest, ArtikliUpsertRequest>
    {
        public ArtikliController(IBaseCRUDService<Artikli, ArtikliSearchRequest, ArtikliUpsertRequest, ArtikliUpsertRequest> service) : base(service)
        {
        }
    }
}
