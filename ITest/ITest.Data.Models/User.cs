using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITest.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace ITest.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        public User()
        {
            this.UserTest = new HashSet<UserTest>(); 
        }
        

        public ICollection<UserTest> UserTest { get; set; }
    }
}
