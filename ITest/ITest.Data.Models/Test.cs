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
            this.Questions = new HashSet<Question>();
        }
        public string Name { get; set; } 

        public string AuthorID { get; set; }
        public User Author { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
