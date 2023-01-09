using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Dragut_Hanc.Data;
using Proiect_Dragut_Hanc.Models;

namespace Proiect_Dragut_Hanc.Pages.Buyings
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext _context;

        public IndexModel(Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext context)
        {
            _context = context;
        }

        public IList<Buying> Buying { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Buying != null)
            {
                Buying = await _context.Buying
                .Include(b => b.Client)
                .Include(b => b.Product).ToListAsync();
            }
        }
    }
}