using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamba_Razvan_Catalin.Models
{
    public class Dog
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name ="Dog Name")]
        public string Nume { get; set; }
        public string Sex { get; set; }

        [Range(0, 15)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Varsta { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        public int DonorID { get; set; }

        public Donor Donor { get; set; }

        public ICollection<DogBreed> DogBreeds { get; set; }
    }
}
