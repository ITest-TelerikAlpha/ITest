using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITest.Data.Models
{
    public class AnswersToUserTest
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserTestId { get; set; }

        public UserTest UserTest { get; set; }

        public Guid AnswerId { get; set; }

        public Answer Answer { get; set; }
    }
}
