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
        [HttpPut]
        public void addstockunit(int idart)
        {
            using (Apply context = new Apply())
            {
                Stock stock = context.Stocks.Where(x => x.IdArticle == idart).First();
                stock.StockActual ++;
                stock.StockProv++;
                context.Update(stock);
                context.SaveChanges();
            }
        }
        [HttpPut]
        public void addstockunitid(int idstock)
        {
            using (Apply context = new Apply())
            {
                Stock stock = context.Stocks.Where(x => x.ID_Stock == idstock).First();
                stock.StockActual++;
                stock.StockProv++;
                context.Update(stock);
                context.SaveChanges();
            }
        }
        [HttpPut]

        public void dropstockunit(int idart)
        {
            using (Apply context = new Apply())
            {
                Stock stock = context.Stocks.Where(x => x.IdArticle == idart).First();
                stock.StockActual--;
                stock.StockProv--;
                context.Update(stock);
                context.SaveChanges();
            }
        }
        [HttpPut]
        public void dropstockunitid(int idstock)
        {
            using (Apply context = new Apply())
            {
                Stock stock = context.Stocks.Where(x => x.ID_Stock == idstock).First();
                stock.StockActual--;
                stock.StockProv--;
                context.Update(stock);
                context.SaveChanges();
            }
        }
        [HttpPut]

        public void addstockmul(int idart, int i)
        {
            using (Apply context = new Apply())
            {
                Stock stock = context.Stocks.Where(x => x.IdArticle == idart).First();
                stock.StockActual += i;
                stock.StockProv += i;
                context.Update(stock);
                context.SaveChanges();
            }
        }
        [HttpPut]
        public void addstockmulid(int idstock, int i)
        {
            using (Apply context = new Apply())
            {
                Stock stock = context.Stocks.Where(x => x.ID_Stock == idstock).First();
                stock.StockActual += i;
                stock.StockProv += i;
                context.Update(stock);
                context.SaveChanges();
            }
        }
        [HttpPut]
        public void dropstockmul(int idart, int i)
        {
            using (Apply context = new Apply())
            {
                Stock stock = context.Stocks.Where(x => x.IdArticle == idart).First();
                stock.StockActual -= i;
                stock.StockProv -= i;
                context.Update(stock);
                context.SaveChanges();
            }
        }
        [HttpPut]
        public void dropstockmulid(int idstock, int i)
        {
            using (Apply context = new Apply())
            {
                Stock stock = context.Stocks.Where(x => x.ID_Stock == idstock).First();
                stock.StockActual -= i;
                stock.StockProv -= i;
                context.Update(stock);
                context.SaveChanges();
            }
        }
        [HttpPut]
        public void putstockmin(int idstock, int i)
        {
            using (Apply context = new Apply())
            {
                Stock stock = context.Stocks.Where(x => x.ID_Stock == idstock).First();
                stock.StockMin = i;               
                context.Update(stock);
                context.SaveChanges();
            }
        }
    }
}
