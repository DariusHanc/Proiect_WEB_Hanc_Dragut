using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Dragut_Hanc.Data;
using Proiect_Dragut_Hanc.Models;
using Proiect_Dragut_Hanc.Models.ViewModels;

namespace Proiect_Dragut_Hanc.Pages.Stores
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext _context;

        public IndexModel(Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext context)
        {
            _context = context;
        }

        public IList<Store> Store { get; set; } = default!;

        public StoreIndexData StoreData { get; set; }
        public int StorID { get; set; }
        public int ProdID { get; set; }
        public async Task OnGetAsync(int? id, int? productID)
        {

            StoreData = new StoreIndexData();
            StoreData.Store = await _context.Store
            .Include(i => i.Products)
            .ThenInclude(c => c.Admin)
            .OrderBy(i => i.StoreName)
            .ToListAsync();
            if (id != null)
            {
                StorID = id.Value;
                Store store = StoreData.Store
                .Where(i => i.StoreID == id.Value).Single();
                StoreData.Products = store.Products;
            }
        }
    }
}