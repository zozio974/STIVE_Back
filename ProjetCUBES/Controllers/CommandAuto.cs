using Bogus;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetCUBES.Model;
using System;
using System.Security.Cryptography;
using WebApi.OutputCache.Core.Time;
using static ProjetCUBES.Helpers.Class;
namespace ProjetCUBES.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CommandAuto
    {
        /// <summary>
        ///  Passe la fonction commande automatique en off
        /// </summary>
        [HttpPut]
        public void commandeauto_off()
        {
            using (Apply context = new Apply())
            {
                Auto auto = context.Autos.Where(x => x.Id == 1).First();
                auto.AutoRefill=0;
                context.Update(auto);
                context.SaveChanges();
            }
        }
        /// <summary>
        ///  Passe la fonction commande automatique en on
        /// </summary>
        [HttpPut]
        public void commandeauto_on()
        {
            using (Apply context = new Apply())
            {
                Auto auto = context.Autos.Where(x => x.Id == 1).First();
                auto.AutoRefill = 1;
                context.Update(auto);
                context.SaveChanges();
            }
        }
        /// <summary>
        ///  Change la quantité d'article commandé pour les rechargements automatiques
        /// </summary>
        [HttpPut]
        public void quantiteaddtostock(int y)
        {
            using (Apply context = new Apply())
            {
                Auto auto = context.Autos.Where(x => x.Id == 1).First();
                auto.AddToStock = y;
                context.Update(auto);
                context.SaveChanges();
            }
        }
        /// <summary>
        ///  Affiche la valeur de la variable pour les commandes automatique
        /// </summary>
        [HttpGet]
        public int displayautovar()
        {

            using (Apply context = new Apply())
            {
                Auto auto = context.Autos.Where(x => x.Id == 1).First();
                return auto.AutoRefill;
            }
        }
        /// <summary>
        ///  Affiche la valeur du montant ajouté au stock pour les commandes automatiques
        /// </summary>
        [HttpGet]
        public int displayquantadd()
        {

            using (Apply context = new Apply())
            {
                Auto auto = context.Autos.Where(x => x.Id == 1).First();
                return auto.AddToStock;
            }
        }


    }
}
