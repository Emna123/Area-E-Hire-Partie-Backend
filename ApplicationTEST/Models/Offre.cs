using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Offre
    {
        [Key]
        public int id { get; set; }
        public string titre { get; set; }
        public string type_offre { get; set; }
        public string type_contrat { get; set; }
        public string lieu_travail { get; set; }
        public string nbr_poste { get; set; }
        public string annee_exp { get; set; }
        public string description { get; set; }
        public string date_publication { get; set; }
        public string date_expiration { get; set; }
        public ICollection<Diplome> diplomes { get; set; }
        public ICollection<Langue> langues { get; set; }
        public ICollection<Competence> competences { get; set;}
        public ICollection<Candidature> candidatures { get; set; }


    }
}
