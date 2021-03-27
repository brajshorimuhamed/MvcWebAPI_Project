using InventoryManagement.Models.Contexts;
using InventoryManagement.Models.Entities;
using InventoryManagement.Models.Entities._DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Services_BL.Inventories
{
    public class InventoryService : IInventoryService
    {
        private readonly IAPI_DbContext _context;

        public InventoryService(IAPI_DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public InventoryData AddInventory(InventorySubmissionModel model)
        {
            var entity = model.ToEntity();
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            _context.Inventories.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool DeleteInventory(int inventoryId)
        {
            var entity = _context.Inventories.FirstOrDefault(x => x.Id == inventoryId);
            if (entity != null)
            {
                _context.Inventories.Remove(entity);

                return _context.SaveChanges() > 0;
            }

            return false;
        }

        public List<InventoryData> GetInventories()
        {
            return _context.Inventories.ToList();
        }

        public InventoryData GetInventoryById(int Id)
        {
            var entity = _context.Inventories.Where(x => x.Id == Id).FirstOrDefault();

            return entity;
        }

        public bool UpdateInventory(InventoryUpdateSubmissionModel inventoryData)
        {
            var entity = _context.Inventories.FirstOrDefault(x => x.Id == inventoryData.Id);
            if (entity != null)
            {
                entity.Id = inventoryData.Id;
                entity.Name = inventoryData.Name;
                entity.Status = inventoryData.Status;

                return _context.SaveChanges() > 0;
            }

            return false;
        }
    }
}
