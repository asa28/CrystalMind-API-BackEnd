using AutoMapper;
using System.Collections.Generic;
using WebAPITask.BLL.ViewModels;
using WebAPITask.DAL.Models;

namespace WebAPITask.BLL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressViewModel>().ReverseMap();
            //CreateMap<List<Customer>, List<CustomerViewModel>>().ReverseMap();
            //CreateMap<List<CustomerAddress>, List<CustomerAddressViewModel>>().ReverseMap();
        }
    }
}
