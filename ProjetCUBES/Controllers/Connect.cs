using Bogus;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetCUBES.Model;
using System;
using System.Security.Cryptography;
using WebApi.OutputCache.Core.Time;
using static ProjetCUBES.Helpers.Class;
namespace ProjetCUBES.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Connect
    {
        /// <summary>
        /// Test la connexion d'un client suivant son login et mdp
        /// </summary>
        [HttpGet]
        public bool connectcust(string? username = "", string? password = "")
        {
            using (Apply context = new Apply())
            {
                List<User> listcust = context.Users.Where((x => x.LogInUser == username && x.Idjob ==5)).ToList();
                if (listcust.Any() == false)
                {
                    return false;
                }
                User cust = context.Users.Where((x => x.LogInUser == username)).First();
                if (cust.PassWordUser != password)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Test la connexion d'un employé suivant son login et mdp
        /// </summary>
        [HttpGet]
        public bool connectemp(string? username = "", string? password = "")
        {
            using (Apply context = new Apply())
            {
                List<User> listcust = context.Users.Where((x => x.LogInUser == username && x.Idjob != 5)).ToList();
                if (listcust.Any() == false)
                {
                    return false;
                }
                User cust = context.Users.Where((x => x.LogInUser == username)).First();
                if (cust.PassWordUser != password)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Affiche un utilisateur selon son login
        /// </summary>
        [HttpGet]
        public User getjobbylogin(string name)
        {
            using (Apply context = new Apply())
            {
                User emp = context.Users.Where(x => x.LogInUser == name).First();
                return emp;
            }
        }

    }
}
