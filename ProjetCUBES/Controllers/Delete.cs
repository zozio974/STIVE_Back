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
    public class Delete
    {
        [HttpDelete]
        public void delete_cust(int ID)
        {
            using (Apply context = new Apply())
            {
                Customer cust = context.Customers.Where(x => x.ID_Customer == ID).First();
                context.Remove(cust);
                context.SaveChanges();
            }
        }
        [HttpDelete]
        public void delete_emp(int ID)
        {
            using (Apply context = new Apply())
            {
                Employer emp = context.Employers.Where(x => x.ID_Employer == ID).First();
                context.Remove(emp);
                context.SaveChanges();
            }
        }
        [HttpDelete]
        public void delete_family(int ID)
        {
            using (Apply context = new Apply())
            {
                Family fami = context.Familys.Where(x => x.ID_Family == ID).First();
                context.Remove(fami);
                context.SaveChanges();
            }
        }
        [HttpDelete]
        public void delete_article(int ID)
        {
            using (Apply context = new Apply())
            {
                Article arti = context.Articles.Where(x => x.ID_Article == ID).First();
                context.Remove(arti);
                context.SaveChanges();
            }
        }
        [HttpDelete]
        public void delete_sup(int ID)
        {
            using (Apply context = new Apply())
            {
                Supplier sup = context.Suppliers.Where(x => x.Id == ID).First();
                context.Remove(sup);
                context.SaveChanges();
            }
        }
        [HttpDelete]
        public void delete_job(int ID)
        {
            using (Apply context = new Apply())
            {
                Job job = context.Jobs.Where(x => x.ID_Job == ID).First();
                context.Remove(job);
                context.SaveChanges();
            }
        }
    }
}

