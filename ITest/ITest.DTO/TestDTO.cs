using ITest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.DTO
{
    public class TestDTO
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
        public bool IsPublished { get; set; }
    }
}
