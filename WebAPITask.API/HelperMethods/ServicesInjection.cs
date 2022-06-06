using Microsoft.Extensions.DependencyInjection;
using WebAPITask.BLL.Services;
using WebAPITask.DAL.Repositories;
using WebAPITask.DAL.UnitOfWork;

namespace WebAPITask.API.HelperMethods
{
    public static  class ServicesInjection
    {

        public static void AddServicesInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();            
            services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();                               
            services.AddScoped<ICustomerService, CustomerService>();                                    
            services.AddScoped<ICustomerAddressService, CustomerAddressService>();
        }
    }
}
