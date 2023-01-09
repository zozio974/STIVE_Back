using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetCUBES.Model
{
    public class User
    {
        [Key]
        public int ID_User { get; set; }
        [Required]
        public string LogInUser { get; set; }
        [Required]
        public string PassWordUser{ get; set; }
        [Required]
        public string NameUser { get; set; }
        [Required]
        public string FirstNameUser { get; set; }
        [Required]
        public int Idjob { get; set; }

        public User() { }

        public User(string loginuser, string passworduser, string nameuser, string firstnameuser, int idjob)
        {
            LogInUser = loginuser;
            PassWordUser = passworduser;
            NameUser = nameuser;
            FirstNameUser = firstnameuser;
            Idjob = idjob;


        }
    }
}
