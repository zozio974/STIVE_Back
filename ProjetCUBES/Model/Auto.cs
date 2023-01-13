using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
namespace ProjetCUBES.Model
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AddToStock { get; set; }
        [Required]
        public int AutoRefill { get; set; }
        public int ID_Auto { get; internal set; }

        public Auto() { }
        public Auto(int addtostock,int autorefill) 
        { 
            AddToStock= addtostock;
            AutoRefill = autorefill;
        }
    }
}
