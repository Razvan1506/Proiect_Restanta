using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamba_Razvan_Catalin.Models
{
    public class Breed
    {
        public int ID { get; set; }
        public string BreedName { get; set; }
        public ICollection<DogBreed> DogBreeds { get; set; }
    }
}
