using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Result_Examen
    {
        [Key]
        public int id { get; set; }
        public DateTime date_result { get; set; }
        public double note_totale { get; set; }
        public DateTime date_expiration  { get; set; }
        public Boolean passed  { get; set; }
        public virtual Candidat candidat { get; set; }
        public virtual Examen examen { get; set; }
    }
}
