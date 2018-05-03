using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITest.Areas.User.Models;
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

        public TestController(IUserTestService userTestService, ICategoryService categoryService, IMappingProvider mappingProvider)
        {
            this.userTestService = userTestService;
            this.categoryService = categoryService;
            this.mappingProvider = mappingProvider;
        }
        public IActionResult Index(string category)
        {
            if (this.categoryService.CheckIfCategoryExists(category))
            {
                var test = this.userTestService.GetAssignedTestWithCategory(category);
                var testModel = this.mappingProvider.MapTo<TakeTestViewModel>(test.Test);
                testModel.Category = test.Test.CategoryName;

                return View(testModel);
            }


            return View();
        }
    }
}
