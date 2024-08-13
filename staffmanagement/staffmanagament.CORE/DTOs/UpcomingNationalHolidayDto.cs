using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.DTOs
{
    public class UpcomingNationalHolidayDto
    {
        public string NationalHolidayName { get; set; }
        public DateTime NationalHolidayStartDate { get; set; }
        public DateTime NationalHolidayEndDate { get; set; }
    }
}
