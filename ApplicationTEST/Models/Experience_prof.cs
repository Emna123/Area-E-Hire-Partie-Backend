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
        [Column(TypeName = "varchar")]
        public String poste_occupe { get; set; }
        [Column(TypeName = "varchar")]
        public String lieu_Exp { get; set; }
        [Column]
        public DateTime date_debut { get; set; }
        [Column]
        public DateTime date_fin { get; set; }
        [Column(TypeName = "varchar")]
        public String description { get; set; }
         public Generer generer {get; set;}   
    }
}
