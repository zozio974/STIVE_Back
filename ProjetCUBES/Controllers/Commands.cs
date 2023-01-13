using Bogus;
using Bogus.DataSets;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetCUBES.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using WebApi.OutputCache.Core.Time;
using static ProjetCUBES.Helpers.Class;
namespace ProjetCUBES.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Commands
    {
        [HttpPost]
        public void addlinecommand(int idart,string refcom,int quant)
        {
            using (Apply context = new Apply())
            {
                LineCommand lineCommandCust= new LineCommand();
                Article article = context.Articles.Where(x => x.ID_Article == idart).First();
                lineCommandCust.Id_article = idart;
                lineCommandCust.Ref_Command = refcom;
                lineCommandCust.Quantity = quant;
                lineCommandCust.Price = quant * article.Price;
                context.Add(lineCommandCust);
                context.SaveChanges();
            }
        }
        [HttpPost]
        public void addlinecommandsup(int idart, string refcom, int quant)
        {
            using (Apply context = new Apply())
            {
                LineCommand lineCommandCust = new LineCommand();
                Article article = context.Articles.Where(x => x.ID_Article == idart).First();
                lineCommandCust.Id_article = idart;
                lineCommandCust.Ref_Command = refcom;
                lineCommandCust.Quantity = quant;
                lineCommandCust.Price = quant * article.PriceSup;
                context.Add(lineCommandCust);
                context.SaveChanges();

               
            }
        }

        [HttpPost]
        public void addcommand(string refcom,int iduser)
        { 
            using (Apply context = new Apply())
            {
                double a = 0;
                double b = 0;
                Model.Command command = new Model.Command();
                command.RefCommand = refcom;
                command.Status_Comman = 1;
                command.Date_Command = DateTime.Now.ToString("MM/dd/yyyy");
                command.Id_User= iduser;
                List<LineCommand> line = context.LineCommands.Where(x => x.Ref_Command == refcom).ToList();
                
                
                foreach (LineCommand lineCom in line)
                {
                    Article stock = context.Articles.Where(x => x.ID_Article == lineCom.Id_article).First();
                    stock.StockProv += lineCom.Quantity;
                    a += lineCom.Price;
                    context.Update(stock);
                    context.SaveChanges();
                }
                command.Price_Command= a;
                context.Add(command);
                context.SaveChanges();
            }
        }

        [HttpPost]
        public void addcommandclient(string refcom, int iduser)
        {
            using (Apply context = new Apply())
            {
                double a = 0;
                double b = 0;
                Model.Command command = new Model.Command();
                command.RefCommand = refcom;
                command.Status_Comman = 1;
                command.Date_Command = DateTime.Now.ToString("MM/dd/yyyy");
                command.Id_User = iduser;
                List<LineCommand> line = context.LineCommands.Where(x => x.Ref_Command == refcom).ToList();


                foreach (LineCommand lineCom in line)
                {
                    Article stock = context.Articles.Where(x => x.ID_Article == lineCom.Id_article).First();
                    stock.StockProv -= lineCom.Quantity;
                    stock.StockActual -= lineCom.Quantity;
                    a += lineCom.Price;
                    context.Update(stock);
                    context.SaveChanges();
                }
                command.Price_Command = a;
                context.Add(command);
                context.SaveChanges();
            }
        }

        [HttpGet]
        public List<LineCommand> displaylinecommand(string refcom)
        {
            using (Apply context = new Apply())
            {
                List<LineCommand> line = context.LineCommands.Where(x => x.Ref_Command == refcom).ToList();
                return line;
            }
        }
        [HttpPut]
        public void dropstockmulid(int idstock, int i)
        {
            using (Apply context = new Apply())
            {
                Article stock = context.Articles.Where(x => x.ID_Article == idstock).First();
                stock.StockActual -= i;
                stock.StockProv -= i;
                context.Update(stock);
                context.SaveChanges();
            }
            using (Apply context = new Apply())
            {
                Article stock = context.Articles.Where(x => x.ID_Article == idstock).First();
                Auto auto = context.Autos.Where(x => x.Id == 1).First();
                User user = context.Users.Where(x => x.ID_User == 1).First();
                if (stock.StockProv < stock.StockMin && auto.AutoRefill == 1)
                {
                    string a = DataFill.RandomString(5);
                    addlinecommandsup(idstock, a, auto.AddToStock);
                    addcommand(a, user.ID_User);
                }
            }
        }
        [HttpPut]
        public void dropstockunitid(int idstock)
        {
            using (Apply context = new Apply())
            {
                Article stock = context.Articles.Where(x => x.ID_Article == idstock).First();
                stock.StockActual--;
                stock.StockProv--;
                context.Update(stock);
                context.SaveChanges();
            }
            using (Apply context = new Apply())
            {
                Article stock = context.Articles.Where(x => x.ID_Article == idstock).First();
                Auto auto = context.Autos.Where(x => x.Id == 1).First();
                User user = context.Users.Where(x => x.ID_User == 1).First();
                if (stock.StockProv < stock.StockMin && auto.AutoRefill == 1)
                {
                    string a = DataFill.RandomString(5);
                    addlinecommandsup(idstock, a, auto.AddToStock);
                    addcommand(a, user.ID_User);
                }
            }
        }
        [HttpPut]
        public void putstock(int idstock, int i)
        {
            using (Apply context = new Apply())
            {
                Article stock = context.Articles.Where(x => x.ID_Article == idstock).First();
                stock.StockProv = i;
                stock.StockActual = i;
                context.Update(stock);
                context.SaveChanges();
            }
            using (Apply context = new Apply())
            {
                Article stock = context.Articles.Where(x => x.ID_Article == idstock).First();
                Auto auto = context.Autos.Where(x => x.Id == 1).First();
                User user = context.Users.Where(x => x.ID_User == 1).First();
                if (stock.StockProv < stock.StockMin && auto.AutoRefill == 1)
                {
                    string a = DataFill.GetRandomPassword(5);
                    addlinecommandsup(idstock, a, auto.AddToStock);
                    addcommand(a, user.ID_User);
                }
            }
        }
        [HttpGet]
        public List<Command> displaycommands()
        {
            using (Apply context = new Apply())
            {
                List<Command> commande = context.Commands.ToList();
                List<Command> reverse = Enumerable.Reverse(commande).ToList();

                return reverse;
            }
        }
        [HttpPost]
        public void validatecommand(int id)
        {
            using (Apply context = new Apply())
            {
                Command comm = context.Commands.Where(x => x.Id_Command== id).First();
                List<LineCommand> linecom = context.LineCommands.Where(x => x.Ref_Command == comm.RefCommand).ToList();
                foreach (LineCommand line in linecom)
                {
                    Article article = context.Articles.Where(x => x.ID_Article == line.Id_article).First();
                    article.StockActual = article.StockProv;
                    context.Update(article);
                    context.SaveChanges();
                }
                comm.Status_Comman = 2;
                context.Update(comm);
                context.SaveChanges();

            }

        }
        [HttpPost]
        public void validatecommandclient(int id)
        {
            using (Apply context = new Apply())
            {
                Command comm = context.Commands.Where(x => x.Id_Command == id).First();
                List<LineCommand> linecom = context.LineCommands.Where(x => x.Ref_Command == comm.RefCommand).ToList();
                foreach (LineCommand line in linecom)
                {
                    Article article = context.Articles.Where(x => x.ID_Article == line.Id_article).First();
                    article.StockActual -= line.Quantity;
                    article.StockProv -= line.Quantity;
                    context.Update(article);
                    context.SaveChanges();
                }
                comm.Status_Comman = 2;
                context.Update(comm);
                context.SaveChanges();

            }

        }
        [HttpGet]
        public bool checkvalidatecommandclient(int id)
        {
            using (Apply context = new Apply())
            {
                Command comm = context.Commands.Where(x => x.Id_Command == id).First();
                List<LineCommand> linecom = context.LineCommands.Where(x => x.Ref_Command == comm.RefCommand).ToList();
                foreach (LineCommand line in linecom)
                {
                    Article article = context.Articles.Where(x => x.ID_Article == line.Id_article).First();
                    article.StockActual -= line.Quantity;
                    article.StockProv -= line.Quantity;
                    if (article.StockActual < 0)
                    {
                        return false;
                    }
                }
                return true;

            }

        }
        [HttpGet]

        public List<Command> displaycommandsup()
        {
            using (Apply context = new Apply())
            {
                var comres = new List<Command>();
                List<Command> comm = context.Commands.ToList();
                foreach(Command com in comm)
                {
                    User user = context.Users.Where(x => x.ID_User == com.Id_User).First();
                    if(user.Idjob != 5)
                    {
                        comres.Add(com);
                    }
                }
                List<Command> reverse = Enumerable.Reverse(comres).ToList();
                return reverse;
            }
        }
        [HttpGet]
        public List<Command> displaycommandclient()
        {
            using (Apply context = new Apply())
            {
                var comres = new List<Command>();
                List<Command> comm = context.Commands.ToList();
                foreach (Command com in comm)
                {
                    User user = context.Users.Where(x => x.ID_User == com.Id_User).First();
                    if (user.Idjob == 5)
                    {
                        comres.Add(com);
                    }
                }
                List<Command> reverse = Enumerable.Reverse(comres).ToList();
                return reverse;
            }
        }

    }
}
