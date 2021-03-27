using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Entities._DTO
{
    public class InventoryUpdateSubmissionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public InventoryData ToEntity()
        {
            return new InventoryData
            {
                Id = Id,
                Name = Name,
                Status = Status
            };
        }
    }
}
