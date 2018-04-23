using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Services.Data.Contracts;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ITest.Services.Data
{
    public class AnswerService : IAnswerService
    {
        private readonly IRepository<Question> questionRepository;
        private readonly IRepository<Answer> answerRepository;
        private readonly ISaver saver;
        private readonly IMappingProvider mapper;

        public AnswerService(IRepository<Question> questionRepository, IRepository<Answer> answerRepository, ISaver saver, IMappingProvider mapper)
        {
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
            this.saver = saver;
            this.mapper = mapper;
        }
    }
}
