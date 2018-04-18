using ITest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Data.Models
{
    public class UserTests
    {
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public double Score { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
