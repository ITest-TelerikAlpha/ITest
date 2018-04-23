using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITest.Data.Models;
using ITest.Data.Models.Abstraction;
using Microsoft.AspNetCore.Identity;

namespace ITest.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser, IDeletable
    {
        public User()
        {
            this.UserTest = new HashSet<UserTest>(); 
        }
        

        public ICollection<UserTest> UserTest { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
