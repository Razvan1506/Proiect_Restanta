using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tamba_Razvan_Catalin.Data;
using Tamba_Razvan_Catalin.Models;

namespace Tamba_Razvan_Catalin.Pages.Breeds
{
    public class CreateModel : PageModel
    {
        private readonly Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext _context;

        public CreateModel(Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Breed Breed { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Breed.Add(Breed);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
