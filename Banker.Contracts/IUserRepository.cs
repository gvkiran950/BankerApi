﻿using Banker.Database;
using Banker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banker.Contracts
{
    public interface IUserRepository
    {
        Task<bool> IsUserExist(UserViewModel userModel);
        List<User> GetUsers();
    }
}
