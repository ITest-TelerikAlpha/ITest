using ITest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.DTO
{
    public class QuestionDTO
    {
        //public Guid Id { get; set; }
        public string Content { get; set; }
       // public Guid TestId { get; set; }
        //public TestDTO Test { get; set; }
        public ICollection<AnswerDTO> Answers { get; set; }
    }
}
