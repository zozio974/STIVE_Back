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
    public class Commands
    {
        [HttpPost]
        public void addlinecommand(int idart,int refcom,int quant)
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
        public void addlinecommandsup(int idart, int refcom, int quant)
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
        public void addcommand(int refcom,int status)
        { 
            using (Apply context = new Apply())
            {
                double a = 0;
                Model.Command command = new Model.Command();
                command.RefCommand = refcom;
                command.Status_Comman = status;
                command.Date_Command = DateTime.Now.ToString("MM/dd/yyyy");
                List<LineCommand> line = context.LineCommands.Where(x => x.Ref_Command == refcom).ToList();
                foreach (LineCommand lineCom in line)
                {
                    a += lineCom.Price;
                }
                command.Price_Command= a;
                context.Add(command);
                context.SaveChanges();
            }
        }
        [HttpPost]
        public void addcommandcust(int refcom, int status,int idcust)
        {
            using (Apply context = new Apply())
            {
                double a = 0;
                Model.Command command = new Model.Command();
                command.RefCommand = refcom;
                command.Status_Comman = status;
                command.id_customer = idcust;
                command.Date_Command = DateTime.Now.ToString("MM/dd/yyyy");
                List<LineCommand> line = context.LineCommands.Where(x => x.Ref_Command == refcom).ToList();
                foreach (LineCommand lineCom in line)
                {
                    a += lineCom.Price;
                }
                command.Price_Command = a;
                context.Add(command);
                context.SaveChanges();
            }
        }
        [HttpGet]
        public List<LineCommand> displaylinecommand(int refcom)
        {
            using (Apply context = new Apply())
            {
                List<LineCommand> line = context.LineCommands.Where(x => x.Ref_Command == refcom).ToList();
                return line;
            }
        }
        
        
    }
}
