using ITest.Areas.User.Models.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.User.Models
{
    public class TakeTestViewModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int RequestedTime { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}
