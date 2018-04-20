using ITest.Data.Models;
using ITest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.DTO
{
    class UserTestDTO
    {
        public Guid TestId { get; set; }

        public Test Test { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public double Score { get; set; }
        public ICollection<AnswersToUserTest> AnswersToUserTests { get; set; }
    }
}
