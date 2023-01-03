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


    public class PutTable
    {
        [HttpPut]
        public void putcustomer(int ID,string? login = "", string? password = "", string? name = "", string? firstname = "")
        {
            using (Apply context = new Apply())
            {
                if (login != "")
                {
                    Customer cust = context.Customers.Where(x => x.ID_Customer == ID).First();
                    cust.LogInCus = login;
                    context.Update(cust);
                    context.SaveChanges();

                }
                if (password != "")
                {
                    Customer cust = context.Customers.Where(x => x.ID_Customer == ID).First();
                    cust.PassWordCus = password;
                    context.Update(cust);
                    context.SaveChanges();

                }
                if (name != "")
                {
                    Customer cust = context.Customers.Where(x => x.ID_Customer == ID).First();
                    cust.NameCus = name;
                    context.Update(cust);
                    context.SaveChanges();

                }
                if (firstname != "")
                {
                    Customer cust = context.Customers.Where(x => x.ID_Customer == ID).First();
                    cust.FirstNameCus = firstname;
                    context.Update(cust);
                    context.SaveChanges();

                }


            }

        }
        [HttpPut]
        public void putemployer(int ID, string? idjob="",string? login = "", string? password = "", string? name = "", string? firstname = "")
        {
            using (Apply context = new Apply())
            {
                if (login != "")
                {
                    Employer emp = context.Employers.Where(x => x.ID_Employer == ID).First();
                    emp.LogInEmp = login;
                    context.Update(emp);
                    context.SaveChanges();

                }
                if (idjob != "")
                {
                    Employer emp = context.Employers.Where(x => x.ID_Employer == ID).First();
                    emp.Idjob = Convert.ToInt32(idjob);
                    context.Update(emp);
                    context.SaveChanges();

                }
                if (password != "")
                {
                    Employer emp = context.Employers.Where(x => x.ID_Employer == ID).First();
                    emp.PassWordEmp = password;
                    context.Update(emp);
                    context.SaveChanges();

                }
                if (name != "")
                {
                    Employer emp = context.Employers.Where(x => x.ID_Employer == ID).First();
                    emp.NameEmp = name;
                    context.Update(emp);
                    context.SaveChanges();

                }
                if (firstname != "")
                {
                    Employer emp = context.Employers.Where(x => x.ID_Employer == ID).First();
                    emp.FirstNameEmp = firstname;
                    context.Update(emp);
                    context.SaveChanges();
                }


            }

        }
        [HttpPut]
        public void putfamily(int ID,string? name = "")
        {
            using (Apply context = new Apply())
            {
                if (name != "")
                {
                    Family fam = context.Familys.Where(x => x.ID_Family == ID).First();
                    fam.NameFamily = name;
                    context.Update(fam);
                    context.SaveChanges();

                }
                

            }

        }
        [HttpPut]
        public void putsupplier(int ID, string? name = "")
        {
            using (Apply context = new Apply())
            {
                if (name != "")
                {
                    Supplier fam = context.Suppliers.Where(x => x.Id == ID).First();
                    fam.Name = name;
                    context.Update(fam);
                    context.SaveChanges();
                }
            }
        }
        [HttpPut]
        public void putjob(int ID, string? name = "")
        {
            using (Apply context = new Apply())
            {
                if (name != "")
                {
                    
                    Job job = context.Jobs.Where(x => x.ID_Job == ID).First();
                    job.JobName = name;
                    context.Update(job);
                    context.SaveChanges();
                }
            }
        }
        [HttpPut]
        public void putarticle(int ID, string? name = "", string? idsup = "", string? datefill = "", string? idfamily = "",
            string? pricesup = "", string? price = "", string? volume = "", string? degree = "", string? grape = "", string? ladder = "")
        {
            using (Apply context = new Apply())
            {
                if (name != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.NameArticle = name;
                    context.Update(art);
                    context.SaveChanges();

                }
                if (idsup != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.IdProvider = Convert.ToInt32(idsup);
                    context.Update(art);
                    context.SaveChanges();

                }
                if (datefill != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.DateFill = Convert.ToInt32(datefill);
                    context.Update(art);
                    context.SaveChanges();

                }
                if (idfamily != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.IdFamily = Convert.ToInt32(idfamily);
                    context.Update(art);
                    context.SaveChanges();

                }
                if (pricesup != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.PriceSup = Convert.ToDouble(pricesup);
                    context.Update(art);
                    context.SaveChanges();

                }
                if (price != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.Price = Convert.ToDouble(price);
                    context.Update(art);
                    context.SaveChanges();

                }
                if (volume != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.Volume = Convert.ToInt32(volume);
                    context.Update(art);
                    context.SaveChanges();

                }
                if (degree != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.Degree = Convert.ToInt32(degree);
                    context.Update(art);
                    context.SaveChanges();
                }
                if (grape != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.Grape = grape;
                    context.Update(art);
                    context.SaveChanges();

                }
                if (ladder != "")
                {
                    Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                    art.Ladder = ladder;
                    context.Update(art);
                    context.SaveChanges();

                }



            }

        }
    }
}
