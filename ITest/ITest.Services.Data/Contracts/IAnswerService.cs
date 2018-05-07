using ITest.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Services.Data.Contracts
{
    public interface IAnswerService
    {
        bool IsAnswerCorrect(string id);
        AnswerDTO GetRightAnswer(QuestionDTO question);
    }
}
