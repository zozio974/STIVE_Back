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
        [HttpPut]
        public void commandeauto_off()
        {
            using (Apply context = new Apply())
            {
                Auto auto = context.Autos.Where(x => x.ID_Auto == 1).First();
                auto.AutoRefill=0;
                context.Update(auto);
                context.SaveChanges();
            }
        }

        [HttpPut]
        public void commandeauto_on()
        {
            using (Apply context = new Apply())
            {
                Auto auto = context.Autos.Where(x => x.ID_Auto == 1).First();
                auto.AutoRefill = 1;
                context.Update(auto);
                context.SaveChanges();
            }
        }

        [HttpPut]
        public void quantiteaddtostock(int y)
        {
            using (Apply context = new Apply())
            {
                Auto auto = context.Autos.Where(x => x.ID_Auto == 1).First();
                auto.AddToStock = y;
                context.Update(auto);
                context.SaveChanges();
            }
        }


    }
}
