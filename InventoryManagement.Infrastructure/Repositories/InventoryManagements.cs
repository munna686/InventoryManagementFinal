using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class InventoryManagements:IInventoryManagement
    {
        private readonly InventoryManagmentContext _context;
        public ICategoryRepository Categories {  get; }
        public InventoryManagements(InventoryManagmentContext context,
                                ICategoryRepository categories)
        {
            _context = context;
            Categories = categories;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
