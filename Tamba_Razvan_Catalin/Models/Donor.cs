using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamba_Razvan_Catalin.Models
{
    public class Donor
    {
        public int ID { get; set; }
        public string DonorName { get; set; }
        public ICollection<Dog> Dogs { get; set; }
    }
}
