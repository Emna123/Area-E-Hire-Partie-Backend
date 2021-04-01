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
        public int id_formation { get; set; }
        [Column(TypeName = "varchar")]
        public String diplome { get; set; }
        [Column(TypeName = "varchar")]
        public String universite { get; set; }
        [Column]
        public DateTime date_debut { get; set; }
        [Column]
        public DateTime date_fin { get; set; }
        public Generer generer {get; set;}   
    }
}
