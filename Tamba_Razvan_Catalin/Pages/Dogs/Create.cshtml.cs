using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tamba_Razvan_Catalin.Data;
using Tamba_Razvan_Catalin.Models;

namespace Tamba_Razvan_Catalin.Pages.Dogs
{
    public class CreateModel : DogBreedsPageModel
    {
        private readonly Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext _context;

        public CreateModel(Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DonorID"] = new SelectList(_context.Set<Donor>(), "ID", "DonorName");

                var dog = new Dog();
            dog.DogBreeds = new List<DogBreed>();

            PopulateAssignedBredData(_context, dog);

            return Page();
        }

        [BindProperty]
        public Dog Dog { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedBreeds)
        {
            var newDog = new Dog();
            if (selectedBreeds != null)
            {
                newDog.DogBreeds = new List<DogBreed>();
                foreach (var cat in selectedBreeds)
                {
                    var catToAdd = new DogBreed
                    {
                        BreedID = int.Parse(cat)
                    };
                    newDog.DogBreeds.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync<Dog>(
                newDog,
                "Dog",
                i => i.Nume, i => i.Sex,
                i => i.Varsta, i => i.CheckInDate, i => i.DonorID))
            {
                _context.Dog.Add(newDog);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedBredData(_context, newDog);
            return Page();
        }
    }
}
