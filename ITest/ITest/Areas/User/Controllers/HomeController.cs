using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITest.Areas.User.Models.HomeViewModels;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ITest.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IUserTestService userTestService;
        private readonly IMappingProvider mappingProvider;

        public HomeController(ICategoryService categoryService, IUserTestService userTestService, IMappingProvider mappingProvider)
        {
            this.categoryService = categoryService;
            this.userTestService = userTestService;
            this.mappingProvider = mappingProvider;
        }

        public IActionResult Index()
        {
            var model = new CategoryCollectionViewModel();
            var collection = categoryService.GetAllCategories();
            model.Categories = mappingProvider.ProjectTo<TestCategoryViewModel>(collection).ToList();

            //Check if there is an active test

            foreach (var category in model.Categories)
            {
                if (userTestService.CheckIfUserHasAssignedTest(category.Name))
                {
                    category.IsTestTaken = true;
                }
                else
                {
                    category.IsTestTaken = false;
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult StartTest(string category)
        {
            if (!this.categoryService.CheckIfCategoryExists(category))
            {
                return View("Index");
            }   
            
            
            if (userTestService.CheckIfUserHasAssignedTest(category))
            {
                return RedirectToAction("Index", "Test", category);
            }
            else
            {
                userTestService.AssignTestToUser(category);
            }

            return View();
        }
    }
}