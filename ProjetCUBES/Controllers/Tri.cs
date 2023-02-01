using Bogus;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetCUBES.Model;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using static ProjetCUBES.Helpers.Class;
namespace ProjetCUBES.Controllers
{


    [ApiController]
    [Route("[controller]/[action]")]

    public class Tri
    {

        /// <summary>
        /// Affiche tout les articles qui ont l'id d'une famille
        /// </summary>
        [HttpGet]
        public List<Article> displayarticlebyfamily(int ID)
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.Where(x => x.IdFamily == ID).ToList();
                return article;
            }
        }
        /// <summary>
        /// Affiche tout les articles qui ont l'id d'un fournisseur
        /// </summary>
        [HttpGet]

        public List<Article> displayarticlebySupplier(int ID)
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.Where(x => x.IdProvider == ID).ToList();
                return article;
            }
        }
        /// <summary>
        /// Affiche tout les articles qui ont l'id d'une famille et l'id d'un fournisseur
        /// </summary>
        [HttpGet]

        public List<Article> displayarticlebySupFam(int idsup,int idfam)
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.Where(x => x.IdProvider == idsup &&  x.IdFamily ==idfam).ToList();
                return article;
            }
        }
        /// <summary>
        /// Affiche tout les clients qui ont un nom donné
        /// </summary>
        [HttpGet]

        public List<User> displaycustbyname(string name)
        {
            using (Apply context = new Apply())
            {
                List<User> user = context.Users.Where(x => x.NameUser == name).ToList();
                return user;
            }
        }
    }
}
