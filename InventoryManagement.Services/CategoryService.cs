using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Models;
using InventoryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class CategoryService : ICategoryService
    {
        public IInventoryManagement _inventory;
        public CategoryService(IInventoryManagement inventory)
        {
            _inventory = inventory;
        }

        public async Task<bool> CreateCategory(Category category)
        {
            if(category != null)
            {
                await _inventory.Categories.Add(category);
                var result = _inventory.Save();
                if(result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            if(id > 0)
            {
                var category =  await _inventory.Categories.GetById(id);
                if(category != null)
                {
                    _inventory.Categories.Delete(category);
                    var result = _inventory.Save();
                    if(result > 0) 
                        return true;
                    else
                        return false;
                }
            }
            return false ;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
             var category = await _inventory.Categories.GetAll();
            return category;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            if(id > 0)
            {
                var category = await _inventory.Categories.GetById(id);
                if(category != null)
                {
                    return category;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            if(category != null)
            {
                var categorys = await _inventory.Categories.GetById(category.CategoryId);
                if(categorys != null)
                {
                    categorys.CategoryName = category.CategoryName;
                    categorys.Description = category.Description;

                    _inventory.Categories.Update(categorys);
                    var result = _inventory.Save();
                    if(result > 0) 
                        return true;
                    else 
                        return false;
                }
            }
            return false;
        }
    }
}
