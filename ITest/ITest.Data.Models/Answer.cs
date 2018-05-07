using ITest.Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITest.Data.Models
{
    public class Answer: DataModel
    {
        public Answer()
        {
            this.AnswersToUserTests = new HashSet<AnswersToUserTest>();
        }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswersToUserTest> AnswersToUserTests { get; set; }
    }
}
