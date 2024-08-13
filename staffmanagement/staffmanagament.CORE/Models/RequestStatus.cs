using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class RequestStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }



        // Navigation properties
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Leave> Leaves { get; set; }
    }
}
