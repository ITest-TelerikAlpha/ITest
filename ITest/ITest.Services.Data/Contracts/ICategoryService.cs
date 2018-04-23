using ITest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITest.Services.Data.Contracts
{
    public interface ICategoryService
    {
        IQueryable<CategoryDTO> GetAllCategories();
    }
}
