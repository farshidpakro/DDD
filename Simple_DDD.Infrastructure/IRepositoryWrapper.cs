using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_DDD.Infrastructure.Repositores.Interfaces;

namespace Simple_DDD.Infrastructure
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}
