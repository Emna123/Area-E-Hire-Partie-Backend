using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Question
    {
        [Key]
        public int id { get; set; }
        public string question { get; set; }
        public double note { get; set; }
        public virtual ICollection<Note_Question> notes_questions { get; set; }
        public virtual ICollection<Reponse> reponses { get; set; }

        //public virtual Examen examen { get; set; }

    }
}
