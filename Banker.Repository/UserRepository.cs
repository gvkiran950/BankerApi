using Banker.Contracts;
using Banker.Models;
using System;
using System.Threading.Tasks;

namespace Banker.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> IsUserExist(UserModel userModel)
        {
            return true;
        }
    }
}
