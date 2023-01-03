
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCUBES.Model
{
    public class Family
    {
        [Key]
        public int ID_Family { get; set; }

        [Required]
        public string NameFamily { get; set; }

        public Family() { }
        public Family(string namefamily)
        { 
            NameFamily = namefamily;
        }

    }
}
