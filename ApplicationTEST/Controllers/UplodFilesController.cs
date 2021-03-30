using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationTEST.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationTEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplodFilesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;



        public UplodFilesController(IWebHostEnvironment webHostEnvironment, TodoContext context, UserManager<Candidat> userManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            this.userManager = userManager;

        }


        // POST api/<UplodFilesController>
        [HttpPost]
        [Consumes("multipart/form-data")]

        [Route("Upload")]
        public async Task<IActionResult> Post([FromForm] UploadFile objectfile) 
        {
            try
            {
                if (objectfile.file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //string.Format(@"{0}.txt", Guid.NewGuid())
                    string nnn = Path.GetFileNameWithoutExtension(objectfile.file.FileName);
                    nnn = string.Format(@"{0}.pdf", Guid.NewGuid());
                    var sss = Path.GetExtension(objectfile.file.FileName);
                    var newname = string.Format(@"{0}.pdf", Guid.NewGuid());
                    using (FileStream fileStream = System.IO.File.Create(path +newname))
                    {
                        objectfile.file.CopyTo(fileStream);
                        fileStream.Flush();
                        var user = await userManager.FindByEmailAsync(objectfile.useremail);
                        Console.WriteLine("aaaaaaaaaa!!!!!!!!!!!!!!!!!!!!!!!!!!"+user.nom);
                        user.CVname = newname;
                        user.CVoriginalfilename = objectfile.file.FileName;
                         _context.Entry(user).State = EntityState.Modified;
                         await _context.SaveChangesAsync();
                         return  Ok(new Response { message = "File uploaded !", status = newname,
                             extrafield = objectfile.file.FileName
                         });
                    }
                }
                else
                {
                    return Ok(new Response
                    {
                        message="you have to choose a file first !"
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
      
    }
}
