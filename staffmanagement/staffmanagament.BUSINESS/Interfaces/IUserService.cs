using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.BUSINESS.Interfaces
{
    public interface IUserService
    {

        Task<User> GetUserByUsername(string username);
        Task<IList<User>> GetAllUsers();
        Task<User> GetRelatedUser(int employeeId);
        Task AddUserAsync(User user);
        Task<User> Authenticate(string username, string password);

    }
}
