using ITest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.DTO
{
    public class AnswerDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid QuestionId { get; set; }
        public QuestionDTO Question { get; set; }
        public bool IsCorrect { get; set; }
    }
}
