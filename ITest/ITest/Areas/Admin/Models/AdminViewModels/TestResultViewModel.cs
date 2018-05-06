using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.Admin.Models.AdminViewModels
{
    public class TestResultViewModel
    {
        public string TestName { get; set; }
        public string UserEmail { get; set; }
        public double Score { get; set; }
        public string CategoryName { get; set; }
        public int RequestedTime { get; set; }
    }
}
