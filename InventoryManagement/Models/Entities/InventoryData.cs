using InventoryManagement.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Entities
{
    public class InventoryData : BaseEntity
    {
        public string Name { get; set; }

        public string Status { get; set; }
    }
}
