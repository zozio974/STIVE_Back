using System.ComponentModel.DataAnnotations;

namespace ProjetCUBES.Model
{
    public class Job
    {
        [Key]
        public int ID_Job { get; set; }
        [Required]
        public string JobName{ get; set; }

        public Job() { }
        public Job(string jobName)
        {
            JobName = jobName;
        }
    }
}
