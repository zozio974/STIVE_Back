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
    public class Add
    {
        [HttpPost]
        public void add_customer(string login, string password, string name, string firstname)
        {

            using (Apply context = new Apply())
            {
                Customer newcust = new Customer();
                newcust.LogInCus = login;
                newcust.PassWordCus = password;
                newcust.NameCus = name;
                newcust.FirstNameCus = firstname;


                context.Add(newcust);
                context.SaveChanges();
            }

        }
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
        [HttpPost]
        public void add_employer(string login, string password, string name, string firstname, int idjob)
        {

            using (Apply context = new Apply())
            {
                Employer newemp = new Employer();
                newemp.LogInEmp = login;
                newemp.PassWordEmp = password;
                newemp.NameEmp = name;
                newemp.FirstNameEmp = firstname;
                newemp.Idjob = idjob;

                context.Add(newemp);
                context.SaveChanges();
            }
        }
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
                newart.StockMin = 10;
                context.Add(newart);
                context.SaveChanges();
            }
        }


    }
}
