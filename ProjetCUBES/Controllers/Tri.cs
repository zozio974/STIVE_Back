using Bogus;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetCUBES.Model;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using static ProjetCUBES.Helpers.Class;
namespace ProjetCUBES.Controllers
{


    [ApiController]
    [Route("[controller]/[action]")]

    public class Tri
    {


        [HttpGet]
        public List<Article> displayarticlebyfamily(int ID)
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.Where(x => x.IdFamily == ID).ToList();
                return article;
            }
        }
        [HttpGet]

        public List<Article> displayarticlebySupplier(int ID)
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.Where(x => x.IdProvider == ID).ToList();
                return article;
            }
        }
    }
}
