using ITest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.User.Models.HomeViewModels
{
    public class CategoryCollectionViewModel
    {
        public CategoryCollectionViewModel()
        {
            this.Categories = new List<TestCategoryViewModel>();
        }
        public IList<TestCategoryViewModel> Categories { get; set; }
    }
}
