using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class GetLeaveDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public int ApprovedById { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int RequestStatusId { get; set; }
    }
}
