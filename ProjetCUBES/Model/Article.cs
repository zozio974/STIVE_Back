using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetCUBES.Model
{
    public class Article
    {
        [Key]
        public int ID_Article { get; set; }
        [Required]
        public string NameArticle { get; set; }
        [Required]
        public int IdProvider { get; set; }
        [Required]
        public int DateFill { get; set; }
        [Required]
        public int IdFamily { get; set; }
        [Required]
        public double PriceSup { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        public int Degree { get; set; }
        [Required]
        public string Grape { get; set; }
       
        public string Ladder { get; set; }
        [Required]
        public int StockActual { get; set; }
        [Required]
        public int StockProv { get; set; }
        [Required]
        public int StockMin { get; set; }

        public Article() { }

        public Article(string nameArticle, int idProvider, int dateFill, int idFamily,double pricesup, double price, int volume, int degree, string grape, string ladder,int stockactual,int stockprov,int stockmin)
        {
            NameArticle = nameArticle;
            IdProvider = idProvider;
            DateFill = dateFill;
            IdFamily = idFamily;
            PriceSup = pricesup;
            Price = price;
            Volume = volume;
            Degree = degree;
            Grape = grape;
            Ladder = ladder;
            StockActual = stockactual;
            StockProv = stockprov;
            StockMin = stockmin;
        }



       



    }
}