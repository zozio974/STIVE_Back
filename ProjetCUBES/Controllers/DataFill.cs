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

        [HttpPost]

        public void FillBDD() 
        { 
            FillCustomer();
            FillFamily();
            FillJob();
            FillEmployer();
            FillSupplier();
            FillArticle();
            FillStock();
            FillStatusCommand();
        }
        public static void FillCustomer()
        {
            using (Apply context = new Apply())
            {
                List<Customer> list = new List<Customer>();

                for (int i = 0; i < 100; i++)
                {
                    string a = Faker.Name.First();
                    Customer use = new Customer(Faker.Internet.Email(a), GetRandomPassword(8), Faker.Name.Last(), a);

                    list.Add(use);
                }


                foreach (Customer cust in list)
                {
                    context.Add(cust);
                    context.SaveChanges();
                }

            }
        }
        public static void FillEmployer()
        {
            using (Apply context = new Apply())
            {
                Employer employer = new Employer("admin", "admin12", "patron", "patron", 1);
                context.Add(employer);
                context.SaveChanges();
                List<Employer> list = new List<Employer>();

                for (int i = 0; i < 10; i++)
                {
                    string a = Faker.Name.First();
                    Employer use = new Employer(Faker.Internet.Email(a), GetRandomPassword(8), Faker.Name.Last(), a, Faker.RandomNumber.Next(2, 4));

                    list.Add(use);
                }


                foreach (Employer emp in list)
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
                list.Add(new Job("Gérant"));
                list.Add(new Job("Gestionnaire"));
                list.Add(new Job("Inventoriste"));
                list.Add(new Job("Passeur de commande"));
                foreach(Job job in list)
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
                    Article use = new Article(winelist[a],Faker.RandomNumber.Next(1,5), Faker.RandomNumber.Next(2015,2022), Faker.RandomNumber.Next(1, 5), d,d+5,75,Faker.RandomNumber.Next(12, 15), grapelist[b], ladderlist[c]);

                    list.Add(use);
                }
                foreach (Article art in list)
                {
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

        public static void FillStock()
        {
            using (Apply context = new Apply())
            {
                List<Stock> list = new List<Stock>();
                int x = Faker.RandomNumber.Next(1, 5);
                for (int i = 1; i < 100; i=i+x)
                {
                    string a = Faker.Name.First();
                    int c = Faker.RandomNumber.Next(2, 15);
                    int d = Faker.RandomNumber.Next(c, 100);
                    Stock use = new Stock(i, d,d, c);
                    list.Add(use);
                    x= Faker.RandomNumber.Next(1, 5);
                }


                foreach (Stock sto in list)
                {
                    context.Add(sto);
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
                list.Add(new StatusCommand("Validé"));
                
                

                foreach (StatusCommand stat in list)
                {
                    context.Add(stat);
                    context.SaveChanges();
                }
            }
        }
    }
}
