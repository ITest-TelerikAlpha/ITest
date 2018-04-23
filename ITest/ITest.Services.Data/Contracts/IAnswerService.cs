using ITest.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Services.Data.Contracts
{
    public interface IAnswerService
    {
        AnswerDTO GetRightAnswer(QuestionDTO question);
    }
}
