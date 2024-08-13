using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class User : IdentityUser<int>
    {
        public int? CompanyId { get; set; }


        // Navigation properties
        public Employee? Employee { get; set; }
        public Company? Company { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
