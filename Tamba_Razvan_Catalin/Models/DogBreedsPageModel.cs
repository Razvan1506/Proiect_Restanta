using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tamba_Razvan_Catalin.Data;

namespace Tamba_Razvan_Catalin.Models
{
    public class DogBreedsPageModel:PageModel
    {
        public List<AssignedBreedData> AssignedBreedDataList;

        public void PopulateAssignedBredData(Tamba_Razvan_CatalinContext context, Dog dog)
        {
            var allBreeds = context.Breed;
            var dogBreeds = new HashSet<int>(
                dog.DogBreeds.Select(c => c.DogID));
            AssignedBreedDataList = new List<AssignedBreedData>();
            foreach (var cat in allBreeds)
            {
                AssignedBreedDataList.Add(new AssignedBreedData
                {
                    BreedID = cat.ID,
                    Name = cat.BreedName,
                    Assigned = dogBreeds.Contains(cat.ID)
                });
            }
        }

        public void UpdateDogBreeds(Tamba_Razvan_CatalinContext context,
            string[] selectedBreeds, Dog dogToUpdate)
        {
            if (selectedBreeds == null)
            {
                dogToUpdate.DogBreeds = new List<DogBreed>();
                return;
            }

            var selectedBreedsHS = new HashSet<string>(selectedBreeds);
            var dogBreeds = new HashSet<int>
                (dogToUpdate.DogBreeds.Select(c => c.Breed.ID));
            foreach (var cat in context.Breed)
            {
                if (selectedBreedsHS.Contains(cat.ID.ToString()))
                {
                    if (!dogBreeds.Contains(cat.ID))
                    {
                        dogToUpdate.DogBreeds.Add(
                            new DogBreed
                            {
                                DogID = dogToUpdate.ID,
                                BreedID = cat.ID
                            });
                    }
                }
                else
                {
                    if (dogBreeds.Contains(cat.ID))
                    {
                        DogBreed courseToRemove = dogToUpdate
                            .DogBreeds
                            .SingleOrDefault(i => i.BreedID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
