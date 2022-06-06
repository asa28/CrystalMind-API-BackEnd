using System;

namespace WebAPITask.BLL.ViewModels
{
    public class CustomerAddressViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Address { get; set; }
        public int? AddressRank { get; set; }
    }
}
