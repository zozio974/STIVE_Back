using Bogus;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetCUBES.Model;
using System;
using System.Security.Cryptography;
using System.Diagnostics.CodeAnalysis;
using static ProjetCUBES.Helpers.Class;
namespace ProjetCUBES.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Add
    {   
        /// <summary>
        ///  Ajouter un client dans la table utilisateur
        /// </summary>
       
       
        [HttpPost]
        public void add_customer(string login, string password, string name, string firstname)
        {

            using (Apply context = new Apply())
            {
                User newcust = new User();
                newcust.LogInUser = login;
                newcust.PassWordUser = password;
                newcust.NameUser = name;
                newcust.FirstNameUser = firstname;
                newcust.Idjob = 5;


                context.Add(newcust);
                context.SaveChanges();
            }

        }
        /// <summary>
        ///  Ajouter un client dans la table utilisateur a partir du site
        /// </summary>
        [HttpGet]
        public bool add_customersite(string login, string password, string name, string firstname)
        {

            using (Apply context = new Apply())
            {
                User newcust = new User();
                newcust.LogInUser = login;
                newcust.PassWordUser = password;
                newcust.NameUser = name;
                newcust.FirstNameUser = firstname;
                newcust.Idjob = 5;


                context.Add(newcust);
                context.SaveChanges();
                return true;
            }

        }
        /// <summary>
        ///  Ajouter une nouvelle famille de vin dans la table famille
        /// </summary>
        [HttpPost]
        public void add_family(string name)
        {

            using (Apply context = new Apply())
            {
                Family newfam = new Family();
                newfam.NameFamily=name;
                context.Add(newfam);
                context.SaveChanges();
            }

        }
        /// <summary>
        ///  Ajouter un nouveau fournisseur dans la table fournisseur
        /// </summary>
        [HttpPost]
        public void add_supplier(string name)
        {

            using (Apply context = new Apply())
            {
                Supplier newsup = new Supplier();
                newsup.Name = name;
                context.Add(newsup);
                context.SaveChanges();
            }

        }
        /// <summary>
        ///  Ajouter un employé dans la table utilisateur
        /// </summary>
        [HttpPost]
        public void add_employer(string login, string password, string name, string firstname, int idjob)
        {

            using (Apply context = new Apply())
            {
                User newemp = new User();
                newemp.LogInUser = login;
                newemp.PassWordUser = password;
                newemp.NameUser = name;
                newemp.FirstNameUser = firstname;
                newemp.Idjob = idjob;

                context.Add(newemp);
                context.SaveChanges();
            }
        }
        /// <summary>
        ///  Ajouter une nouvelle fonction dans la table fonction
        /// </summary>
        [HttpPost]
        public void add_job(string name)
        {

            using (Apply context = new Apply())
            {
                Job newjob = new Job();
                newjob.JobName = name;
                context.Add(newjob);
                context.SaveChanges();
            }

        }
        /// <summary>
        ///  Ajouter un article dans la table article
        /// </summary>
        [HttpPost]

        public void add_article(string name, int idprovider,int datefill,int idfamily,double pricesup, double price, int volume,int degree,string grape,string ladder)
        {

            using (Apply context = new Apply())
            {
                Article newart = new Article();
                newart.NameArticle= name;
                newart.IdProvider= idprovider;
                newart.DateFill= datefill;
                newart.IdFamily = idfamily;
                newart.PriceSup=pricesup;
                newart.Price= price;
                newart.Volume= volume;
                newart.Degree= degree;
                newart.Grape= grape;
                newart.Ladder= ladder;
                newart.StockProv = 0;
                newart.StockActual = 0;
                newart.StockMin = 0;
                context.Add(newart);
                context.SaveChanges();
            }
        }


    }
}
