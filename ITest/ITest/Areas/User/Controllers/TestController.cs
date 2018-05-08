using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITest.Areas.User.Models;
using ITest.Areas.User.Models.TestViewModels;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Services.Data.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITest.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class TestController : Controller
    {
        private readonly IUserTestService userTestService;
        private readonly ICategoryService categoryService;
        private readonly IMappingProvider mappingProvider;
        private readonly ITestService testService;

        public TestController(IUserTestService userTestService, ICategoryService categoryService, IMappingProvider mappingProvider, ITestService testService)
        {
            this.userTestService = userTestService;
            this.categoryService = categoryService;
            this.mappingProvider = mappingProvider;
            this.testService = testService;
        }
        

        public IActionResult Index(string category)
        {
            var activeTestCategory = this.userTestService.CheckIfUserHasActiveTest();
            if (activeTestCategory != null && activeTestCategory.Category.Name != category)
            {
                return RedirectToAction("Index", "Test", new { category = activeTestCategory.Category.Name });
            }

            if (this.categoryService.CheckIfCategoryExists(category))
            {
                var test = this.userTestService.GetAssignedTestWithCategory(category);

                if (test == null)
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }

                if (test.Score != 0.0)
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }

                var testModel = this.mappingProvider.MapTo<TakeTestViewModel>(test.Test);
                testModel.RequestedTime = test.Test.RequestedTime * 60 - (int)(DateTime.Now - test.StartTime).TotalSeconds;

                if (testModel.RequestedTime < 1)
                {
                    this.userTestService.FailUserNoSubmit(test.Test.Id.ToString());

                    return RedirectToAction("Index", "Home", new { area = "User" });
                }

                testModel.Category = test.Test.CategoryName;

                return View(testModel);
            }


            return RedirectToAction("Index", "Home", new { area = "User" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitTest([FromBody] UserAnswersViewModel answersViewModel)
        {
            if (ModelState.IsValid)
            {
                var answers = this.mappingProvider.MapTo<AnswersFromUserDTO>(answersViewModel);
                this.userTestService.EvaluateTest(answers);

            }

            return Ok();
        }
    }
}
