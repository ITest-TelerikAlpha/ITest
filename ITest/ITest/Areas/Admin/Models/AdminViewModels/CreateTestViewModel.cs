using ITest.Areas.Admin.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.Admin.Models
{
    public class CreateTestViewModel
    {
        public CreateTestViewModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
            this.Questions = new HashSet<CreateQuestionViewModel>();
        }
        public string Name { get; set; }
        public int RequestedTime { get; set; }
        public string Category { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; }
        public ICollection<CreateQuestionViewModel> Questions { get; set; }
    }
}
