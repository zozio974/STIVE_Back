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
        /// <summary>
        /// Supprime un utilisateur de la table selon son id
        /// </summary>
        [HttpDelete]
        public void delete_user(int ID)
        {
            using (Apply context = new Apply())
            {
                User cust = context.Users.Where(x => x.ID_User == ID).First();
                context.Remove(cust);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Supprime une famille de la table selon son id
        /// </summary>
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
        /// <summary>
        /// Supprime un article de la table selon son id
        /// </summary>
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
        /// <summary>
        /// Supprime un fournisseur de la table selon son id
        /// </summary>
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
        /// <summary>
        /// Supprime une fonction de la table selon son id
        /// </summary>
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
        /// <summary>
        /// Supprime une ligne de commande de la table selon son id
        /// </summary>
        [HttpDelete]
        public void delete_linecommand(int ID)
        {
            using (Apply context = new Apply())
            {
                LineCommand line = context.LineCommands.Where(x => x.Id_LineCommande == ID).First();
                context.Remove(line);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Supprime une ligne de commande du panier site de la table selon son id
        /// </summary>
        [HttpGet]
        public bool deletelinecommandsite(int ID)
        {

            try
            {
                using (Apply context = new Apply())
                {
                    LineCommand line = context.LineCommands.Where(x => x.Id_LineCommande == ID).First();
                    context.Remove(line);
                    context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}

