﻿using DataAccess.Entities;

namespace ShopMVC.Models
{
    public class ProductCartViewModel
    {
        public Product Product { get; set; }
        public bool IsInCart { get; set; }
    }
}
