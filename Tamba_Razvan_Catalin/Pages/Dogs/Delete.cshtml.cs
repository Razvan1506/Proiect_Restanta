using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tamba_Razvan_Catalin.Data;
using Tamba_Razvan_Catalin.Models;

namespace Tamba_Razvan_Catalin.Pages.Dogs
{
    public class DeleteModel : PageModel
    {
        private readonly Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext _context;

        public DeleteModel(Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dog.FirstOrDefaultAsync(m => m.ID == id);

            if (Dog == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dog.FindAsync(id);

            if (Dog != null)
            {
                _context.Dog.Remove(Dog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
