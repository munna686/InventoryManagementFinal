using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> CreateCategory(Category category);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<bool> UpdateCategory (Category category);
        Task<bool> DeleteCategory(int id);
    }
}
