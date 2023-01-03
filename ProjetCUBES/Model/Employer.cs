
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCUBES.Model
{
    
    public class Employer
    {
        [Key]
        public int ID_Employer { get; set; }
        [Required]
        public string LogInEmp { get; set; }
        [Required]
        public string PassWordEmp { get; set; }
        [Required]
        public string NameEmp { get; set; }
        [Required]
        public string FirstNameEmp { get; set; }
        [Required]
        public int Idjob { get; set; }

        public Employer() { }

        public Employer(string loginemp, string passwordemp, string nameemp, string firstname , int idjob)
        {
            LogInEmp= loginemp;
            PassWordEmp= passwordemp;
            NameEmp= nameemp;
            FirstNameEmp = firstname;
            Idjob = idjob;


        }


    }
}
