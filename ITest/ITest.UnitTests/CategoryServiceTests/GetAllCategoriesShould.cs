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
    public class GetAllCategoriesShould
    {
        [TestMethod]
        public void ReturnsCorrectNumberOfCategories()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();

            var categoryService = new CategoryService(categoriesRepositoryMock.Object, saverMock.Object, mapperMock.Object);

            var models = new List<Category>()
            {
                new Category{Id = Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"), Name = "Category1"},
                new Category{Id = Guid.Parse("d987165b-3278-42d1-9918-834556989282"), Name = "Category2"},
                new Category{Id = Guid.Parse("bb01cb4c-b260-45c7-9f43-4abc3338e211"), Name = "Category3"}
            };

            categoriesRepositoryMock.Setup(x => x.All).Returns(models.AsQueryable);

            var DTOs = new List<CategoryDTO>()
            {
                new CategoryDTO{ Name = "Category1"},
                new CategoryDTO{ Name = "Category2"},
                new CategoryDTO{ Name = "Category3"}
            };

            mapperMock.Setup(m => m.ProjectTo<CategoryDTO>(It.IsAny<IQueryable<Category>>())).Returns(new List<CategoryDTO>(DTOs).AsQueryable);

            var collection = categoryService.GetAllCategories();

            Assert.AreEqual(models.Count, collection.Count());
            Assert.IsInstanceOfType(collection, typeof(IQueryable<CategoryDTO>));
        }

        [TestMethod]
        public void ReturnsInstaneOfIQueryableOfCategoryDTO()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var categoriesRepositoryMock = new Mock<IRepository<Category>>();

            var categoryService = new CategoryService(categoriesRepositoryMock.Object, saverMock.Object,
                mapperMock.Object);

            var models = new List<Category>()
            {
                new Category {Id = Guid.Parse("c29e29c6-c29a-4cca-81e0-17102bd13a7c"), Name = "Category1"},
                new Category {Id = Guid.Parse("d987165b-3278-42d1-9918-834556989282"), Name = "Category2"},
                new Category {Id = Guid.Parse("bb01cb4c-b260-45c7-9f43-4abc3338e211"), Name = "Category3"}
            };

            categoriesRepositoryMock.Setup(x => x.All).Returns(models.AsQueryable);

            var DTOs = new List<CategoryDTO>()
            {
                new CategoryDTO {Name = "Category1"},
                new CategoryDTO {Name = "Category2"},
                new CategoryDTO {Name = "Category3"}
            };

            mapperMock.Setup(m => m.ProjectTo<CategoryDTO>(It.IsAny<IQueryable<Category>>()))
                .Returns(new List<CategoryDTO>(DTOs).AsQueryable);

            var collection = categoryService.GetAllCategories();

            Assert.IsInstanceOfType(collection, typeof(IQueryable<CategoryDTO>));
        }

    }
}
