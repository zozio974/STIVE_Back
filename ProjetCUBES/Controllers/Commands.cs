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
        /// <summary>
        ///  Génére une référence de commande qui n'existe pas
        /// </summary>
        [HttpGet]
        public  int getrefcom()
        {
            int a = 0;
            using (Apply context = new Apply())
            {
                List<Command> comm = new List<Command>();
                

                do
                {
                    comm = context.Commands.Where(x => x.RefCommand == a.ToString()).ToList();
                    if (comm.Any() == true )
                    {
                        a++; 
                    }

                   

                } while (comm.Any() == true) ;
                return a;
            }
                   
            
        }
        /// <summary>
        ///  Génére une référence de commande qui n'existe pas pour un site ou revient sur la commande deja en cours
        /// </summary>
        [HttpGet]
        public int getrefcomsite(int iduser)
        {
            int a = 0;
            using (Apply context = new Apply())
            {

                List<LineCommand> comm = context.LineCommands.Where(x => x.Id_user == iduser && x.Id_status == 1).ToList();


                if (comm.Any() == true)
                {
                    LineCommand com = context.LineCommands.Where(x => x.Id_user == iduser && x.Id_status == 1).First();
                    return Convert.ToInt32(com.Ref_Command);
                }
            }
            using (Apply context = new Apply())
            {
                List<LineCommand> comm = new List<LineCommand>();


                do
                {
                    comm = context.LineCommands.Where(x => x.Ref_Command == a.ToString()).ToList();
                    if (comm.Any() == true)
                    {
                        a++;
                    }



                } while (comm.Any() == true);
                return a;

            }


        }
        /// <summary>
        /// Ajoute une ligne de commande avec un article et sa quantité pour une commande avec sa référence
        /// </summary>
        [HttpPost]
        public void addlinecommand(int idart, string refcom, int quant,int iduser)
        {
            using (Apply context = new Apply())
            {
                LineCommand lineCommandCust = new LineCommand();
                Article article = context.Articles.Where(x => x.ID_Article == idart).First();
                lineCommandCust.Id_article = idart;
                lineCommandCust.Ref_Command = refcom;
                lineCommandCust.Quantity = quant;
                lineCommandCust.Id_user= iduser;
                lineCommandCust.Id_status = 2;
                lineCommandCust.Price = quant * article.Price;
                context.Add(lineCommandCust);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Ajoute une ligne de commande site avec un article et sa quantité pour une commande avec sa référence
        /// </summary>
        [HttpGet]
        public bool addlinecommandsite(int idart, int quant, int iduser)
        {
            using (Apply context = new Apply())
            {
                int a = getrefcomsite(iduser);
                LineCommand lineCommandCust = new LineCommand();

                Article article = context.Articles.Where(x => x.ID_Article == idart).First();
                lineCommandCust.Id_article = idart;
                lineCommandCust.Ref_Command = a.ToString();
                lineCommandCust.Quantity = quant;
                lineCommandCust.Id_user = iduser;
                lineCommandCust.Id_status = 1;
                lineCommandCust.Price = quant * article.Price;
                context.Add(lineCommandCust);
                context.SaveChanges();
            }
            return true;

        }
        /// <summary>
        /// Ajoute une ligne de commande fournisseur avec un article et sa quantité pour une commande avec sa référence
        /// </summary>

        [HttpPost]
        public void addlinecommandsup(int idart, string refcom, int quant,int iduser)
        {
            using (Apply context = new Apply())
            {
                LineCommand lineCommandCust = new LineCommand();
                Article article = context.Articles.Where(x => x.ID_Article == idart).First();
                lineCommandCust.Id_article = idart;
                lineCommandCust.Ref_Command = refcom;
                lineCommandCust.Quantity = quant;
                lineCommandCust.Id_user = iduser;
                lineCommandCust.Id_status = 2;

                lineCommandCust.Price = quant * article.PriceSup;
                context.Add(lineCommandCust);
                context.SaveChanges();


            }
        }
        /// <summary>
        /// Ajoute une commande fournisseur
        /// </summary>
        [HttpPost]
        public void addcommand(string refcom, int iduser)
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
                    stock.StockProv += lineCom.Quantity;
                    a += lineCom.Price;
                    context.Update(stock);
                    context.SaveChanges();
                }
                command.Price_Command = a;
                context.Add(command);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Ajoute une commande via le site
        /// </summary>
        [HttpGet]
        public bool addcommandsite(string refcom, int iduser)
        {
            using (Apply context = new Apply())
            {
                User user = context.Users.Where(x => x.ID_User == iduser).First();

                double a = 0;
                Model.Command command = new Model.Command();
                command.RefCommand = refcom;
                command.Status_Comman = 3;
                command.Date_Command = DateTime.Now.ToString("MM/dd/yyyy");
                command.Id_User = user.ID_User;
                List<LineCommand> line = context.LineCommands.Where(x => x.Ref_Command == refcom).ToList();


                foreach (LineCommand lineCom in line)
                {
                    Article stock = context.Articles.Where(x => x.ID_Article == lineCom.Id_article).First();
                    a += lineCom.Price;
                    lineCom.Id_status = 2;
                    context.Update(lineCom);
                    context.Update(stock);
                    context.SaveChanges();
                }
                command.Price_Command = a;
                context.Add(command);
                context.SaveChanges();
            }
            return true;
        }
        /// <summary>
        /// Ajoute une commande client via l'application
        /// </summary>
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
                    Auto auto = context.Autos.Where(x => x.Id == 1).First();
                    User user = context.Users.Where(x => x.ID_User == 1).First();
                    if (stock.StockProv < stock.StockMin && auto.AutoRefill == 1)
                    {
                        string refe = getrefcom().ToString();
                        addlinecommandsup(stock.ID_Article, refe, auto.AddToStock,user.ID_User);
                        addcommand(refe, user.ID_User);
                    }
                }
                command.Price_Command = a;
                context.Add(command);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Affiche toute les lignes de commande d'une commande suivant sa référence
        /// </summary>
        [HttpGet]
        public List<LineCommand> displaylinecommand(string refcom)
        {
            using (Apply context = new Apply())
            {
                List<LineCommand> line = context.LineCommands.Where(x => x.Ref_Command == refcom).ToList();
                return line;
            }
        }
        /// <summary>
        /// Baisse le stock d'un article  d'une certaine quantité suivant l'id de cet article
        /// </summary>
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
                    string a = getrefcom().ToString();
                    addlinecommandsup(idstock, a, auto.AddToStock, user.ID_User);
                    addcommand(a, user.ID_User);
                }
            }
        }
        /// <summary>
        /// Baisse le stock d'un article  de 1 suivant l'id de cet article
        /// </summary>
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
                    string a = getrefcom().ToString();
                    addlinecommandsup(idstock, a, auto.AddToStock, user.ID_User);
                    addcommand(a, user.ID_User);
                }
            }
        }
        /// <summary>
        /// Modifie le stock d'un article  par une valeur suivant l'id de cet article
        /// </summary>
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
                    int a = getrefcom();
                    addlinecommandsup(idstock, a.ToString(), auto.AddToStock,user.ID_User);
                    addcommand(a.ToString(), user.ID_User);
                }
            }
        }
        /// <summary>
        /// Affiche la liste des commandes avec les commandes les plus récentes affichées en premier
        /// </summary>
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
        /// <summary>
        /// Valide une commande fournisseur : change son statut et actualise le stock
        /// </summary>
        [HttpPost]
        public void validatecommand(int id)
        {
            using (Apply context = new Apply())
            {
                Command comm = context.Commands.Where(x => x.Id_Command == id).First();
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
        /// <summary>
        /// Valide une commande client : change son statut et actualise le stock
        /// </summary>
        [HttpPost]
        public void validatecommandclient(int id)
        {
            using (Apply context = new Apply())
            {
                Command comm = context.Commands.Where(x => x.Id_Command == id).First();
                List<LineCommand> linecom = context.LineCommands.Where(x => x.Ref_Command == comm.RefCommand).ToList();
                if (comm.Status_Comman== 3)
                {
                    comm.Status_Comman = 1;
                    context.Update(comm);
                    context.SaveChanges();


                    foreach (LineCommand line in linecom)
                    {
                        Article stock = context.Articles.Where(x => x.ID_Article == line.Id_article).First();
                        stock.StockProv -= line.Quantity;
                        stock.StockActual -= line.Quantity;
                        
                        context.Update(stock);
                        context.SaveChanges();
                        Auto auto = context.Autos.Where(x => x.Id == 1).First();
                        User user = context.Users.Where(x => x.ID_User == 1).First();
                        if (stock.StockProv < stock.StockMin && auto.AutoRefill == 1)
                        {
                            string refe = getrefcom().ToString();
                            addlinecommandsup(stock.ID_Article, refe, auto.AddToStock, user.ID_User);
                            addcommand(refe, user.ID_User);
                           
                        }
                    }
                    

                }
                else
                {
                    comm.Status_Comman = 2;
                    context.Update(comm);
                    context.SaveChanges();

                }

            }

        }
        /// <summary>
        /// Annule une commande client 
        /// </summary>
        [HttpGet]
        public bool cancelcommandclient(int id)
        {
            using (Apply context = new Apply())
            {
                Command comm = context.Commands.Where(x => x.Id_Command == id).First();
                List<LineCommand> linecom = context.LineCommands.Where(x => x.Ref_Command == comm.RefCommand).ToList();
                foreach (LineCommand line in linecom)
                {
                    Article article = context.Articles.Where(x => x.ID_Article == line.Id_article).First();
                    article.StockActual += line.Quantity;
                    article.StockProv += line.Quantity;
                    context.Update(article);
                    context.Remove(line);
                    context.SaveChanges();

                }
                context.Remove(comm);
                context.SaveChanges();
                return true;
            }


        }
        /// <summary>
        /// Annule une commande fournisseur 
        /// </summary>
        [HttpPut]
        public void cancelcommandsup(int id)
        {
            using (Apply context = new Apply())
            {
                Command comm = context.Commands.Where(x => x.Id_Command == id).First();
                List<LineCommand> linecom = context.LineCommands.Where(x => x.Ref_Command == comm.RefCommand).ToList();
                foreach (LineCommand line in linecom)
                {
                    Article article = context.Articles.Where(x => x.ID_Article == line.Id_article).First();
                    article.StockProv -= line.Quantity;
                    
                    context.Update(article);
                    context.Remove(line);
                    context.SaveChanges();
                }
                context.Remove(comm);
                context.SaveChanges();

            }

        }
        /// <summary>
        /// Vérifie si on peut valider une commande client, il faut pas que le stock devienne négatif aprés la commande
        /// </summary>
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
                    if (article.StockActual < 0 && line.Id_status ==1)
                    {
                        return false;
                    }
                }
                return true;

            }

        }
        /// <summary>
        /// Affiche toute les commandes fournisseur
        /// </summary>
        [HttpGet]

        public List<Command> displaycommandsup()
        {
            using (Apply context = new Apply())
            {
                var comres = new List<Command>();
                List<Command> comm = context.Commands.ToList();
                foreach (Command com in comm)
                {
                    User user = context.Users.Where(x => x.ID_User == com.Id_User).First();
                    if (user.Idjob != 5)
                    {
                        comres.Add(com);
                    }
                }
                List<Command> reverse = Enumerable.Reverse(comres).ToList();
                return reverse;
            }
        }
        /// <summary>
        /// Affiche toute les commandes clients
        /// </summary>
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
        /// <summary>
        /// Affiche le prix total d'une commande
        /// </summary>
        [HttpGet]
        public double displaytotalcommand(string refe)
        {
            using (Apply context = new Apply())
            {
                double a = 0;

                List<LineCommand> linecom = context.LineCommands.Where(x => x.Ref_Command == refe).ToList();
                foreach (LineCommand line in linecom)
                {
                    a += line.Price;
                }
                return a;

            }

        }
    }
}