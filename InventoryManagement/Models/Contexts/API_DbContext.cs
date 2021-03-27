using InventoryManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Contexts
{
    public class API_DbContext : DbContext, IAPI_DbContext
    {
        public API_DbContext(DbContextOptions<API_DbContext> options) : base(options)
        {

        }

        public DbSet<UserData> Users { get; set; }

        public DbSet<InventoryData> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().HasData(
                new UserData
                {
                    Id = 1,
                    FullName = "Muhamed Brajshori",
                    NrPhone = "+38344345678",
                    Email = "brajshorimuhamedApi@live.de",
                    Password = "APIGateway",
                    Address = "Kodra e Trimave Vranjevc"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
