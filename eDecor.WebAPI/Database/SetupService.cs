using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Database
{
    public class SetupService
    {
        public static void Init(eDecorContext context)
        {
            context.Database.Migrate();
        }
    }
}
