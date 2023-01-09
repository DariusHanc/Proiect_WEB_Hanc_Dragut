using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Dragut_Hanc.Models;


namespace Proiect_Dragut_Hanc.Data
{
    public class Proiect_Dragut_HancContext : DbContext
    {
        public Proiect_Dragut_HancContext (DbContextOptions<Proiect_Dragut_HancContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Dragut_Hanc.Models.Product> Product { get; set; } = default!;
        public DbSet<Proiect_Dragut_Hanc.Models.Store> Store { get; set; } 
        public DbSet<Proiect_Dragut_Hanc.Models.Admin> Admin { get; set; }
        public DbSet<Proiect_Dragut_Hanc.Models.Buying> Buying { get; set; }
        public DbSet<Proiect_Dragut_Hanc.Models.Category> Category { get; set; }

        public DbSet<Proiect_Dragut_Hanc.Models.Client> Client { get; set; }


    }
}
