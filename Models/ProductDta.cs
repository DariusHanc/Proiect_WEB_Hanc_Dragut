﻿namespace Proiect_Dragut_Hanc.Models
{
    public class ProductDta
    {
        public IEnumerable<Product> Products { get; set;}
        public IEnumerable<Category> Categories { get; set;}
        public IEnumerable<ProductCategory> ProductCategories { get; set;}

    }
}
