using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITest.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoriesRepository;
        private readonly ISaver saver;
        private readonly IMappingProvider mapper;
        public CategoryService(IRepository<Category> categoriesRepository, ISaver saver, IMappingProvider mapper)
        {
            this.categoriesRepository = categoriesRepository;
            this.saver = saver;
            this.mapper = mapper;
        }

        public IQueryable<CategoryDTO> GetAllCategories()
        {
            var categories = this.mapper.ProjectTo<CategoryDTO>(this.categoriesRepository.All.Where(x => x.IsDeleted == false));
            return categories;
        }

        public bool CheckIfCategoryExists(string categoryName)
        {
            var category = this.categoriesRepository.All.FirstOrDefault(x => x.Name == categoryName);

            if (category == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string GetCategoryId(string categoryName)
        {
            return this.categoriesRepository.All.FirstOrDefault(x => x.Name == categoryName).Id.ToString();
        }
     }
}
