﻿using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interfaces
{
    public interface IProductRepository:IGenericRepository<Product>
    {
    }
}
