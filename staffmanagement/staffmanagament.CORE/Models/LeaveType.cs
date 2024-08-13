using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[ForeignKey("Leave")]

        // Navigation properties
        public ICollection<Leave> Leaves { get; set; }
    }
}
