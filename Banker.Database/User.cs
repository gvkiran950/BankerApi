using System;
using System.Collections.Generic;
using System.Text;

namespace Banker.Database
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
