using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Questionnaire
    {
        [Key]
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public Offre offre { get; set; }
        public Boolean require { get; set; }

    }
}
