using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebAPITask.BLL.ViewModels;
using WebAPITask.DAL.Models;
using WebAPITask.DAL.UnitOfWork;

namespace WebAPITask.BLL.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerAddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<CustomerAddressViewModel>> GetAllCustomerAddressesByCustomerId(Guid customerId)
        {
            var addressList = _unitOfWork.CustomerAddressRepository.getAllAddressesbyCustomerId(customerId);
            var addressListModel = _mapper.Map<List<CustomerAddressViewModel>>(addressList);
            return await Task.FromResult(addressListModel);
        }
        public async Task<CustomerAddressViewModel> GetCustomerAddressByAddressId(Guid id)
        {
            var addressEntity = _unitOfWork.CustomerAddressRepository.FindById(id);
            var addressModel = _mapper.Map<CustomerAddressViewModel>(addressEntity);
            return await Task.FromResult(addressModel);
        }
        public async Task<CustomerAddressViewModel> CreateCustomerAddress(CustomerAddressViewModel model)
        {
            var customerAddressEntity = _mapper.Map<CustomerAddress>(model);
            _unitOfWork.CustomerAddressRepository.Add(customerAddressEntity);
            _unitOfWork.SaveChanges();
            var returnModel = _mapper.Map<CustomerAddressViewModel>(customerAddressEntity);
            return await Task.FromResult(returnModel);
        }
        public async Task<CustomerAddressViewModel> UpdateCustomerAddress(CustomerAddressViewModel model)
        {
            var updatedEntity = _mapper.Map<CustomerAddress>(model);
            _unitOfWork.CustomerAddressRepository.Update(updatedEntity);
            _unitOfWork.SaveChanges();
            return await Task.FromResult(model);
        }
        public void DeleteCustomerAddressById(Guid id)
        {
            _unitOfWork.CustomerAddressRepository.DeleteById(id);
            _unitOfWork.SaveChanges();
        }
    }


    public interface ICustomerAddressService
    {
        Task<List<CustomerAddressViewModel>> GetAllCustomerAddressesByCustomerId(Guid customerId);
        Task<CustomerAddressViewModel> GetCustomerAddressByAddressId(Guid id);
        Task<CustomerAddressViewModel> CreateCustomerAddress(CustomerAddressViewModel model);
        Task<CustomerAddressViewModel> UpdateCustomerAddress(CustomerAddressViewModel model);
        void DeleteCustomerAddressById(Guid id);
    }
}
