﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interfaces
{
    public interface IInventoryManagement : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        int Save();
    }
}
