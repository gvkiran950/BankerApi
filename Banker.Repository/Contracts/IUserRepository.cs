using Banker.Database;
using Banker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banker.Repository.Contracts
{
    public interface IUserRepository
    {
        User GetUser(UserViewModel userModel);
        List<User> GetAllUsers();
    }
}
