using System.ComponentModel.DataAnnotations;

namespace ProjetCUBES.Model
{
    public class Stock
    {

        [Key]
        public int ID_Stock { get; set; }
        [Required]
        public int IdArticle { get; set; }
        [Required]
        public int StockActual { get; set;}
        [Required]
        public int StockProv { get; set; }
        [Required]
        public int StockMin { get; set; }       
        public Stock() { }
        public Stock(int idarticle,int stockactual,int stockprov, int stockmin)
        {
            IdArticle= idarticle;
            StockActual = stockactual;
            StockProv = stockprov;
            StockMin = stockmin;
            
        }
        
    }
}
