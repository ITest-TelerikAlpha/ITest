using ITest.Data.Models;
using ITest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.DTO
{
    public class UserTestDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public Guid TestId { get; set; }

        public TestDTO Test { get; set; }

        public double Score { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;
    }
}
