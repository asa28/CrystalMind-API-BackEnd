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
    public class CustomerController : ControllerBase
    {
        private ICustomerService _CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }



        [HttpGet("list-all-customers")]
        public Task<List<CustomerViewModel>> ListAllCustomers()
        {
            var res = _CustomerService.GetAllCustomers();
            return res;
        }

        [HttpPost("add-customer")]
        public Task<CustomerViewModel> AddCustomer(CustomerViewModel model)
        {
            var res = _CustomerService.CreateCustomer(model);
            return res;
        }

        [HttpGet("view-customer/{id}")]
        public Task<CustomerViewModel> ViewCustomerById(Guid id)
        {
            var res = _CustomerService.GetCustomerById(id);
            return res;
        }

        [HttpPut("edit-customer")]
        public Task<CustomerViewModel> EditCustomer(CustomerViewModel model)
        {
            var res = _CustomerService.UpdateCustomer(model);
            return res;
        }

        [HttpDelete("remove-customer/{id}")]
        public void RemoveCustomer(Guid id)
        {
            _CustomerService.DeleteCustomerById(id);
        }        
    }
}
