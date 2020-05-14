using System;
namespace TinyCrm.Core.Services.Options
{
    public class UpdateCustomerOptions
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }

        public UpdateCustomerOptions()
        {
        }
    }
}
