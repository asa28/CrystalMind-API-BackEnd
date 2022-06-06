using Microsoft.EntityFrameworkCore;
using WebAPITask.DAL.DataSeed;
using WebAPITask.DAL.Models;

namespace WebAPITask.DAL.Context
{
    public class CrystalMindDbContext : DbContext
    {
        public CrystalMindDbContext()
        {
        }

        public CrystalMindDbContext(DbContextOptions<CrystalMindDbContext> opt) : base(opt)
        {
        }



        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.CustomerSeed();
            modelBuilder.CustomerAddressSeed();
        }
    }
}
