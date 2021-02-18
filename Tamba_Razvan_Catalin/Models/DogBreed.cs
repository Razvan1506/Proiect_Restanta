using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamba_Razvan_Catalin.Models
{
    public class DogBreed
    {
        public int ID { get; set; }

        public int DogID { get; set; }

        public Dog Dog { get; set; }

        public int BreedID { get; set; }

        public Breed Breed { get; set; }
    }
}
