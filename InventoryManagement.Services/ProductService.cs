using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Models;
using InventoryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class ProductService : IProductService
    {
        public IInventoryManagement _inventory;
        public ProductService(IInventoryManagement inventory)
        {
            _inventory = inventory;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            if(product != null)
            {
                await _inventory.Products.Add(product);
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

        public async Task<bool> DeleteProduct(int id)
        {
            if(id > 0)
            {
                var product = await _inventory.Products.GetById(id);
                if(product != null)
                {
                    _inventory.Products.Delete(product); 
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
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _inventory.Products.GetAll();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            if(id > 0)
            {
                var product = await _inventory.Products.GetById(id);
                if(product != null)
                {
                    return product;
                }
            }
            return null;
        }

        //public async Task<bool> UpdateProduct(Product product)
        //{
        //    if(product != null)
        //    {
        //        var prod = await _inventory.Products.GetById(product.ProductId); 
        //        if(prod != null)
        //        {
        //            prod.ProductName = product.ProductName;
        //            prod.CategoryId = product.CategoryId;
        //            prod.Price = product.Price;
        //            prod.Description = product.Description;
        //            prod.Quantity = prod.Quantity;

        //        }
        //    }
        //}
    }
}
