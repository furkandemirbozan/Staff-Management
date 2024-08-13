using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface INationalHolidayRepository: IRepository<NationalHoliday>
    {
        Task<NationalHoliday> UpdateAsync(NationalHoliday nationalHoliday);
        Task<NationalHoliday> DeleteAsync(NationalHoliday nationalHoliday);
    }
}
