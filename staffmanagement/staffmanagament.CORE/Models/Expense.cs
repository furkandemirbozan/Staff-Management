﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string? Description { get; set; }
        public DateTime RequestedDate { get; set; }
        public int ApprovedById { get; set; }
        //[ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        //[ForeignKey("RequestStatus")]
        public int RequestStatusId { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}
