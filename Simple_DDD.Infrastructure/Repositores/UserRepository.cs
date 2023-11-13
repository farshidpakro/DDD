using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_DDD.Infrastructure.Context;
using Simple_DDD.Infrastructure.Repositores.Interfaces;

namespace Simple_DDD.Infrastructure.Repositores
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext _repositoryContext) : base(_repositoryContext)
        {
        }
        // public list<> GetList_sp ()
        // {


        // }
    }
}