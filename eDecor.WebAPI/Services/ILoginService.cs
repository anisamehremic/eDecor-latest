using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Services
{
    public interface ILoginService
    {
        Model.Korisnici Authenticiraj(string username, string pass);
        Model.Korisnici AuthenticirajKlijenta(string username, string pass);
    }
}
