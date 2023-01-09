using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Dragut_Hanc.Data;
using Proiect_Dragut_Hanc.Models;
using Microsoft.AspNetCore.Authorization;

namespace Proiect_Dragut_Hanc.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {

        public ProductCategoriesPM categorie = new ProductCategoriesPM();
        private readonly Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext _context;

        public CreateModel(Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StoreID"] = new SelectList(_context.Store, "StoreID", "StoreID");
            ViewData["Admin"] = new SelectList(_context.Set<Admin>(), "Admin", "Admin");

            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            categorie.PopulateAssignedCategoryData(_context, product);

            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProduct = Product;
            if (selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }
            
            _context.Product.Add(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
            categorie.PopulateAssignedCategoryData(_context, newProduct);
            return Page();
        }
    }
}