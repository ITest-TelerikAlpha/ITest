using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.DTO
{
    public class AnswersFromUserDTO
    {
        public string Category { get; set; }

        public ICollection<UserAnswerDTO> Answers { get; set; }
    }
}
