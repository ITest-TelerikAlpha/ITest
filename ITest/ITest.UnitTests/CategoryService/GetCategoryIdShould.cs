using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Services.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ITest.UnitTests.CategoryServiceTests
{
    [TestClass]
    public class GetCategoryIdShould
    {
        [TestMethod]
        public void ReturnFalse_WhenTheCategoryExists()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();

            var categoryService = new CategoryService(categoriesRepositoryMock.Object, saverMock.Object,
                mapperMock.Object);

            var models = new List<Category>()
            {
                new Category {Id = Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"), Name = "Category1"}
            };

            categoriesRepositoryMock.Setup(x => x.All).Returns(models.AsQueryable);

            var DTOs = new List<CategoryDTO>()
            {
                new CategoryDTO {Name = "Category1"}
            };

            mapperMock.Setup(m => m.ProjectTo<CategoryDTO>(It.IsAny<IQueryable<Category>>()))
                .Returns(new List<CategoryDTO>(DTOs).AsQueryable);

            var categorId = categoryService.GetCategoryId("Category1");

            Assert.AreEqual(Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"), categorId);
        }
    }
}
