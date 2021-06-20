using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class User : IdentityUser
    {
        //[Key]
        // public long Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string password { get; set; }
        public string CVname { get; set; }
        public string CVoriginalfilename { get; set; }
        public string Photo { get; set; }
        //  public Boolean archiver { get; set; }

        public DateTime date_naissance { get; set; }
        public string etat_matrimonial { get; set; }
        public string adresse { get; set; }
        public string metier { get; set; }
        //public  Generer generer {get; set;}
        public string genre { get; set; }
        public string description { get; set; }
        public virtual Generer generer { get; set; }
        public virtual ICollection<Langue> Langue { get; set; }
        public virtual ICollection<Experience_prof> Experience_prof { get; set; }
        public virtual ICollection<Competence> Competence { get; set; }
        public virtual ICollection<Hobby> Hobby { get; set; }
        public virtual ICollection<Formation> Formation { get; set; }
        public virtual ICollection<Candidature> candidatures { get; set; }
        public virtual ICollection<Commentaire> Commentaire { get; set; }
        public virtual ICollection<Result_Examen> examenresults { get; set; }
        public virtual Linkedin linkedin { get; set; }
        //public int  GenererId  {get; set;}   
    }
}
