using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_DDD.Domain.DTOs;

namespace Simple_DDD.API.Services.Interfaces
{
    public interface ICurrentUserServices
    {
         string GetUserId();

         string GetUserEmail();
        
         string GetUserRole();
         

    }
}