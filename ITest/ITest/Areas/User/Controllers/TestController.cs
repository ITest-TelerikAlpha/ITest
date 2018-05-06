using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITest.Areas.User.Models;
using ITest.Areas.User.Models.TestViewModels;
using ITest.Infrastructure.Providers;
using ITest.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITest.Areas.User.Controllers
{
    [Area("User")]
    public class TestController : Controller
    {
        private readonly IUserTestService userTestService;
        private readonly ICategoryService categoryService;
        private readonly IMappingProvider mappingProvider;
        private readonly IList<string> link;

        public TestController(IUserTestService userTestService, ICategoryService categoryService, IMappingProvider mappingProvider)
        {
            this.userTestService = userTestService;
            this.categoryService = categoryService;
            this.mappingProvider = mappingProvider;
            this.link = new List<string>();
        }
        public IActionResult Index(string category="Java")
        {
            //check if user has active test
                
            if (this.categoryService.CheckIfCategoryExists(category))
            {
                var test = this.userTestService.GetAssignedTestWithCategory(category);
                
                if (test.Score != 0.0)
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }

                var testModel = this.mappingProvider.MapTo<TakeTestViewModel>(test.Test);
                testModel.RequestedTime = test.Test.RequestedTime * 60 - (int)(DateTime.Now - test.StartTime).TotalSeconds;

                if (testModel.RequestedTime < 1)
                {
                    //calculate test.
                    //return RedirectToAction("Index", "Home", new { area = "User" });
                }

                testModel.Category = test.Test.CategoryName;

                return View(testModel);
            }


            return RedirectToAction("Index", "Home", new { area = "User" });
        }

        [HttpPost]
        public  IActionResult SubmitTest(UserAnswersViewModel answersViewModel)
        {

            return Ok();
        }
    }
}
