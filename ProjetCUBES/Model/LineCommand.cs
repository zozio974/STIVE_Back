using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCUBES.Model
{
    public class LineCommand
    {
        [Key]
        public int Id_LineCommande { get; set; }

        [Required]
        public int Id_article { get; set; }
        [Required]
        public string Ref_Command { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public LineCommand() { }

        public LineCommand(int id_article,string ref_comand, int quantity, double price)
        {
            Id_article = id_article;
            Ref_Command = ref_comand;
            Quantity = quantity;
            Price = price;
        }
    }
}
