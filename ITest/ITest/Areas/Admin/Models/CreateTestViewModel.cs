using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.Admin.Models
{
    public class CreateTestViewModel
    {
        public string Name { get; set; }
        public int RequestedTime { get; set; }
        public string Category { get; set; }

        public ICollection<CreateQuestionViewModel> Questions { get; set; }
    }
}
