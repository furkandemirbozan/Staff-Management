using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class LeaveCardDto
    {
        public int RemainingLeaveDays { get; set; }
        public List<LeaveDetailDto> Leaves { get; set; }
    }
}
