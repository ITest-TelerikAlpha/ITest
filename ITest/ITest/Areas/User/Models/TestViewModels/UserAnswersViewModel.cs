using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.User.Models.TestViewModels
{
    public class UserAnswersViewModel
    {
        public UserAnswersViewModel()
        {
            this.UserAnswers = new HashSet<UserAnswerViewModel>();
        }
        public string Category { get; set; }
        public ICollection<UserAnswerViewModel> UserAnswers { get; set; }
    }
}
