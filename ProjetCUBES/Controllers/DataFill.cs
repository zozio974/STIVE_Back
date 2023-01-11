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

    public class DataFill
    {
        public static string GetRandomPassword(int length)
        {
            byte[] rgb = new byte[length];
            RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
            rngCrypt.GetBytes(rgb);
            return Convert.ToBase64String(rgb);
        }
        public static string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        [HttpPost]

        public void FillBDD() 
        {
            FillUser();
            FillFamily();
            FillJob();
            FillSupplier();
            FillArticle();
            FillAuto();
            FillStatusCommand();
            FillCommands();
        }
       
        public static void FillUser()
        {
            using (Apply context = new Apply())
            {
                User auto= new User("adminauto","dnoanad9745","automatique","auto",1);
                User employer = new User("admin", "admin12", "patron", "patron", 1);
                User employer1 = new User("gestion", "gestion", "gestion", "gestion", 2);
                User employer2 = new User("inventaire", "inventaire", "inventaire", "inventaire", 3);
                User employer3 = new User("commande", "commande", "commande", "commande", 4);
                context.Add(auto);
                context.Add(employer);
                context.Add(employer1);
                context.Add(employer2);
                context.Add(employer3);
                context.SaveChanges();
                List<User> list = new List<User>();

                for (int i = 0; i < 100; i++)
                {
                    string a = Faker.Name.First();
                    User use = new User(Faker.Internet.Email(a), GetRandomPassword(8), Faker.Name.Last(), a, 5);

                    list.Add(use);
                }


                foreach (User emp in list)
                {
                    context.Add(emp);
                    context.SaveChanges();
                }


            }
        }

        public static void FillJob()
        {
            using (Apply context = new Apply())
            {
                List<Job> list = new List<Job>();
                list.Add(new Job("Admin"));
                list.Add(new Job("Gestionnaire"));
                list.Add(new Job("Inventoriste"));
                list.Add(new Job("Passeur de commande"));
                list.Add(new Job("Client"));

                foreach (Job job in list)
                {
                    context.Add(job);
                    context.SaveChanges();
                }
                
            }
        }

        public static void FillFamily() 
        {
            using (Apply context = new Apply())
            {
                List<Family> list = new List<Family>();

                list.Add(new Family("Blanc"));
                list.Add(new Family("Rosé"));
                list.Add(new Family("Rouge"));
                list.Add(new Family("Pétillants"));
                list.Add(new Family("Digestif"));

                foreach (Family fam in list)
                {
                    context.Add(fam);
                    context.SaveChanges();
                }
            }
        }

        public static void FillArticle()
        {
            var winelist = new string[]
            {
                "Chablis",
                "Champagne",
                "Chenin",
                "Bordeaux",
                "Burgundy",
                "Côtes du Rhône",
                "Loire Valley",
                "Rhône Valley",
                "Sancerre",
                "Provence",
                "Saint-Émilion",
                "Pomerol",
                "Châteauneuf-du-Pape",
                "Gigondas",
                "Hermitage",
                "Crozes-Hermitage",
                "Meursault",
                "Pouilly-Fuissé",
                "Sauternes",
                "Alsace",
                "Muscadet",
                "Vouvray",
                "Anjou",
                "Beaujolais",
                "Château-Grillet",
                "Collioure",
                "Condrieu",
                "Corsica",
                "Côtes de Gascogne",
                "Côtes de Provence",
                "Côtes du Jura",
                "Côtes du Luberon",
                "Côtes du Roussillon",
                "Côtes du Ventoux",
                "Jura",
                "Languedoc",
                "Madiran",
                "Minervois",
                "Rivesaltes",
                "Vin de Corse",
                "Vin de Pays de Côte de Gascogne",
                "Vin de Pays de l'Ardèche",
                "Vin de Pays de l'Hérault",
                "Vin de Pays de la Haute Vallée de l'Aude",
                "Vin de Pays de la Loire",
                "Vin de Pays de la Vallée de l'Oise",
                "Vin de Pays de la Vienne",
                "Vin de Pays de l'Oc",
                "Vin de Pays de Vaucluse"
            };
            var grapelist = new string[]
            {
                "Cabernet Sauvignon",
                "Pinot",
                "Chardonnay",
                "Sauvignon",
                "Syrah/Shiraz",
                "Riesling",
                "Merlot",
                "Zinfandel",
                "Pinot Grigio",
                "Gewurztraminer",
                "Viognier",
                "Malbec",
                "Cabernet Franc",
                "Pinot",
                "Pinot Meunier",
                "Gamay",
                "Grenache",
                "Tempranillo",
                "Sangiovese",
                "Nebbiolo",
                "Barolo",
                "Brunello di Montalcino",
                "Chianti",
                "Vermentino",
                "Verdelho",
                "Touriga Nacional",
                "Albarino",
                "Marsanne",
                "Roussanne",
                "Chenin",
                "Muscat",
                "Gros manseng",
                "Verdejo",
                "Sémillon",
                "Torrontes",
                "Verdejo",
                "Grüner Veltliner",
                "Glera",
                "Friulano",
                "Aglianico",
                "Nero d'Avola",
                "Fiano",
                "Godello",
                "Verduzzo",
                "Tannat",
                "Bonarda",
                "Bobal",
                "Mencia",
                "Garnacha",
                "Monastrell"
            };
            var ladderlist = new string[]
            {
                "1er cru",
                "1er cru",
                "1er cru",
                "1er cru",
                "1er cru",
                "1er cru",
                "1er cru classé",
                "2e cru classé",
                "grand cru",
                "grand cru",
                "grand cru",
                "cru classé",
                "village",
                "village",
                "village",
            };




            using (Apply context = new Apply())
            {
                
                List<Article> list = new List<Article>();
                for (int i = 0; i < 200; i++)
                {
                    int a = Faker.RandomNumber.Next(0,winelist.Length-1);
                    int b = Faker.RandomNumber.Next(0, grapelist.Length-1);
                    int c = Faker.RandomNumber.Next(0, ladderlist.Length - 1);
                    double d = Faker.RandomNumber.Next(7, 40);
                    Article use = new Article(winelist[a],Faker.RandomNumber.Next(1,5), Faker.RandomNumber.Next(2015,2022), Faker.RandomNumber.Next(1, 5), d,d+5,75,Faker.RandomNumber.Next(12, 15), grapelist[b], ladderlist[c],0,0,0);

                    list.Add(use);
                }
                
                foreach (Article art in list)
                {
                    if(Faker.RandomNumber.Next(1,3)== Faker.RandomNumber.Next(1, 3))
                    {
                        int a = Faker.RandomNumber.Next(15, 100);
                        art.StockActual= a;
                        art.StockProv = a;
                        art.StockMin = 10;
                    }
                    context.Add(art);
                    context.SaveChanges();
                }
            }
        }

        public static void FillSupplier()
        {
            using (Apply context = new Apply())
            {
                List<Supplier> list = new List<Supplier>();

                list.Add(new Supplier("Les domaines de Tariquet"));
                list.Add(new Supplier("Pelleheaut"));
                list.Add(new Supplier("Joy"));
                list.Add(new Supplier("Vignoble Fontan"));
                list.Add(new Supplier("Vignoble Uby"));

                foreach (Supplier sup in list)
                {
                    context.Add(sup);
                    context.SaveChanges();
                }
            }
        }

      
        public static void FillStatusCommand()
        {
            using (Apply context = new Apply())
            {
                List<StatusCommand> list = new List<StatusCommand>();

                list.Add(new StatusCommand("En cours"));
                list.Add(new StatusCommand("Archivé"));
                
                

                foreach (StatusCommand stat in list)
                {
                    context.Add(stat);
                    context.SaveChanges();
                }
            }
        }
        public static void FillCommands()
        {
            using (Apply context = new Apply())
            {
                List<Command> list = new List<Command>();
                List<LineCommand> list2 = new List<LineCommand>();


                for (int i=0; i < 20; i++)
                {
                    string b = RandomString(5);
                    int c = Faker.RandomNumber.Next(1, 50);
                    list.Add(new Command(b, DateTime.Now.ToString("MM/dd/yyyy"), Faker.RandomNumber.Next(20, 450),2,1));
                    list2.Add(new LineCommand(Faker.RandomNumber.Next(1, 199), b, c, c * Faker.RandomNumber.Next(7, 20)));
                }



                foreach (Command stat in list)
                {
                    context.Add(stat);
                    context.SaveChanges();
                }
                foreach (LineCommand stat in list2)
                {
                    context.Add(stat);
                    context.SaveChanges();
                }
            }
        }
        public static void FillAuto()
        {
            using (Apply context = new Apply())
            {
                List<Auto> list = new List<Auto>();

                list.Add(new Auto(50,1));

                

                foreach (Auto aut in list)
                {
                    context.Add(aut);
                    context.SaveChanges();
                }
            }
        }

    }
}
