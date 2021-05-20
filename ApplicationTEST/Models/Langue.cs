using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Langue
    {
        [Key]
        public int id {get;set;}
        public string langue { get; set; }
        public string niveau { get; set; }
        public virtual Candidat candidat { get; set; }
        public virtual Offre offre { get; set; }
        public Boolean require { get; set; }

    }
}
