using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Note_Question
    {
        [Key]
        public int id { get; set; }
        //public double note_obtenue { get; set; }
        //public virtual  Candidat candidat { get; set; }
        public virtual Examen examen { get; set; }
        public virtual Question question { get; set; }
    }
}
