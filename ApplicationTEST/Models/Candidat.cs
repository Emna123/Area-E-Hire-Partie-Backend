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
        public string key { get; set; }
        public virtual Generer generer {get; set;} 
        //public int  GenererId  {get; set;}   


    }
}
