using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string City { get; set; }
    }
}
