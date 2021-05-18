using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationTEST.Models
{
    public class Experience_prof
    {
        [Key]
        public int id_ex { get; set; }
        public string poste_occupe { get; set; }
        public string lieu_Exp { get; set; }
        [Column]
        public string date_debut { get; set; }
        [Column]
        public string employeur { get; set; }
        [Column]
        public string date_fin { get; set; }
        [Column]
        public string typeEmploi { get; set; }
        [Column(TypeName = "varchar")]
        public string description { get; set; }
        public Generer generer {get; set;}
        public Candidat candidat { get; set; }

    }
}
