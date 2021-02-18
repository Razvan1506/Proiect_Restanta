using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamba_Razvan_Catalin.Models
{
    public class DogData
    {
        public IEnumerable<Dog> Dogs { get; set; }
        public IEnumerable<Breed> Breeds { get; set; }
        public IEnumerable<DogBreed> DogBreeds { get; set; }
    }
}
