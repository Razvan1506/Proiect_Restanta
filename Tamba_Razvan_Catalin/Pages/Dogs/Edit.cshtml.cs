using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tamba_Razvan_Catalin.Data;
using Tamba_Razvan_Catalin.Models;

namespace Tamba_Razvan_Catalin.Pages.Dogs
{
    public class EditModel : DogBreedsPageModel
    {
        private readonly Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext _context;

        public EditModel(Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext context)
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

            Dog = await _context.Dog
                .Include(b => b.Donor)
                .Include(b => b.DogBreeds).ThenInclude(b => b.Breed)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Dog == null)
            {
                return NotFound();
            }

            PopulateAssignedBredData(_context, Dog);
            ViewData["DonorID"] = new SelectList(_context.Set<Donor>(), "ID", "DonorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedBreeds)
        {
            if (id == null)
                {
                return NotFound();
            }

            var dogToUpdate = await _context.Dog
                .Include(i => i.Donor)
                .Include(i => i.DogBreeds).ThenInclude(i => i.Breed)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (dogToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Dog>(
                dogToUpdate,
                "Dog",
                i => i.Nume, i => i.Sex,
                i => i.Varsta, i => i.CheckInDate, i => i.Donor ))
            {
                UpdateDogBreeds(_context, selectedBreeds, dogToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateDogBreeds(_context, selectedBreeds, dogToUpdate);
            PopulateAssignedBredData(_context, dogToUpdate);
            return Page();
        }

        private bool DogExists(int id)
        {
            return _context.Dog.Any(e => e.ID == id);
        }
    }
}
