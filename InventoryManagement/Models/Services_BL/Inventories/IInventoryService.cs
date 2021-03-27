using InventoryManagement.Models.Entities;
using InventoryManagement.Models.Entities._DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Services_BL.Inventories
{
    public interface IInventoryService
    {
        List<InventoryData> GetInventories();
        InventoryData GetInventoryById(int Id);
        InventoryData AddInventory(InventorySubmissionModel model);
        bool DeleteInventory(int inventoryId);
        bool UpdateInventory(InventoryUpdateSubmissionModel inventoryData);
    }
}
