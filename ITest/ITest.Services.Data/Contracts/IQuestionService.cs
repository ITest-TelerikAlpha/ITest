using ITest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITest.Services.Data.Contracts
{
    public interface IQuestionService
    {
        IQueryable<AnswerDTO> GetAnswersForQuestion(string questionId);
    }
}
