using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITest.Services.Data.Contracts
{
    public interface ITestService
    {
        void CreateTest(TestDTO test);

        TestDTO GetRandomTestFromCategory(CategoryDTO category);

        void PublishTestFromDraft(string name);
        void EditTest(TestDTO test);
        void DeteleTest(string name);
        TestDTO GetTestById(string id);
        TestDTO GetTestByName(string name);
        void DisableTest(string name);
        IQueryable<TestDTO> GetAllTests();
    }
}
