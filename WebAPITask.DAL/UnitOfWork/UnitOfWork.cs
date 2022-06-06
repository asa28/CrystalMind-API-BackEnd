using System;
using WebAPITask.DAL.Context;
using WebAPITask.DAL.Repositories;

namespace WebAPITask.DAL.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CrystalMindDbContext _context;
        private ICustomerRepository _customerRepository;
        private ICustomerAddressRepository _customerAddressRepository;

        public UnitOfWork(CrystalMindDbContext context)
        {
            _context = context;
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository = _customerRepository ?? new CustomerRepository(_context);
            }
        }

        public ICustomerAddressRepository CustomerAddressRepository
        {
            get
            {
                return _customerAddressRepository = _customerAddressRepository ?? new CustomerAddressRepository(_context);
            }
        }

        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }


    public interface IUnitOfWork : IDisposable
    {
        public ICustomerRepository CustomerRepository { get; }
        public ICustomerAddressRepository CustomerAddressRepository { get; }

        void SaveChanges();        
    }
}
