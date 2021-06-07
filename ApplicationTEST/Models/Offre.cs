using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{

    public class Offre
    {

        private readonly ILazyLoader _lazyLoader;
       /* public Offre()
        {

        }
        public Offre(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }*/
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
        public string niveau_pro { get; set; }
        public Boolean archiver { get; set; }

        public virtual ICollection<Candidature> Candidature { get; set; }
        public virtual ICollection<Competence> Competence { get; set; }
        public virtual ICollection<Langue> Langue { get; set; }
        public virtual ICollection<Diplome> Diplome { get; set; }
        public virtual ICollection<Questionnaire> Questionnaire { get; set; }
        public virtual Examen Examen { get; set; }

        /*   private ICollection<Candidature> _Candidature;
           public ICollection<Candidature> Candidature
           {
               get => _lazyLoader.Load(this, ref _Candidature);
               set => _Candidature = value;
           }

           */
        /* private ICollection<Competence> _Competence;
         public ICollection<Competence> Competence
         {
             get => _lazyLoader.Load(this, ref _Competence);
             set => _Competence = value;
         }
         private ICollection<Langue> _Langue;
         public ICollection<Langue> Langue
         {
             get => _lazyLoader.Load(this, ref _Langue);
             set => _Langue = value;
         }
         private ICollection<Diplome> _Diplome;
         public ICollection<Diplome> Diplome
         {
             get => _lazyLoader.Load(this, ref _Diplome);
             set => _Diplome = value;
         }
         private ICollection<Questionnaire> _Questionnaire;
         public ICollection<Questionnaire> Questionnaire
         {
             get => _lazyLoader.Load(this, ref _Questionnaire);
             set => _Questionnaire = value;
         }*/


    }
}