using ITest.Areas.Admin.Models;
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
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class AdminController: Controller
    {
        private readonly ITestService testService;
        private readonly IMappingProvider mapper;

        public AdminController(ITestService testService, IMappingProvider mapper)
        {
            this.testService = testService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var allTestsViewModel = new AllTestsViewModel();

            allTestsViewModel.AllTests.Add
                (new TestViewModel()
                {
                    Name = "Test",
                    IsPublished = true
                });
            return View(allTestsViewModel);
        }
    }
}
