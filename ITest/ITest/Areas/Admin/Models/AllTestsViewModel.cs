using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.Admin.Models
{
    public class AllTestsViewModel
    {
        public AllTestsViewModel()
        {
            this.AllTests = new HashSet<TestViewModel>();
        }

        public ICollection<TestViewModel> AllTests { get; set; }
    }
}
