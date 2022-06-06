using System;
using System.Collections.Generic;
using System.Linq;
using WebAPITask.DAL.Context;
using WebAPITask.DAL.Models;

namespace WebAPITask.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly CrystalMindDbContext _context;

        public CustomerRepository(CrystalMindDbContext context)
        {
            _context = context;
        }


        public void Add(Customer entity)
        {
            _context.Set<Customer>().Add(entity);
        }

        public List<Customer> GetAll()
        {
            return _context.Set<Customer>().ToList();
        }

        public Customer FindById(Guid Id)
        {
            return _context.Set<Customer>().Find(Id);
        }
        

        public Customer Update(Customer entity)
        {
            // to be modified -> (_context.find)
            _context.Set<Customer>().Update(entity);
            return entity;
        }


        public void DeleteById(Guid Id)
        {
            var entity = FindById(Id);
            _context.Set<Customer>().Remove(entity);
        }

    }


    public interface ICustomerRepository
    {
        void Add(Customer entity);
        List<Customer> GetAll();
        Customer FindById(Guid Id);      
        Customer Update(Customer entity);
        void DeleteById(Guid Id);
    }
}
