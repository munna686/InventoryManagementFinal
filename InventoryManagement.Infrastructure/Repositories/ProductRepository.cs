using InventoryManagement.Core.Models;
using InventoryManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ProductRepository:GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(InventoryManagmentContext dbContext) : base(dbContext) { }
    }
}
