using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Reponse
    {
        [Key]
        public int id { get; set; }
        public string reponse { get; set; }
        public Boolean correcte { get; set; }
        public virtual Question question { get; set; }

    }
}
