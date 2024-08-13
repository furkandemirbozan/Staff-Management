﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LogoUrl { get; set; }
        //[ForeignKey("Address")]
        //[ForeignKey("EmployeeId")]


        // Navigation properties
        public Address? Address { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Department>? Departments { get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<Resume>? Resumes { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Job>? Jobs { get; set; }
    }
}