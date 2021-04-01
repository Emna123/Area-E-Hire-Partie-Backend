using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationTEST.Models
{
    public class Generer
    {
        [Key]
        public int id_generer { get; set; }
        [Column(TypeName = "varchar")]
        public String poste_domande { get; set; }
        [Column(TypeName = "varchar")]
        public String domaine_activite { get; set; }
        [Column(TypeName = "varchar")]
        public String photo_profil { get; set; }
        [Column]
        public double salaire_min { get; set; }
        public List<Formation> formations { get; set; } 
       public List<Experience_prof> experience_profs { get; set; } 
         public Candidat candidat {get; set;}   


        
            }
}
