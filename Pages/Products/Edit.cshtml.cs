using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Dragut_Hanc.Data;
using Proiect_Dragut_Hanc.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Policy;

namespace Proiect_Dragut_Hanc.Pages.Products
{
   
   [Authorize(Roles = "Admin")]
   
    public class EditModel : ProductCategoriesPM
    {
        private readonly Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext _context;

        public EditModel(Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                .Include(i => i.Store)
                .Include(i => i.Admin)
                .Include(i => i.ProductCategories)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductID == id);

            var product = await _context.Product.FirstOrDefaultAsync(m => m.ProductID == id);
            if (Product == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Product);

            Product = product;
            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "StoreName");
            ViewData["Category"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");
            


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productToUpdate = await _context.Product
            .Include(i => i.Store)
            .Include(i => i.Admin)
            .Include(i => i.ProductCategories)
            .FirstOrDefaultAsync(s => s.ProductID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Product>(
                 productToUpdate,
                 "Product",
                 i => i.Name, i => i.Description, i => i.Category, i => i.Price, i => i.AvailabilityDate))
            {
                UpdateProductCategories(_context, selectedCategories, productToUpdate);
                // Update other properties of the Product model
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            UpdateProductCategories(_context, selectedCategories, productToUpdate);

            PopulateAssignedCategoryData(_context, productToUpdate);
            return Page();
        }
    }
}