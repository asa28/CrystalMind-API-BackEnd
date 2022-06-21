using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPITask.BLL.ViewModels;
using WebAPITask.DAL.Models;
using WebAPITask.DAL.UnitOfWork;

namespace WebAPITask.BLL.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            var entityList = _unitOfWork.CustomerRepository.GetAll();
            var modelList = _mapper.Map<List<CustomerViewModel>>(entityList);
            return await Task.FromResult(modelList);
        }
        public async Task<CustomerViewModel> GetCustomerById(Guid id)
        {
            var entityModel = _unitOfWork.CustomerRepository.FindById(id);
            var model = _mapper.Map<CustomerViewModel>(entityModel);
            return await Task.FromResult(model);
        }
        public async Task<CustomerViewModel> CreateCustomer(CustomerViewModel model)
        {
            var entityModel = _mapper.Map<Customer>(model);
            _unitOfWork.CustomerRepository.Add(entityModel);
            _unitOfWork.SaveChanges();
            var returnModel = _mapper.Map<CustomerViewModel>(entityModel);                
            return await Task.FromResult(returnModel);
        }
        public async Task<CustomerViewModel> UpdateCustomer(CustomerViewModel model)
        {
            var updatedEntity = _mapper.Map<Customer>(model);
            _unitOfWork.CustomerRepository.Update(updatedEntity);
            _unitOfWork.SaveChanges();
            return await Task.FromResult(model);
        }
        public void DeleteCustomerById(Guid id)
        {
            _unitOfWork.CustomerRepository.DeleteById(id);
            _unitOfWork.SaveChanges();
        }
    }


    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAllCustomers();
        Task<CustomerViewModel> CreateCustomer(CustomerViewModel model);
        Task<CustomerViewModel> GetCustomerById(Guid id);
        Task<CustomerViewModel> UpdateCustomer(CustomerViewModel model);
        void DeleteCustomerById(Guid id);
    }
}
