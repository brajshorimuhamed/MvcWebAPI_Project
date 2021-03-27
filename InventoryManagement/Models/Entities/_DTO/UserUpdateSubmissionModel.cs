using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Entities._DTO
{
    public class UserUpdateSubmissionModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string NrPhone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public UserData ToEntity()
        {
            return new UserData
            {
                Id = Id,
                FullName = FullName,
                NrPhone = NrPhone,
                Email = Email,
                Password = Password,
                Address = Address
            };
        }
    }
}
