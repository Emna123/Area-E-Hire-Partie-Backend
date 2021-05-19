using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationTEST.Models
{
    public class Commentaire
    {
        [Key]
        public int id { get; set; }
        public string commentaire { get; set; }
        public DateTime date { get; set; }
        public Candidat candidat { get; set; }
    }
}
