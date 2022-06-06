using System;
using Microsoft.EntityFrameworkCore;
using WebAPITask.DAL.Models;

namespace WebAPITask.DAL.DataSeed
{

    public static class CustomerAddressSeedData
    {
        public static void CustomerAddressSeed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CustomerAddress>().HasData(

                new CustomerAddress()
                {
                    Id = new Guid("f138a31e-3c81-481e-92de-d873d020b000"),
                    CustomerId = new Guid("f138a31e-3c81-481e-92de-d873d020b4d4"),
                    Address = "Cairo - Egypt",
                    AddressRank = 2
                },

                new CustomerAddress()
                {
                    Id = new Guid("f138a31e-3c81-481e-92de-d873d020b111"),
                    CustomerId = new Guid("f138a31e-3c81-481e-92de-d873d020b4d4"),
                    Address = "Alex - Egypt",
                    AddressRank = 1
                },

                new CustomerAddress()
                {
                    Id = new Guid("f138a31e-3c81-481e-92de-d873d020b222"),
                    CustomerId = new Guid("f138a31e-3c81-481e-92de-d873d020b4d5"),
                    Address = "Liverpool - England",
                    AddressRank = 1
                }

             );
        }
    }
}
