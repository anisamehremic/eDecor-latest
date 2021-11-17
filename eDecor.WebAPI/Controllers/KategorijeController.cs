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
    public class KategorijeController : BaseCRUDController<Model.Kategorije, object, KategorijeUpsertRequest, KategorijeUpsertRequest>
    {
        public KategorijeController(IBaseCRUDService<Kategorije, object, KategorijeUpsertRequest, KategorijeUpsertRequest> service) : base(service)
        {
        }
    }
}
