using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class Examen
    {
        [Key]
        public int id { get; set; }
        public int nbr_questions { get; set; }
        public double duree { get; set; }
        public virtual Offre Offre { get; set; }
        public int id_offre { get; set; }
        public virtual ICollection<Result_Examen> examenresults { get; set; }
        public virtual ICollection<Note_Question> notes_questions { get; set; }


    }
}
