using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPITask.BLL.Services;
using WebAPITask.BLL.ViewModels;

namespace WebAPITask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private ICustomerAddressService _CustomerAddressService;

        public CustomerAddressController(ICustomerAddressService customerAddressService)
        {
            _CustomerAddressService = customerAddressService;
        }



        [HttpGet("list-all-customer-addresses-by-customer-id/{customerId}")]
        public Task<List<CustomerAddressViewModel>> ListAllCustomerAddresses(Guid customerId)
        {
            var res = _CustomerAddressService.GetAllCustomerAddressesByCustomerId(customerId);
            return res;
        }

        [HttpPost("add-Customer-address")]
        public Task<CustomerAddressViewModel> AddCustomerAddress(CustomerAddressViewModel model)
        {
            var res = _CustomerAddressService.CreateCustomerAddress(model);
            return res;
        }

        [HttpGet("view-customer-address/{id}")]
        public Task<CustomerAddressViewModel> ViewCustomerAddressById(Guid id)
        {
            var res = _CustomerAddressService.GetCustomerAddressByAddressId(id);
            return res;
        }

        [HttpPut("edit-customer-address")]
        public Task<CustomerAddressViewModel> EditCustomerAddress(CustomerAddressViewModel model)
        {
            var res = _CustomerAddressService.UpdateCustomerAddress(model);
            return res;
        }

        [HttpDelete("remove-customer-address-by-id/{id}")]
        public void RemoveCustomer(Guid id)
        {
            _CustomerAddressService.DeleteCustomerAddressById(id);
        }
    }
}
