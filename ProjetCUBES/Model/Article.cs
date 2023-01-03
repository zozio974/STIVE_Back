using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Required]
        public string Ladder { get; set; }

        public Article() { }

        public Article(string nameArticle, int idProvider, int dateFill, int idFamily,double pricesup, double price, int volume, int degree, string grape, string ladder)
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
        }



       



    }
}