using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        //[ForeignKey("Company")]
        public int? CompanyId { get; set; }
        //[ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        // Navigation properties 
        public Company? Company { get; set; }
        public Employee? Employee { get; set; }
    }
}
