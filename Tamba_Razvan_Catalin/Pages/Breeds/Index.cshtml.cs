using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tamba_Razvan_Catalin.Data;
using Tamba_Razvan_Catalin.Models;

namespace Tamba_Razvan_Catalin.Pages.Breeds
{
    public class IndexModel : PageModel
    {
        private readonly Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext _context;

        public IndexModel(Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext context)
        {
            _context = context;
        }

        public IList<Breed> Breed { get;set; }

        public async Task OnGetAsync()
        {
            Breed = await _context.Breed.ToListAsync();
        }
    }
}
