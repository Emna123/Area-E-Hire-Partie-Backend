using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Models
{
    public class UploadFile
    {
        public IFormFile file { get; set; }
        public string useremail { get; set; }

    }
}
