using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Dragut_Hanc.Data;
using Proiect_Dragut_Hanc.Models;

namespace Proiect_Dragut_Hanc.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext _context;

        public IndexModel(Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }

        public ProductDta ProductD { get; set; }
        public int ProdID { get; set; }
        public int CategoryID { get; set; }

        public string NameSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            ProductD = new ProductDta();
            NameSort = String.IsNullOrEmpty(sortOrder) ? "prod_desc" : "";
            PriceSort = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            CurrentFilter = searchString;

            ProductD.Products = await _context.Product
            .Include(b => b.Store)
            .Include(b => b.ProductCategories)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ProductD.Products = ProductD.Products.Where(s => s.Name.Contains(searchString)
               || s.Description.Contains(searchString)); 
            }

            if (id != null)
            {
                ProdID = id.Value;
                Product product = ProductD.Products
                .Where(i => i.ProductID == id.Value).Single();
                ProductD.Categories = product.ProductCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "prod_desc":
                    ProductD.Products = ProductD.Products.OrderByDescending(s =>
                   s.Name);
                    break;
                case "price_desc":
                    ProductD.Products = ProductD.Products.OrderByDescending(s =>
                   s.Price);
               
                    break;
            }

        }
    }
}