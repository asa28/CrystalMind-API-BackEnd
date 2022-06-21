using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAPITask.DAL.Context;
using WebAPITask.DAL.Models;

namespace WebAPITask.DAL.Repositories
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        protected readonly CrystalMindDbContext _context;

        public CustomerAddressRepository(CrystalMindDbContext context)
        {
            _context = context;
        }



        public IEnumerable<CustomerAddress> getAllbyCustomFilter(
            Expression<Func<CustomerAddress, bool>> filter = null,Func<IQueryable<CustomerAddress>, IOrderedQueryable<CustomerAddress>> orderBy = null)
        {
            IQueryable<CustomerAddress> query = _context.Set<CustomerAddress>();

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

        public List<CustomerAddress> getAllAddressesbyCustomerId(Guid customerId)
        {
            return _context.CustomerAddresses.Where(x => x.CustomerId == customerId).ToList();
        }
        public void Add(CustomerAddress entity)
        {
            _context.Set<CustomerAddress>().Add(entity);
        }
        public List<CustomerAddress> GetAll()
        {
            return _context.Set<CustomerAddress>().ToList();
        }
        public CustomerAddress FindById(Guid Id)
        {
            return _context.Set<CustomerAddress>().Find(Id);
        }
        public CustomerAddress Update(CustomerAddress entity)
        {
            _context.Set<CustomerAddress>().Update(entity);
            return entity;
        }
        public void DeleteById(Guid Id)
        {
            var entity = FindById(Id);
            _context.Set<CustomerAddress>().Remove(entity);
        }
    }


    public interface ICustomerAddressRepository
    {
        IEnumerable<CustomerAddress> getAllbyCustomFilter(
            Expression<Func<CustomerAddress, bool>> filter = null, Func<IQueryable<CustomerAddress>, IOrderedQueryable<CustomerAddress>> orderBy = null);
        List<CustomerAddress> getAllAddressesbyCustomerId(Guid customerId);
        void Add(CustomerAddress entity);
        List<CustomerAddress> GetAll();
        CustomerAddress FindById(Guid Id);
        CustomerAddress Update(CustomerAddress entity);
        void DeleteById(Guid Id);
    }
}
