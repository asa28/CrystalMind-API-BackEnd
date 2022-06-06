using System;

namespace WebAPITask.BLL.ViewModels
{

    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}