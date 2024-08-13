﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //[ForeignKey("User")]
        public int UserId { get; set; }
        //[ForeignKey("Company")]
        public int CompanyId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Company Company { get; set; }


    }
}
