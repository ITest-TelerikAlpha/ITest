using ITest.Data.Models.Abstraction;
using ITest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Data.Models
{
    public class Test : DataModel
    {
        public Test()
        {
            this.UserTest = new HashSet<UserTest>();

            this.Questions = new HashSet<Question>();
        }
        public string Name { get; set; }

        public bool IsPublished { get; set; }

        public int Duration { get; set; }

        //public Guid AuthorId { get; set; }
        
        public User Author { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<UserTest> UserTest { get; set; }
    }
}
