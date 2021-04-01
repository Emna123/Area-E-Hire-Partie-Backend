using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Responsable_RH
    {
       

        [Key]
        public int id_resp { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public String e_mail { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public String mdp { get; set; }
        [Column]
         public int code { get; set; }
    }
}
