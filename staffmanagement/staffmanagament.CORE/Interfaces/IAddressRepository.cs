using staffmanagament.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> UpdateAsync(Address address);
        Task<Address> DeleteAsync(Address address);
    }
}
