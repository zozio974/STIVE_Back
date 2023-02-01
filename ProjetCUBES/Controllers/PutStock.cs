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


    public class PutStock
    {
        /// <summary>
        /// Ajoute une unité au stock d'un article en fonction de l'id de l'article
        /// </summary>
        [HttpPut]
        public void addstockunitid(int idstock)
        {
            using (Apply context = new Apply())
            {
                Article stock = context.Articles.Where(x => x.ID_Article == idstock).First();
                stock.StockActual++;
                stock.StockProv++;
                context.Update(stock);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Ajoute un nombre au stock d'un article en fonction de l'id de l'article
        /// </summary>
        [HttpPut]
        public void addstockmulid(int idstock, int i)
        {
            using (Apply context = new Apply())
            {
                Article stock = context.Articles.Where(x => x.ID_Article == idstock).First();
                stock.StockActual += i;
                stock.StockProv += i;
                context.Update(stock);
                context.SaveChanges();
            }

        }

        /// <summary>
        /// Remplace le stock minimum par un nombre d'un article en fonction de son id
        /// </summary>
        [HttpPut]
        public void putstockmin(int idstock, int i)
        {
            using (Apply context = new Apply())
            {
                Article stock = context.Articles.Where(x => x.ID_Article == idstock).First();
                stock.StockMin = i;               
                context.Update(stock);
                context.SaveChanges();
            }
        }
        
    }
}
