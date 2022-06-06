using Microsoft.EntityFrameworkCore;
using System;
using WebAPITask.DAL.Models;

namespace WebAPITask.DAL.DataSeed
{
    public static class CustomerSeedData
    {
        public static void CustomerSeed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData(

                new Customer() 
                {
                    Id = new Guid("f138a31e-3c81-481e-92de-d873d020b4d4"),
                    FirstName = "Ahmed",
                    LastName = "Sabry",
                    Email = "ahmadsabry28@gmail.com",
                    Gender = 'M',
                    DateOfBirth = new DateTime(1993-01-28)
                },

                new Customer()
                {
                    Id = new Guid("f138a31e-3c81-481e-92de-d873d020b4d5"),
                    FirstName = "Mohamed",
                    LastName = "Salah",
                    Email = "mohamedsalah@gmail.com",
                    Gender = 'M',
                    DateOfBirth = new DateTime(1992-06-15)
                }

             );
        }
    }
}
