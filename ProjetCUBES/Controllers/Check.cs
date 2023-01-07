﻿using Bogus;
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
    public class Check
    {
        [HttpGet]
        public bool checksupplierexist(int a)
        {
            using (Apply context = new Apply())
            {
                List<Article> listart = context.Articles.Where((x => x.IdProvider == a)).ToList();
                if (listart.Any() == false)
                {
                    return false;
                }             
                return true;
            }

                
        }
        [HttpGet]
        public bool checkfamilyexist(int a)
        {
            using (Apply context = new Apply())
            {
                List<Article> listart = context.Articles.Where((x => x.IdFamily == a)).ToList();
                if (listart.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }
        [HttpGet]
        public bool checkjobexist(int a)
        {
            using (Apply context = new Apply())
            {
                List<Employer> listemp = context.Employers.Where((x => x.Idjob == a)).ToList();
                if (listemp.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }
        [HttpGet]

        public bool articlebynameexist(string name)
        {
            using (Apply context = new Apply())
            {
                List<Article> article = context.Articles.Where(x => x.NameArticle == name).ToList();
                if (article.Any() == false)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
