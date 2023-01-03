using System.ComponentModel.DataAnnotations;

namespace ProjetCUBES.Model
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Supplier() { } 
        
        public Supplier(string name)
        {
            Name= name;
        }

    }
}
