using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCUBES.Model
{
    public class Command
    {
        [Key]
        public int Id_Command { get; set; }
        [Required]
        public int RefCommand { get; set; }
        [Required]
        public string Date_Command { get; set; }
        [Required]
        public double Price_Command { get; set; }
        [Required]
        public int Status_Comman { get; set; }

        public int id_customer { get; set; }

        public Command() { }

        public Command(int refcommand, string date_Command, double price_Command, int status_Command)
        {
            RefCommand= refcommand;
            Date_Command = date_Command;
            Price_Command = price_Command;
            Status_Comman = status_Command;
        }

        public Command(int refcommand, string date_Command, double price_Command, int status_Command,int idcustomer)
        {
            RefCommand = refcommand;
            Date_Command = date_Command;
            Price_Command = price_Command;
            Status_Comman = status_Command;
            id_customer = idcustomer;
        }
    }
}
