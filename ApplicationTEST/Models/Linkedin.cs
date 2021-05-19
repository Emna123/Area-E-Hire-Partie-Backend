using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ApplicationTEST.Models
{
    public class Linkedin
    {
        [Key]
        public int id { get; set; }
        public string linkedin { get; set; }
        public Candidat candidat { get; set; }
        public string id_candidat { get; set; }
    }
}
