using ITest.Areas.Admin.Models;
using ITest.Areas.Admin.Models.AdminViewModels;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Services.Data.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Areas.Admin.Controllers
{
    //    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ITestService testService;
        private readonly IUserService userservice;
        private readonly ICategoryService categoryService;
        private readonly IMappingProvider mapper;
        private readonly IUserTestService userTestService;

        public AdminController(ITestService testService,
            IUserService userservice,
            ICategoryService categoryService,
            IMappingProvider mapper,
            IUserTestService userTestService)
        {
            this.testService = testService;
            this.userservice = userservice;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.userTestService = userTestService;
        }

        public IActionResult Index()
        {
            var allTestsViewModel = new AllTestsViewModel();
            var tests = this.testService.GetAllTests().ToList();

            foreach (var test in tests)
            {
                allTestsViewModel.AllTests.Add
                (new TestViewModel()
                {
                    Name = test.Name,
                    Category = test.CategoryName,
                    IsPublished = test.IsPublished
                });
            }
            return View(allTestsViewModel);
        }

        [HttpGet]
        public IActionResult CreateTest()
        {
            var createTestViewModel = new CreateTestViewModel();
            var categories = this.categoryService.GetAllCategories().ToList();

            foreach (var category in categories)
            {
                createTestViewModel.Categories.Add
                    (new CategoryViewModel()
                    {
                        Category = category.Name
                    }
                    );
            }

            return View(createTestViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveTest([FromBody] CreateTestViewModel testViewModel)
        {

            if (!this.ModelState.IsValid)
            {
                return View("CreateTest");
            }

            var testDTO = this.mapper.MapTo<TestDTO>(testViewModel);

            this.testService.CreateTest(testDTO);
            return Content("/Admin/Admin/Index");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteTest(string name)
        {
            this.testService.DeteleTest(name);
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult PublishTestFromDraft(string name)
        {
            this.testService.PublishTestFromDraft(name);
            return Ok();
        }
        public IActionResult CreateQuestion()
        {
            return PartialView("NewQuestionPartial");
        }

        public IActionResult AddNewAnswer()
        {
            return PartialView("NewAnswerPartial");
        }

        [HttpGet]
        public IActionResult EditTest([FromQuery(Name = "name")] string name)
        {
            var testDTO = this.testService.GetTestByName(name);
            var testViewModel = this.mapper.MapTo<CreateTestViewModel>(testDTO);
            var categories = this.categoryService.GetAllCategories().ToList();
            foreach (var category in categories)
            {
                testViewModel.Categories.Add(
                    new CategoryViewModel()
                    {
                        Category = category.Name
                    }
                );
            }

            return View(testViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEditedTest([FromBody]CreateTestViewModel testViewModel)
        {
            var testDTO = this.mapper.MapTo<TestDTO>(testViewModel);

            this.testService.EditTest(testDTO);


            return Content("/Admin/Admin/Index");
        }

        [HttpGet]
        public IActionResult TestResults()
        {
            var testResultsViewModel = new AllTestsResultsViewModel();
            var tests = this.userTestService.GetAllTestScoresWithUsers().ToList();

            foreach (var test in tests)
            {
                testResultsViewModel.AllTestsResults.Add
                (new TestResultViewModel()
                {
                    UserEmail = this.userservice.GetUserEmailById(test.UserId),
                    TestName = this.testService.GetTestById(test.TestId.ToString()).Name,
                    Score = test.Score,
                    CategoryName = test.Test.CategoryName,
                    RequestedTime = test.Test.RequestedTime,
                    ExecutionTime = test.ExecutionTime
                });
            }

            return View("TestResultsPartial", testResultsViewModel);
        }
    }
}