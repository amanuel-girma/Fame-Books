using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTemplate.Models
{
    public class AppUser : IdentityUser
    {
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
