using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class RefreshToken
    {
        [Key]
        public int id { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }
        public virtual Candidat candidat { get; set; }
        

    }
}
