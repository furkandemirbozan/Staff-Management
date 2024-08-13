using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<Expense> UpdateAsync(Expense expense);
        Task<Expense> DeleteAsync(Expense expense);
    }
}
