﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public int ApprovedById { get; set; }
        //[ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        //[ForeignKey("LeaveType")]
        public int LeaveTypeId { get; set; }
        //[ForeignKey("RequestStatus")]
        public int RequestStatusId { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
        public LeaveType LeaveType { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}
