using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.Admin.Models
{
    public class CreateQuestionViewModel
    {
        public CreateQuestionViewModel()
        {
            this.Answers = new HashSet<CreateAnswerViewModel>();
        }
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter your question!")]
        [StringLength(600, MinimumLength = 30, ErrorMessage = "Your question can be maximum 600 symbols!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please add answers to your question!")]
        public ICollection<CreateAnswerViewModel> Answers { get; set; }
    }
}
