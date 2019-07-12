using System;
using System.ComponentModel.DataAnnotations;

namespace Banker.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8,ErrorMessage ="Password required minimum 8 characters")]
        public string Password { get; set; }
    }
}
