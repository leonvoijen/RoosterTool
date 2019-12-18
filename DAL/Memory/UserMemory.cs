using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DAL.DTO;

namespace DAL.Memory
{
    public class UserMemory
    {
        private List<UserDTO> Users = new List<UserDTO>();
        public List<UserDTO> GetAllUser()
        {
            List<UserDTO> temp = new List<UserDTO>();
            UserDTO user1 = new UserDTO(1,"leon","123",true);
            UserDTO user2 = new UserDTO(2,"Piet","124",false);
            UserDTO user3 = new UserDTO(3,"Test","125",false);
            UserDTO user4 = new UserDTO(4,"raar","126",false);

            Users[0] = user1;
            Users[1] = user2;
            Users[2] = user3;
            Users[3] = user4;

            temp = this.Users;
            return Users;
        }

        public int GetId(int index)
        {
            return Users[index].Id;
        }
        public string GetName(int index)
        {
            return Users[index].Username;
        }
        public string GetPassword(int index)
        {
            return Users[index].Password;
        }
        public bool GetIsAdmin(int index)
        {
            return Users[index].IsAdmin;
        }
    }
}
