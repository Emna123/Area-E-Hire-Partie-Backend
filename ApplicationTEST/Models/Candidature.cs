using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Candidature
    {
        [Key]
        public int id { get; set; }
        public string etat { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string date_candidature { get; set; }
        public string lettre_motivation { get; set; }
        public string salaire_demande { get; set; }
        public Candidat candidat { get; set; }
        public Offre offre { get; set; }
    }

}
