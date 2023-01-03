using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCUBES.Model
{
    public class Customer 
    {
        [Key]
        public int ID_Customer { get; set; }
        [Required]
        public string LogInCus { get; set; }
        [Required]
        public string PassWordCus { get; set; }
        [Required]
        public string NameCus { get; set; }
        [Required]
        public string FirstNameCus { get; set; }

        public Customer()
        {
        }
        public Customer(string logincus,string passWordCus,string namecus, string firsnamecus)
        {
            LogInCus= logincus;
            PassWordCus= passWordCus;
            NameCus= namecus;  
            FirstNameCus= firsnamecus;
        }
    }
}
