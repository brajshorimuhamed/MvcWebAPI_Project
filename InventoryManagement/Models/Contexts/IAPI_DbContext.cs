using InventoryManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Contexts
{
    public interface IAPI_DbContext
    {
        DbSet<UserData> Users { get; set; }

        DbSet<InventoryData> Inventories { get; set; }

        int SaveChanges();
    }
}
