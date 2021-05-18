using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace ApplicationTEST.Models
{
    public class Candidat:IdentityUser
    {
        //[Key]
       // public long Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string password { get; set; }
        public string CVname { get; set; }
        public string CVoriginalfilename { get; set; }
        public string genre { get; set; }
        public string metier { get; set; }
        public string etat_matrimonial { get; set; }  
        public string Photo { get; set; }
        public string adresse { get; set; }
        public string date_naissance { get; set; }
        public string description { get; set; }
        //public virtual Generer generer {get; set;} 
        public  ICollection<Langue>langues { get;set; }
        public ICollection<Experience_prof> experiences { get; set; }
        public ICollection<Competence> competences { get; set; }
        public ICollection<Hobby> hobbies { get; set; }
        public ICollection<Formation> formations { get; set; }
        public ICollection<Candidature> candidatures { get; set; }
        public Linkedin linkedin { get; set; }
        //public int  GenererId  {get; set;}   


    }
}
