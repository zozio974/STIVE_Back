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
    public class Connect
    {
        [HttpGet]
        public bool connectcust(string? username = "", string? password = "")
        {
            using (Apply context = new Apply())
            {
                List<Customer> listcust = context.Customers.Where((x => x.LogInCus == username)).ToList();
                if (listcust.Any() == false)
                {
                    return false;
                }
                Customer cust = context.Customers.Where((x => x.LogInCus == username)).First();
                if (cust.PassWordCus != password)
                {
                    return false;
                }
                return true;
            }
        }
        [HttpGet]
        public bool connectemp(string? username = "", string? password = "")
        {
            using (Apply context = new Apply())
            {
                List<Employer> listemp = context.Employers.Where((x => x.LogInEmp == username)).ToList();
                if (listemp.Any() == false)
                {
                    return false;
                }
                Employer emp = context.Employers.Where((x => x.LogInEmp == username)).First();
                if (emp.PassWordEmp != password)
                {
                    return false;
                }
                return true;
            }
        }

    }
}
