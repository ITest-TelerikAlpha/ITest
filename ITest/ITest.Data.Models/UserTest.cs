using ITest.Data.Models.Abstraction;
using ITest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITest.Data.Models
{
    public class UserTest : IDeletable
    {
        public UserTest()
        {
            this.AnswersToUserTests = new HashSet<AnswersToUserTest>();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid TestId { get; set; }

        public Test Test { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public double? Score { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public ICollection<AnswersToUserTest> AnswersToUserTests { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
