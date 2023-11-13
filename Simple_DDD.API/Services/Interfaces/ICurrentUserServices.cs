using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_DDD.API.Services.Interfaces
{
    public interface ICurrentUserServices
    {
         string GetUserId();

         string GetUserEmail();
        
         string GetUserRole();

    }
}