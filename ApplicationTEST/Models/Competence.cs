using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Competence
    {
        [Key]
        public int id { get; set; }
        public string titre { get; set; }
        public string niveau { get; set; }
        public int value { get; set; }
        public virtual Candidat candidat { get; set; }
        public Boolean require { get; set; }
        public virtual Offre offre { get; set; }

    }
}
