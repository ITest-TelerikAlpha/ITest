using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using ITest.Services.Data.Contracts;
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
            var categories = this.mapper.ProjectTo<CategoryDTO>(this.categoriesRepository.All);
            return categories;
        }
     }
}
