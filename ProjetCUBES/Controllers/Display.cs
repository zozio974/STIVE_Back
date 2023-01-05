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
    public class Display
    {
        [HttpGet]
        public List<Article> displayarticle()
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.ToList();
                return article;
            }
        }
        [HttpGet]
        public Article displayarticlebyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                return art;
            }

        }
        [HttpGet]
        
        public List<Article> displayarticlebyname(string name)
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.Where(x => x.NameArticle == name).ToList();
                return article;
            }

        }
        [HttpGet]

        public List<Customer> displaycustomers()
        {
            using (Apply context = new Apply())
            {
                List<Customer> customer = context.Customers.ToList();
                return customer;
            }
        }
        [HttpGet]
        public Customer displaycustomersbyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Customer cust = context.Customers.Where(x => x.ID_Customer == ID).First();
                return cust;
            }

        }
        [HttpGet]
        public List<Employer> displayemployer()
        {
            using (Apply context = new Apply())
            {
                List<Employer> employer = context.Employers.ToList();
                return employer;
            }
        }
        [HttpGet]
        public Employer displayemployersbyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Employer emp = context.Employers.Where(x => x.ID_Employer == ID).First();
                return emp;
            }

        }
        [HttpGet]
        public List<Family> displayfamily()
        {
            using (Apply context = new Apply())
            {
                List<Family> family = context.Familys.ToList();
                return family;
            }
        }
        [HttpGet]
        public Family displayfamilybyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Family fam = context.Familys.Where(x => x.ID_Family == ID).First();
                return fam;
            }

        }
        
        [HttpGet]
        public List<Stock> displaystock()
        {
            using (Apply context = new Apply())
            {
                List<Stock> stock = context.Stocks.ToList();
                return stock;
            }
        }
        [HttpGet]
        public List<Stock> displaystockbyidart(int id)
        {
            using (Apply context = new Apply())
            {
                List<Stock> stock = context.Stocks.Where(x => x.StockActual ==id).ToList();
                return stock;
            }

        }
        [HttpGet]
        public List<Job> displayjob()
        {
            using (Apply context = new Apply())
            {
                List<Job> job = context.Jobs.ToList();
                return job;
            }
        }
        [HttpGet]
        public Job displayjobbyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Job job = context.Jobs.Where(x => x.ID_Job == ID).First();
                return job;
            }

        }
        [HttpGet]
        public List<Supplier> displaysup()
        {
            using (Apply context = new Apply())
            {
                List<Supplier> sup = context.Suppliers.ToList();
                return sup;
            }
        }
        [HttpGet]
        public Supplier displaysupbyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Supplier sup = context.Suppliers.Where(x => x.Id == ID).First();
                return sup;
            }

        }
        [HttpGet]
        public string getidfamily(string name)
        {
            using (Apply context = new Apply())
            {
                Family fam = context.Familys.Where(x => x.NameFamily== name).First();
                return fam.ID_Family.ToString();
            }
        }
        [HttpGet]
        public string getidjob(string name)
        {
            using (Apply context = new Apply())
            {
                Job job = context.Jobs.Where(x => x.JobName == name).First();
                return job.ID_Job.ToString();
            }
        }
        [HttpGet]
        public string getidsupplier(string name)
        {
            using (Apply context = new Apply())
            {
                Supplier sup = context.Suppliers.Where(x => x.Name == name).First();
                return sup.Id.ToString();
            }
        }
        [HttpGet]
        public string getnamefamily(int id)
        {
            using (Apply context = new Apply())
            {
                Family fam = context.Familys.Where(x => x.ID_Family == id).First();
                return fam.NameFamily.ToString();
            }
        }
        [HttpGet]
        public string getnamesupplier(int id)
        {
            using (Apply context = new Apply())
            {
                Supplier sup = context.Suppliers.Where(x => x.Id == id).First();
                return sup.Name.ToString();
            }
        }
        [HttpGet]
        public string getnamejob(int id)
        {
            using (Apply context = new Apply())
            {
                Job job = context.Jobs.Where(x => x.ID_Job == id).First();
                return job.JobName.ToString();
            }
        }
        [HttpGet]
        public List<string> getlistnamesup([FromQuery] int[] listOfIds)
        {
            using (Apply context = new Apply())
            {
                List<string> list1 = new List<string>();
                foreach (int s in listOfIds)
                {
                    list1.Add(getnamesupplier(s).ToString());
                }
                return list1;
            }
        }
        [HttpGet]
        public List<string> getlistnamefam([FromQuery] int[] listOfIds)
        {
            using (Apply context = new Apply())
            {
                List<string> list1 = new List<string>();
                foreach (int s in listOfIds)
                {
                    list1.Add(getnamefamily(s).ToString());
                }
                return list1;
            }
        }
        [HttpGet]
        public List<string> getlistnamejob([FromQuery] int[] listOfIds)
        {
            using (Apply context = new Apply())
            {
                List<string> list1 = new List<string>();
                foreach (int s in listOfIds)
                {
                    list1.Add(getnamejob(s).ToString());
                }
                return list1;
            }
        }
        [HttpGet]
        public List<Article> getlistarticleinstock([FromQuery] int[] listOfIds)
        {
            using (Apply context = new Apply())
            {
                List<Article> list1 = new List<Article>();
                foreach (int s in listOfIds)
                {
                    list1.Add(displayarticlebyid(s));
                }
                return list1;
            }
        }




    }
}
