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
        /// <summary>
        /// Modifie une ou plusieurs valeur d'un client en fonction de son id
        /// </summary>
        [HttpPut]
        public void putcustomer(int ID,string? login = "", string? password = "", string? name = "", string? firstname = "")
        {
            using (Apply context = new Apply())
            {
                if (login != "")
                {
                    User cust = context.Users.Where(x => x.ID_User == ID).First();
                    cust.LogInUser = login;
                    context.Update(cust);
                    context.SaveChanges();

                }
                if (password != "")
                {
                    User cust = context.Users.Where(x => x.ID_User == ID).First();
                    cust.PassWordUser = password;
                    context.Update(cust);
                    context.SaveChanges();

                }
                if (name != "")
                {
                    User cust = context.Users.Where(x => x.ID_User == ID).First();
                    cust.NameUser = name;
                    context.Update(cust);
                    context.SaveChanges();

                }
                if (firstname != "")
                {
                    User cust = context.Users.Where(x => x.ID_User == ID).First();
                    cust.FirstNameUser = firstname;
                    context.Update(cust);
                    context.SaveChanges();

                }


            }

        }
        /// <summary>
        /// Modifie une ou plusieurs valeur d'un employé en fonction de son id
        /// </summary>
        [HttpPut]
        public void putemployer(int ID, string? idjob="",string? login = "", string? password = "", string? name = "", string? firstname = "")
        {
            using (Apply context = new Apply())
            {
                if (login != "")
                {
                    User emp = context.Users.Where(x => x.ID_User == ID).First();
                    emp.LogInUser = login;
                    context.Update(emp);
                    context.SaveChanges();

                }
                if (idjob != "")
                {
                    User emp = context.Users.Where(x => x.ID_User == ID).First();
                    emp.Idjob = Convert.ToInt32(idjob);
                    context.Update(emp);
                    context.SaveChanges();

                }
                if (password != "")
                {
                    User emp = context.Users.Where(x => x.ID_User == ID).First();
                    emp.PassWordUser = password;
                    context.Update(emp);
                    context.SaveChanges();

                }
                if (name != "")
                {
                    User emp = context.Users.Where(x => x.ID_User == ID).First();
                    emp.NameUser = name;
                    context.Update(emp);
                    context.SaveChanges();

                }
                if (firstname != "")
                {
                    User emp = context.Users.Where(x => x.ID_User == ID).First();
                    emp.FirstNameUser = firstname;
                    context.Update(emp);
                    context.SaveChanges();
                }


            }

        }
        /// <summary>
        /// Modifie une ou plusieurs valeur d'une famille en fonction de son id
        /// </summary>
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
        /// <summary>
        /// Modifie une ou plusieurs valeur d'un fournisseur en fonction de son id
        /// </summary>
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
        /// <summary>
        /// Modifie une ou plusieurs valeur d'une fonction en fonction de son id
        /// </summary>
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
        /// <summary>
        /// Modifie une ou plusieurs valeur d'un article en fonction de son id
        /// </summary>
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
