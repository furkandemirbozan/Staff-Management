using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class CreateCompanyDto
    {
        public int ?CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyLogoUrl { get; set; }
        public CreateAddressDto createAddressDto { get; set; }
    }
}
