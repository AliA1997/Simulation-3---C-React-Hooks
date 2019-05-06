using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Halo.Domain;
using System.Text;

namespace Halo.Data.Repos
{
    public interface IUserRepo
    {
        Task<User> Login(string user, string password);

        Task<User> Register(User newUser);
    }
}
