using InventoryManagement.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Entities
{
    public class UserData : BaseEntity
    {
        public string FullName { get; set; }

        public string NrPhone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }
    }
}
