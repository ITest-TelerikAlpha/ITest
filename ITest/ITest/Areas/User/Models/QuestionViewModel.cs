using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.User.Models.HomeViewModels
{
    public class QuestionViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<AnswerViewModel> Answers { get; set; }
    }
}
