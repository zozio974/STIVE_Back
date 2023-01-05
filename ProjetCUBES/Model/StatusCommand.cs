using System.ComponentModel.DataAnnotations;

namespace ProjetCUBES.Model
{
    public class StatusCommand
    {
        [Key]
        public int Id_StatusCommand { get; set; }
        [Required]
        public string Name { get; set; }
        
        public StatusCommand() { }
        public StatusCommand(string name)
        {
            Name = name;
        }
        
    }
}
