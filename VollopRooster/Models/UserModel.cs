using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VollopRooster.Models
{
    public class UserModel
    {
        public UserModel(string Username, string Password, bool IsAdmin, int Id)
        {
            Username = this.Username;
            Password = this.Password;
            IsAdmin = this.IsAdmin;
            Id = this.Id;
        }

        private string Username { get; set; }
        private string Password { get; set; }
        private bool IsAdmin { get; set; }
        private int Id { get; set; }
    }
}
