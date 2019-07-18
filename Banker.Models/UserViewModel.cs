using System;
using System.ComponentModel.DataAnnotations;

namespace Banker.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Token { get; set; }
    }
}
