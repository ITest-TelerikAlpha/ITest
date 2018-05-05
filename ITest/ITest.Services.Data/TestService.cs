using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Models;
using ITest.Services.Data.Contracts;
using System;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ITest.Services.Data
{
    public class TestService : ITestService
    {
        private readonly IRepository<Test> testRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Question> questionsRepository;
        private readonly IRepository<Answer> answersRepository;
        private readonly ICategoryService categoryService;
        private readonly ISaver saver;
        private readonly IMappingProvider mapper;

        public TestService(IRepository<Test> testRepository,
            IRepository<User> userRepository,
            IRepository<Category> categoryRepository,
            IRepository<Question> questionsRepository,
            IRepository<Answer> answersRepository,
            ICategoryService categoryService,
            ISaver saver,
            IMappingProvider mapper)
        {
            this.testRepository = testRepository;
            this.userRepository = userRepository;
            this.categoryRepository = categoryRepository;
            this.questionsRepository = questionsRepository;
            this.answersRepository = answersRepository;
            this.categoryService = categoryService;
            this.saver = saver;
            this.mapper = mapper;
        }

        public void CreateTest(TestDTO test)
        {
            if (test == null)
            {
                throw new ArgumentNullException("Test cannot be null");
            }

            var testToAdd = this.mapper.MapTo<Test>(test);
            testToAdd.CategoryId = this.categoryService.GetCategoryId(test.CategoryName);
            // testToAdd.CategoryId = testToAdd.Category.Id; 
            this.testRepository.Add(testToAdd);
            this.saver.SaveChanges();
        }

        public TestDTO GetRandomTestFromCategory(CategoryDTO category)
        {
            var randomInstance = new Random();

            var allTestsFromCategory = testRepository.All
                .Where(t => t.Category.Name == category.Name &&
                            t.IsPublished)
                            .ToList();

            int testIndex = randomInstance.Next(allTestsFromCategory.Count - 1);
            var test = allTestsFromCategory[testIndex];

            var testDto = this.mapper.MapTo<TestDTO>(test);

            return testDto;
        }

        public void PublishTestFromDraft(string name)
        {
            var testToPublish = this.testRepository.All.Where(t => t.Name == name).FirstOrDefault();
            testToPublish.IsPublished = true;
            this.saver.SaveChanges();
        }

        public TestDTO GetTestByName(string name)
        {
            var test = this.testRepository.All
                                .Where(x => x.Name == name)
                                .Include(x => x.Questions)
                                .ThenInclude(x => x.Answers)
                                .FirstOrDefault();

            var testDTO = mapper.MapTo<TestDTO>(test);

            return testDTO;
        }
        public void EditTest(TestDTO test)
        {
            var testToEdit = this.mapper.MapTo<Test>(test);

            this.testRepository.Update(testToEdit);
            foreach (var question in testToEdit.Questions)
            {
                this.questionsRepository.Update(question);
                foreach (var answer in question.Answers)
                {
                    this.answersRepository.Update(answer);
                }
            }

            this.saver.SaveChanges();         
        }

        public void DeteleTest(string name)
        {
            var testToDelete = this.testRepository.All.Where(t => t.Name == name)
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers).FirstOrDefault();

            foreach (var question in testToDelete.Questions)
            {
                question.IsDeleted = true;
                foreach (var answer in question.Answers)
                {
                    answer.IsDeleted = true;
                }
            }
            //this.testRepository.Delete(testToDelete);
            this.saver.SaveChanges();
        }
        public TestDTO GetTestById(string id)
        {
            var test = this.testRepository
                .All
                .Include(t => t.Category)
                .FirstOrDefault(t => t.Id.ToString() == id);


            var testDTO = this.mapper.MapTo<TestDTO>(test);

            return testDTO;
        }


        public IQueryable<TestDTO> GetAllTests()
        {
            return this.mapper.ProjectTo<TestDTO>(this.testRepository.All);
        }
    }
}
