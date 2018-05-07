using ITest.Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITest.Data.Models
{
    public class AnswersToUserTest : IDeletable
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserTestId { get; set; }

        public UserTest UserTest { get; set; }

        public Guid AnswerId { get; set; }

        public Answer Answer { get; set; }
        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get ; set ; }
    }
}
