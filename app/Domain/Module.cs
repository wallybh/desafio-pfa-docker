using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafio_docker.Domain
{
    [Table("modules")]
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Module(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public Module()
        {

        }
    }
}