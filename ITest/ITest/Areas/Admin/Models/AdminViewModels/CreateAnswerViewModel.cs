using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.Admin.Models
{
    public class CreateAnswerViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please fill in the answer's content")]
        [StringLength(400, MinimumLength = 2, ErrorMessage = "The length can be maximum 400 symbols!")]
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}
