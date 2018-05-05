using System;
using System.Collections.Generic;
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

        public string Content { get; set; }
        public ICollection<CreateAnswerViewModel> Answers { get; set; }
    }
}
