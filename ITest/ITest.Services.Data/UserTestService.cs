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
        private readonly IMappingProvider mapper;

        public UserTestService(IRepository<UserTest> userTestRepository, ITestService testService, IUserService userService, ISaver saver, IMappingProvider mapper)
        {
            this.userTestRepository = userTestRepository;
            this.testService = testService;
            this.userService = userService;
            this.saver = saver;
            this.mapper = mapper;
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
    }
}
