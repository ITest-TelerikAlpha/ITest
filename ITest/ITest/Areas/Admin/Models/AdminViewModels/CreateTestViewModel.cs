using ITest.Areas.Admin.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        [Range(20, 240)]
        public int RequestedTime { get; set; }
        public ICollection<CreateQuestionViewModel> Questions { get; set; }
        public bool IsPublished { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
