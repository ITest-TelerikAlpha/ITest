using ITest.Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Data.Models
{
    public class Question : DataModel
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid TestId { get; set; }
        public Test Test {get; set;}
        public ICollection<Answer> Answers { get; set; }
    }
}
