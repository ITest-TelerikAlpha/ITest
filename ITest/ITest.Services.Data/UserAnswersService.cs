using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Services.Data
{
    public class UserAnswersService : IUserAnswersService
    {
        private readonly IRepository<AnswersToUserTest> answersToUserTestRepository;
        private readonly ISaver saver;
        private readonly IMappingProvider mapper;

        public UserAnswersService(IRepository<AnswersToUserTest> answersToUserTestRepository, ISaver saver, IMappingProvider mapper)
        {
            this.answersToUserTestRepository = answersToUserTestRepository;
            this.saver = saver;
            this.mapper = mapper;
        }

        public void AddUserAnswer(string userTestId, string answerId)
        {
            var answerToUserTest = new AnswersToUserTest()
            {
                AnswerId = Guid.Parse(answerId),
                UserTestId = Guid.Parse(userTestId)
            };

            this.answersToUserTestRepository.Add(answerToUserTest);

            this.saver.SaveChanges();
        }
    }
}
