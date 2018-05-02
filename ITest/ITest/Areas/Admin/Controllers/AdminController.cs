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

        public AdminController(ITestService testService, IUserService userservice, ICategoryService categoryService, IMappingProvider mapper)
        {
            this.testService = testService;
            this.userservice = userservice;
            this.categoryService = categoryService;
            this.mapper = mapper;
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
        public IActionResult SaveTest(CreateTestViewModel testViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var testDTO = this.mapper.MapTo<TestDTO>(testViewModel);
                
                this.testService.CreateTest(testDTO);
            }

            return Content("/Admin/Admin/Index");
        }

        public IActionResult CreateQuestion()
        {
            //var question = new CreateQuestionViewModel();

            return PartialView("NewQuestionPartial");
        }

        public IActionResult AddNewAnswer()
        {
            return PartialView("NewAnswerPartial");
        }
    }
}
