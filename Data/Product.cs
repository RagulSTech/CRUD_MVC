﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDOperationMVC.Data
{
    public class Product
    {
        public int ProductId { get; set; }  
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}