using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ApplicationTEST.Models
{
    public class Candidat:IdentityUser
    {
        //[Key]
        // public long Id { get; set; }
        private readonly ILazyLoader _lazyLoader;
        public Candidat()
        {
           
        }
        public Candidat(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public string nom { get; set; }
        public string prenom { get; set; }
        public string password { get; set; }
        public string CVname { get; set; }
        public string CVoriginalfilename { get; set; }
        public string Photo { get; set; }
        public Boolean archiver { get; set; }

        public DateTime date_naissance { get; set; }
        public string etat_matrimonial { get; set; }
        public string adresse { get; set; }
        public string metier { get; set; }
        //public  Generer generer {get; set;}

        /*  private ICollection<Candidature> _Candidature;
          public ICollection<Candidature> Candidature
          {
              get => _lazyLoader.Load(this, ref _Candidature);
              set => _Candidature = value;
          }
          private ICollection<Langue> _Langue;
          public ICollection<Langue>  Langue {
              get => _lazyLoader.Load(this, ref _Langue);
              set => _Langue = value;
          }


          private ICollection<Experience_prof> _Experience_prof;
          public ICollection<Experience_prof> Experience_prof {
              get => _lazyLoader.Load(this, ref _Experience_prof);
              set => _Experience_prof = value;
          }


          private ICollection<Competence> _Competence;
          public  ICollection<Competence> Competence
          {
              get => _lazyLoader.Load(this, ref _Competence);
              set => _Competence = value;
          }


         private ICollection<Hobby> _Hobby;
          public ICollection<Hobby> Hobby
          {
              get => _lazyLoader.Load(this, ref _Hobby);
              set => _Hobby = value;
          }

          private ICollection<Formation> _Formation;
          public ICollection<Formation> Formation
          {
              get => _lazyLoader.Load(this, ref _Formation);
              set => _Formation = value;
          }
          public ICollection<Commentaire> _Commentaire;
          public ICollection<Commentaire> Commentaire
          {
              get => _lazyLoader.Load(this, ref _Commentaire);
              set => _Commentaire = value;
          }*/

        public string genre { get; set; }
        public string description { get; set; }
        public virtual Generer generer {get; set;} 
        public virtual ICollection<Langue> Langue { get;set; }
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
