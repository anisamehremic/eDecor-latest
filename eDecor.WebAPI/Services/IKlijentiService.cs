using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Services
{
    public interface IKlijentiService
    {
        List<Model.Klijenti> Get(KlijentiSearchRequest request);
        Model.Klijenti GetById(int id);
        Model.Klijenti Insert(KlijentiUpsertRequest request);
        Model.Klijenti Update(int id, KlijentiUpsertRequest request);
        Model.Klijenti AuthenticirajKupce(string username, string pass);
    }
}
