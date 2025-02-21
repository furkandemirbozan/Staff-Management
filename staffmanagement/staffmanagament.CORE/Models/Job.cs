﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //[ForeignKey("Company")]
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        //[ForeignKey("Employee")]

        // Navigation properties
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
