using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            _context.Customers.Add(entity);
        }
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
        public Customer FindById(Guid Id)
        {
            return _context.Customers.Find(Id);
        }    
        public Customer Update(Customer entity)
        {
            _context.Customers.Update(entity);
            return entity;
        }
        public void DeleteById(Guid Id)
        {
            var entity = FindById(Id);
            _context.Customers.Remove(entity);
        }
        public IEnumerable<Customer> getAllbyCustomFilter(
            Expression<Func<Customer, bool>> filter = null, 
            Func<IQueryable<Customer>, 
            IOrderedQueryable<Customer>> orderBy = null)
        {
            IQueryable<Customer> query = _context.Set<Customer>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }


    public interface ICustomerRepository
    {
        IEnumerable<Customer> getAllbyCustomFilter(
                Expression<Func<Customer, bool>> filter = null, 
                Func<IQueryable<Customer>, 
                IOrderedQueryable<Customer>> orderBy = null);
        void Add(Customer entity);
        List<Customer> GetAll();
        Customer FindById(Guid Id);      
        Customer Update(Customer entity);
        void DeleteById(Guid Id);
    }
}
