using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Responsable_RH : IdentityUser
    {



        public string key { get; set; }
        public String mdp { get; set; }
        public int code { get; set; }
    }
}
