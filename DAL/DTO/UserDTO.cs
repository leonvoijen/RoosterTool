using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public struct UserDTO
    {
        public UserDTO(int Id, string Username, string Password, bool IsAdmin)
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
            this.IsAdmin = IsAdmin;
        }

        public int Id           { get; private set; }
        public string Username  { get; private set; }
        public string Password  { get; private set; }
        public bool IsAdmin     { get; private set; }
    }
}
