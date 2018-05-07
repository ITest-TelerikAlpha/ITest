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
    public class UserTestService : IUserTestService
    {
        private readonly IRepository<UserTest> userTestRepository;
        private readonly ITestService testService;
        private readonly IUserService userService;
        private readonly ISaver saver;
        private readonly IUserAnswersService userAnswersService;
        private readonly IMappingProvider mapper;
        private readonly IAnswerService answerService;

        public UserTestService(IRepository<UserTest> userTestRepository, ITestService testService
            , IUserService userService, ISaver saver, IUserAnswersService userAnswersService
            , IMappingProvider mapper, IAnswerService answerService)
        {
            this.userTestRepository = userTestRepository;
            this.testService = testService;
            this.userService = userService;
            this.saver = saver;
            this.userAnswersService = userAnswersService;
            this.mapper = mapper;
            this.answerService = answerService;
        }

        public bool CheckIfUserHasAssignedTest(string category)
        {
            var userId = this.userService.GetCurrentLoggedUser();

            var test = this.userTestRepository.All
                .Where(x => x.UserId == userId && x.Test.Category.Name == category)
                .FirstOrDefault();

            if (test is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public UserTestDTO GetAssignedTestWithCategory(string category)
        {
            var userId = this.userService.GetCurrentLoggedUser();

            var userTest = userTestRepository.All
                                .Where(x => x.UserId == userId)
                                .Include(x => x.Test.Category)
                                .Include(x => x.Test)
                                .ThenInclude(x => x.Questions)
                                .ThenInclude(x => x.Answers)
                                .Where(x => x.Test.Category.Name == category)
                                .FirstOrDefault();

            var dto = mapper.MapTo<UserTestDTO>(userTest);

            return dto;
        }

        public void AssignTestToUser(string category)
        {
            var userId = this.userService.GetCurrentLoggedUser();

            var categoryDTO = new CategoryDTO() { Name = category };

            var test = this.testService.GetRandomTestFromCategory(categoryDTO);


            var userTestsToAdd = new UserTestDTO()
            {
                UserId = userId,
                TestId = test.Id
            };

            this.Publish(userTestsToAdd);
        }

        public void Publish(UserTestDTO dto)
        {
            var model = this.mapper.MapTo<UserTest>(dto);
            this.userTestRepository.Add(model);
            this.saver.SaveChanges();
        }

        public IQueryable<UserTestDTO> GetAllTestScoresWithUsers()
        {
            return this.mapper.ProjectTo<UserTestDTO>(this.userTestRepository.All);
        }

        public CheckActiveTestDTO CheckIfUserHasActiveTest()
        {
            var userId = this.userService.GetCurrentLoggedUser();

            var test = this.userTestRepository.All
                .Where(x => x.UserId == userId && x.ExecutionTime == TimeSpan.Zero && x.Score == 0.0)
                .Include(x => x.Test)
                .ThenInclude(x => x.Category)
                .FirstOrDefault();

            if (test is null)
            {
                return null;
            }

            var testDTO = this.mapper.MapTo<CheckActiveTestDTO>(test.Test);

            return testDTO;
        }

        public void FailUserNoSubmit(string testId)
        {
            var userId = this.userService.GetCurrentLoggedUser();

            var userTest = this.userTestRepository.All
                .Include(x => x.Test)
                .SingleOrDefault(x => x.Test.Id.ToString() == testId && x.UserId == userId);


            userTest.Score = 0.1;
            userTest.ExecutionTime = new TimeSpan(0,0,userTest.Test.RequestedTime * 60);

            this.saver.SaveChanges();
        }

        public void EvaluateTest(AnswersFromUserDTO model)
        {
            var userId = this.userService.GetCurrentLoggedUser();
            var testInDb = this.GetAssignedTestWithCategory(model.Category);
            double score = 0.0;
            double correctAnswerWeight = 100 / testInDb.Test.Questions.Count;

            foreach (var answer in model.Answers)
            {
                if (this.answerService.IsAnswerCorrect(answer.AnswerId))
                {
                    score += correctAnswerWeight;
                }
                this.userAnswersService.AddUserAnswer(testInDb.Id, answer.AnswerId);
            }

            if (score == 0.0)
            {
                score = 0.1;
            }

            var time = DateTime.Now - testInDb.StartTime;

            this.UpdateScoreAndTime(testInDb.TestId.ToString(), score, time);
        }

        public void UpdateScoreAndTime(string testId, double score, TimeSpan time)
        {
            var userId = this.userService.GetCurrentLoggedUser();

            var userTest = this.userTestRepository.All
                .Include(x => x.Test)
                .SingleOrDefault(x => x.Test.Id.ToString() == testId && x.UserId == userId);


            userTest.Score = score;
            userTest.ExecutionTime = time;

            this.saver.SaveChanges();
        }
    }
}
