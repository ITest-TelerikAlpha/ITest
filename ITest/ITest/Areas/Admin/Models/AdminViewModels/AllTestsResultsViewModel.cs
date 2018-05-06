using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.Admin.Models.AdminViewModels
{
    public class AllTestsResultsViewModel
    {
        public AllTestsResultsViewModel()
        {
            this.AllTestsResults = new HashSet<TestResultViewModel>();
        }
        public ICollection<TestResultViewModel> AllTestsResults { get; set; }
    }
}
