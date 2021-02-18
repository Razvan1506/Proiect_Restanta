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
    public class IndexModel : PageModel
    {
        private readonly Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext _context;

        public IndexModel(Tamba_Razvan_Catalin.Data.Tamba_Razvan_CatalinContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; }
        public DogData DogD { get; set; }
        public int DogID { get; set; }
        public int BreedID { get; set; }

        public async Task OnGetAsync(int? id, int? BreedID)
        {
            DogD = new DogData();

            DogD.Dogs = await _context.Dog
                .Include(b => b.Donor)
                .Include(b => b.DogBreeds)
                .ThenInclude(b => b.Breed)
                .AsNoTracking()
                .OrderBy(b => b.Nume)
                .ToListAsync();

            if (id != null)
            {
                DogID = id.Value;
                Dog dog = DogD.Dogs
                    .Where(i => i.ID == id.Value).Single();
                DogD.Breeds = dog.DogBreeds.Select(s => s.Breed);
            }
        }
    }
}
