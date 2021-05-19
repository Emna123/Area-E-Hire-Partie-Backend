using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationTEST.Models
{
    public class Formation
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "varchar")]
        public string diplome { get; set; }
        [Column(TypeName = "varchar")]
        public string universite { get; set; }
        [Column]
        public DateTime annee_debut { get; set; }
        [Column]
        public DateTime annee_fin { get; set; }
        public string annee_debut { get; set; }
        [Column]
        public string annee_fin { get; set; }
        public string description { get; set; }
        public Candidat candidat { get; set; }
        public Generer generer {get; set;}   
    }
}
