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
        /// <summary>
        /// Affiche toute la table article
        /// </summary>
        [HttpGet]
        public List<Article> displayarticle()
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.ToList();
                return article;
            }
        }
        /// <summary>
        /// Affiche un article en fonction de son id
        /// </summary>
        [HttpGet]
        public Article displayarticlebyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                return art;
            }

        }
        /// <summary>
        /// Affiche un article en fonction de son nom
        /// </summary>
        [HttpGet]
        
        public List<Article> displayarticlebyname(string name)
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.Where(x => x.NameArticle == name).ToList();
                return article;
            }
        }

        /// <summary>
        /// Affiche tout les clients 
        /// </summary>
        [HttpGet]

        public List<User> displaycustomers()
        {
            using (Apply context = new Apply())
            {
                List<User> customer = context.Users.Where(x=> x.Idjob == 5).ToList();
                return customer;
            }
        }
        /// <summary>
        /// Affiche un utilisateur en fonction de son id
        /// </summary>
        [HttpGet]
        public User displayusersbyid(int ID)
        {
            using (Apply context = new Apply())
            {
                User cust = context.Users.Where(x => x.ID_User == ID).First();
                return cust;
            }

        }
        /// <summary>
        /// Affiche tout les employés
        /// </summary>
        [HttpGet]
        public List<User> displayemployers()
        {
            using (Apply context = new Apply())
            {
                List<User> customer = context.Users.Where(x => x.Idjob != 5).ToList();
                return customer;
            }
        }
        /// <summary>
        /// Affiche toute les familles
        /// </summary>
        [HttpGet]
        public List<Family> displayfamily()
        {
            using (Apply context = new Apply())
            {
                List<Family> family = context.Familys.ToList();
                return family;
            }
        }
        /// <summary>
        /// Affiche une famille en fonction de son id
        /// </summary>
        [HttpGet]
        public Family displayfamilybyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Family fam = context.Familys.Where(x => x.ID_Family == ID).First();
                return fam;
            }

        }

        /// <summary>
        /// Affiche toutes les fonctions
        /// </summary>
        [HttpGet]
        public List<Job> displayjob()
        {
            using (Apply context = new Apply())
            {
                List<Job> job = context.Jobs.ToList();
                return job;
            }
        }
        /// <summary>
        /// Affiche une fonction en fonction de son id
        /// </summary>
        [HttpGet]
        public Job displayjobbyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Job job = context.Jobs.Where(x => x.ID_Job == ID).First();
                return job;
            }

        }
        /// <summary>
        /// Affiche tout les fournisseurs
        /// </summary>
        [HttpGet]
        public List<Supplier> displaysup()
        {
            using (Apply context = new Apply())
            {
                List<Supplier> sup = context.Suppliers.ToList();
                return sup;
            }
        }
        /// <summary>
        /// Affiche un fournisseur en fonction de son id
        /// </summary>
        [HttpGet]
        public Supplier displaysupbyid(int ID)
        {
            using (Apply context = new Apply())
            {
                Supplier sup = context.Suppliers.Where(x => x.Id == ID).First();
                return sup;
            }

        }
        /// <summary>
        /// Retourne l'id d'une famille en fonction de son nom
        /// </summary>
        [HttpGet]
        public string getidfamily(string name)
        {
            using (Apply context = new Apply())
            {
                Family fam = context.Familys.Where(x => x.NameFamily== name).First();
                return fam.ID_Family.ToString();
            }
        }
        /// <summary>
        /// Retourne l'id d'une fonction en fonction de son nom
        /// </summary>
        [HttpGet]
        public string getidjob(string name)
        {
            using (Apply context = new Apply())
            {
                Job job = context.Jobs.Where(x => x.JobName == name).First();
                return job.ID_Job.ToString();
            }
        }
        /// <summary>
        /// Retourne l'id d'un utilisateur en fonction de son login
        /// </summary>
        [HttpGet]
        public int getiduser(string login)
        {
            using (Apply context = new Apply())
            {
                User use = context.Users.Where(x => x.LogInUser == login).First();
                return use.ID_User;
            }
        }
        /// <summary>
        /// Retourne l'id d'un fournisseur en fonction de son nom
        /// </summary>
        [HttpGet]
        public string getidsupplier(string name)
        {
            using (Apply context = new Apply())
            {
                Supplier sup = context.Suppliers.Where(x => x.Name == name).First();
                return sup.Id.ToString();
            }
        }
        /// <summary>
        /// Retourne le nom d'une famille en fonction de son id
        /// </summary>
        [HttpGet]
        public string getnamefamily(int id)
        {
            using (Apply context = new Apply())
            {
                Family fam = context.Familys.Where(x => x.ID_Family == id).First();
                return fam.NameFamily.ToString();
            }
        }
        /// <summary>
        /// Retourne le nom d'un fournisseur en fonction de son id
        /// </summary>
        [HttpGet]
        public string getnamesupplier(int id)
        {
            using (Apply context = new Apply())
            {
                Supplier sup = context.Suppliers.Where(x => x.Id == id).First();
                return sup.Name.ToString();
            }
        }
        /// <summary>
        /// Retourne le nom d'une fonction en fonction de son id
        /// </summary>
        [HttpGet]
        public string getnamejob(int id)
        {
            using (Apply context = new Apply())
            {
                Job job = context.Jobs.Where(x => x.ID_Job == id).First();
                return job.JobName.ToString();
            }
        }
        /// <summary>
        /// Retourne une liste d'article en fonction d'une liste d'id
        /// </summary>
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
        /// <summary>
        /// Retourne une liste de nom de fournisseurs en fonction d'une liste d'id
        /// </summary>
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
        /// <summary>
        /// Retourne une liste de nom de famille de vins en fonction d'une liste d'id
        /// </summary>
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
        /// <summary>
        /// Retourne une liste de nom de fonction en fonction d'une liste d'id
        /// </summary>
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
        /// <summary>
        /// Retourne le nom d'un utilisateur en fonction de son id
        /// </summary>
       
        [HttpGet]
        public string getnameuser(int ID)
        {
            using (Apply context = new Apply())
            {
                User user = context.Users.Where(x => x.ID_User == ID).First();
                return user.NameUser.ToString();
            }
        }
        /// <summary>
        /// Retourne une liste de nom d'utilisateur en fonction d'une liste d'id
        /// </summary>
        [HttpGet]
        public List<string> getlistnameuser([FromQuery] int[] listOfIds)
        {
            using (Apply context = new Apply())
            {
                List<string> list1 = new List<string>();
                foreach (int s in listOfIds)
                {
                    list1.Add(getnameuser(s).ToString());
                }
                return list1;
            }
        }
        /// <summary>
        /// Retourne le statut d'une commande en fonction de son id
        /// </summary>
        [HttpGet]
        public string getnamestatus(int ID)
        {
            using (Apply context = new Apply())
            {
                StatusCommand stat = context.StatusCommands.Where(x => x.Id_StatusCommand == ID).First();
                return stat.Name.ToString();
            }
        }
        /// <summary>
        /// Retourne une liste de nom de statu en fonction d'une liste d'id
        /// </summary>
        [HttpGet]
        public List<string> getlistnamestatus([FromQuery] int[] listOfIds)
        {
            using (Apply context = new Apply())
            {
                List<string> list1 = new List<string>();
                foreach (int s in listOfIds)
                {
                    list1.Add(getnamestatus(s).ToString());
                }
                return list1;
            }
        }
        /// <summary>
        /// Retourne le nom d'un article en fonction de son id
        /// </summary>
        [HttpGet]
        public string getnamearticle(int ID)
        {
            using (Apply context = new Apply())
            {
                Article art = context.Articles.Where(x => x.ID_Article == ID).First();
                return art.NameArticle.ToString();
            }
        } 
        /// <summary>
          /// Retourne une liste de nom d'article en fonction d'une liste d'id
          /// </summary>
        [HttpGet]
       
        public List<string> getlistnamearticle([FromQuery] int[] listOfIds)
        {
            using (Apply context = new Apply())
            {
                List<string> list1 = new List<string>();
                foreach (int s in listOfIds)
                {
                    list1.Add(getnamearticle(s).ToString());
                }
                return list1;
            }
        }
    }
}
