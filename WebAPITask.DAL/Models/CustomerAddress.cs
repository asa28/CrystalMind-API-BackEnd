using System;

namespace WebAPITask.DAL.Models
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Address { get; set; }
        public int? AddressRank { get; set; }
    }
}
