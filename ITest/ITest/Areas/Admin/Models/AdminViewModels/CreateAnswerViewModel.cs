using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.Admin.Models
{
    public class CreateAnswerViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}
