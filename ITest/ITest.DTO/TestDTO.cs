using ITest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.DTO
{
    public class TestDTO
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int RequestedTime { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
        public bool IsPublished { get; set; }
        //public UserDTO Author { get; set; }

        
    }
}
