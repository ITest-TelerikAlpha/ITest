using ITest.Areas.Admin.Models;
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
//    [Area("Admin")]
    public class AdminController: Controller
    {
        private readonly ITestService testService;
        private readonly IUserService userservice;
        private readonly IMappingProvider mapper;

        public AdminController(ITestService testService, IUserService userservice, IMappingProvider mapper)
        {
            this.testService = testService;
            this.userservice = userservice;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var allTestsViewModel = new AllTestsViewModel();
            var tests= this.testService.GetAllTests().ToList();

            foreach (var test in tests)
            {
                allTestsViewModel.AllTests.Add
                (new TestViewModel()
                {
                    Name = test.Name,
                    Category = test.Category.Name,
                    IsPublished = test.IsPublished
                });
            }
            return View(allTestsViewModel);
        }

        [HttpGet]
        public IActionResult CreateTest()
        {
            return View(new CreateTestViewModel()
            {
                Questions = new List<CreateQuestionViewModel>()
            });
        }

        [HttpPost]
        public IActionResult CreateTest(CreateTestViewModel createTestViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(createTestViewModel);
            }

            var authorID = this.userservice.GetCurrentLoggedUser();
            var currentTestDTO = this.mapper.MapTo<TestDTO>(createTestViewModel);
            currentTestDTO.Author.Id = authorID;

            try
            {
                this.testService.CreateTest(currentTestDTO);
            }
            catch(Exception)
            {
                return View(createTestViewModel);
            }

            return View();
        }
    }
}
