using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITest.Services.Data
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> questionRepository;
        private readonly ISaver saver;
        private IMappingProvider mapper;
        public QuestionService(IRepository<Question> questionRepository, ISaver saver, IMappingProvider mapper)
        {
            this.questionRepository = questionRepository;
            this.saver = saver;
            this.mapper = mapper;
        }
        public IQueryable<AnswerDTO> GetAnswersForQuestion(string questionId)
        {
            var questionAnswers = this.questionRepository
                                     .All
                                     .Include(q => q.Answers)
                                     .Where(q => q.Id.ToString() == questionId)
                                     .SelectMany(q => q.Answers);

            var answers = mapper.ProjectTo<AnswerDTO>(questionAnswers);

            return answers;
        }
    }
}
