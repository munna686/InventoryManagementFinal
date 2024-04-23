using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(InventoryManagmentContext dbContext) : base(dbContext)
        {

        }
    }
}
