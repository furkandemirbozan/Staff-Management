using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffmanagament.CORE.Models
{
    public class Role : IdentityRole<int>
    {
        public Role():base()
        {
        }
        public Role(string roleName) : base(roleName)
        {
        }
    }
}
