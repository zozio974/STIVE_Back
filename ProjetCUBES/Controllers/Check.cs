using Bogus;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetCUBES.Model;
using System;
using System.Security.Cryptography;
using static ProjetCUBES.Helpers.Class;
namespace ProjetCUBES.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Check
    {
        /// <summary>
        ///  Vérifie si un fournisseur existe par son id
        /// </summary>
        [HttpGet]
        public bool checksupplierexist(int a)
        {
            using (Apply context = new Apply())
            {
                List<Article> listart = context.Articles.Where((x => x.IdProvider == a)).ToList();
                if (listart.Any() == false)
                {
                    return false;
                }             
                return true;
            }

                
        }
        /// <summary>
        ///  Vérifie si une famille existe par son id
        /// </summary>
        [HttpGet]
        public bool checkfamilyexist(int a)
        {
            using (Apply context = new Apply())
            {
                List<Article> listart = context.Articles.Where((x => x.IdFamily == a)).ToList();
                if (listart.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        ///  Vérifie si une fonction existe par son id
        /// </summary>
        [HttpGet]
        public bool checkjobexist(int a)
        {
            using (Apply context = new Apply())
            {
                List<User> listemp = context.Users.Where((x => x.Idjob == a)).ToList();
                if (listemp.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        ///  Vérifie si un article existe par son nom
        /// </summary>
        [HttpGet]

        public bool articlebynameexist(string name)
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.Where(x => x.NameArticle == name).ToList();
                if (article.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        ///  Vérifie si un article a un stock
        /// </summary>
        [HttpGet]

        public bool checkarticlestockexist(int a)
        {
            using (Apply context = new Apply())
            {
               Article article = context.Articles.Where(x => x.ID_Article == a).First();
                if (article.StockProv == 0)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        ///  Vérifie si un client existe par son nom
        /// </summary>
        [HttpGet]

        public bool custbynameexist(string name)
        {
            using (Apply context = new Apply())
            {
                List<User> user = context.Users.Where(x => x.NameUser == name).ToList();
                if (user.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        ///  Vérifie si un client existe par son login
        /// </summary>
        [HttpGet]

        public bool userbyloginexist(string login)
        {
            using (Apply context = new Apply())
            {
                List<User> user = context.Users.Where(x => x.LogInUser == login).ToList();
                if (user.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }/// <summary>
         ///  Vérifie si la commande est archivée ou non
         /// </summary>
        [HttpGet]

        public bool checkstatuscommand(int id)
        {
            using (Apply context = new Apply())
            {
                Command comm = context.Commands.Where(x => x.Id_Command == id).First();
                if (comm.Status_Comman == 2)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        ///  Vérifie si une commande existe par sa référence
        /// </summary>
        [HttpGet]

        public bool checkrefcommand(string refcom)
        {
            using (Apply context = new Apply())
            {
                List<Command> comm = context.Commands.Where(x => x.RefCommand == refcom).ToList();
                if (comm.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
