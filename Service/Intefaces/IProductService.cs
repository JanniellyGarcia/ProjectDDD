﻿using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Intefaces
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }
}
