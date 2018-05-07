using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Models;
using ITest.Services.Data;
using ITest.Services.Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ITest.UnitTests.TestService
{
    [TestClass]
    public class CreateTestShould
    {
        [TestMethod]
        public void ThrowArgumentNulException_IfTheTestIsNull()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var questionRepositoryMock = new Mock<IRepository<Question>>();
            var testRepositoryMock = new Mock<IRepository<Test>>();
            var userRepositoryMock = new Mock<IRepository<User>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var answerRepositoryMock = new Mock<IRepository<Answer>>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var testService = new Services.Data.TestService(testRepositoryMock.Object, 
                userRepositoryMock.Object, 
                categoryRepositoryMock.Object, 
                questionRepositoryMock.Object, 
                answerRepositoryMock.Object, 
                categoryServiceMock.Object, 
                saverMock.Object,
                mapperMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => testService.CreateTest(null));
        }

        [TestMethod]
        public void CallMapToOnce()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var questionRepositoryMock = new Mock<IRepository<Question>>();
            var testRepositoryMock = new Mock<IRepository<Test>>();
            var userRepositoryMock = new Mock<IRepository<User>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var answerRepositoryMock = new Mock<IRepository<Answer>>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var testService = new Services.Data.TestService(testRepositoryMock.Object,
                userRepositoryMock.Object,
                categoryRepositoryMock.Object,
                questionRepositoryMock.Object,
                answerRepositoryMock.Object,
                categoryServiceMock.Object,
                saverMock.Object,
                mapperMock.Object);

            var test = new TestDTO()
            {
                CategoryName = "Category1"
            };

            var models = new List<Category>()
            {
                new Category {Id = Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"), Name = "Category1"},
            };

            var testToAdd = new Test();
            categoryRepositoryMock.Setup(x => x.All).Returns(models.AsQueryable);
            categoryServiceMock.Setup(x => x.GetCategoryId("Category1")).Returns(Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"));
            mapperMock.Setup(x => x.MapTo<Test>(test)).Returns(testToAdd);
            testService.CreateTest(test);
            mapperMock.Verify(x => x.MapTo<Test>(It.IsAny<TestDTO>()), Times.Once);
        }

        [TestMethod]
        public void CallGetCategoryIdOnce()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var questionRepositoryMock = new Mock<IRepository<Question>>();
            var testRepositoryMock = new Mock<IRepository<Test>>();
            var userRepositoryMock = new Mock<IRepository<User>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var answerRepositoryMock = new Mock<IRepository<Answer>>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var testService = new Services.Data.TestService(testRepositoryMock.Object,
                userRepositoryMock.Object,
                categoryRepositoryMock.Object,
                questionRepositoryMock.Object,
                answerRepositoryMock.Object,
                categoryServiceMock.Object,
                saverMock.Object,
                mapperMock.Object);

            var test = new TestDTO()
            {
                CategoryName = "Category1"
            };

            var models = new List<Category>()
            {
                new Category {Id = Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"), Name = "Category1"},
            };

            var testToAdd = new Test();
            categoryRepositoryMock.Setup(x => x.All).Returns(models.AsQueryable);
            mapperMock.Setup(x => x.MapTo<Test>(test)).Returns(testToAdd);
            testService.CreateTest(test);
            categoryServiceMock.Verify(x => x.GetCategoryId(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void CallAddOnce()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var questionRepositoryMock = new Mock<IRepository<Question>>();
            var testRepositoryMock = new Mock<IRepository<Test>>();
            var userRepositoryMock = new Mock<IRepository<User>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var answerRepositoryMock = new Mock<IRepository<Answer>>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var testService = new Services.Data.TestService(testRepositoryMock.Object,
                userRepositoryMock.Object,
                categoryRepositoryMock.Object,
                questionRepositoryMock.Object,
                answerRepositoryMock.Object,
                categoryServiceMock.Object,
                saverMock.Object,
                mapperMock.Object);

            var test = new TestDTO()
            {
                CategoryName = "Category1"
            };

            var models = new List<Category>()
            {
                new Category {Id = Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"), Name = "Category1"},
            };

            var testToAdd = new Test();
            categoryRepositoryMock.Setup(x => x.All).Returns(models.AsQueryable);
            categoryServiceMock.Setup(x => x.GetCategoryId("Category1")).Returns(Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"));
            mapperMock.Setup(x => x.MapTo<Test>(test)).Returns(testToAdd);
            testService.CreateTest(test);
            testRepositoryMock.Verify(x => x.Add(testToAdd), Times.Once);
        }

        [TestMethod]
        public void CallSaveChangesOnce()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var questionRepositoryMock = new Mock<IRepository<Question>>();
            var testRepositoryMock = new Mock<IRepository<Test>>();
            var userRepositoryMock = new Mock<IRepository<User>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var answerRepositoryMock = new Mock<IRepository<Answer>>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var testService = new Services.Data.TestService(testRepositoryMock.Object,
                userRepositoryMock.Object,
                categoryRepositoryMock.Object,
                questionRepositoryMock.Object,
                answerRepositoryMock.Object,
                categoryServiceMock.Object,
                saverMock.Object,
                mapperMock.Object);

            var test = new TestDTO()
            {
                CategoryName = "Category1"
            };

            var models = new List<Category>()
            {
                new Category {Id = Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"), Name = "Category1"},
            };

            var testToAdd = new Test();
            categoryRepositoryMock.Setup(x => x.All).Returns(models.AsQueryable);
            categoryServiceMock.Setup(x => x.GetCategoryId("Category1")).Returns(Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"));
            mapperMock.Setup(x => x.MapTo<Test>(test)).Returns(testToAdd);
            testService.CreateTest(test);
            saverMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
