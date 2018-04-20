using ITest.Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Data.Models
{
    public class Answer: DataModel
    {
        public Answer()
        {
            this.AnswersToUserTests = new HashSet<AnswersToUserTest>();
        }
        public string Content { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public bool IsCorrect { get; set; }
        public ICollection<AnswersToUserTest> AnswersToUserTests { get; set; }
    }
}
