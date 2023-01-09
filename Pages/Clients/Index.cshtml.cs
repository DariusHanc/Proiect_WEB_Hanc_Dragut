using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Dragut_Hanc.Data;
using Proiect_Dragut_Hanc.Models;

namespace Proiect_Dragut_Hanc.Pages.Clients
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext _context;

        public IndexModel(Proiect_Dragut_Hanc.Data.Proiect_Dragut_HancContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Client != null)
            {
                Client = await _context.Client.ToListAsync();
            }
        }
    }
}
