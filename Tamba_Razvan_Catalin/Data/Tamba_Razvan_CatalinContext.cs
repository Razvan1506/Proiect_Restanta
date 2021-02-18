using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tamba_Razvan_Catalin.Models;

namespace Tamba_Razvan_Catalin.Data
{
    public class Tamba_Razvan_CatalinContext : DbContext
    {
        public Tamba_Razvan_CatalinContext (DbContextOptions<Tamba_Razvan_CatalinContext> options)
            : base(options)
        {
        }

        public DbSet<Tamba_Razvan_Catalin.Models.Dog> Dog { get; set; }

        public DbSet<Tamba_Razvan_Catalin.Models.Donor> Donor { get; set; }

        public DbSet<Tamba_Razvan_Catalin.Models.Breed> Breed { get; set; }
    }
}
