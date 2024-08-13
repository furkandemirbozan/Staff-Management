using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(User user);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetUserByEmployeeId(int employeeId);
    }
}
