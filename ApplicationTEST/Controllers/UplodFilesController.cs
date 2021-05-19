using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ApplicationTEST.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationTEST.Controllers
{

    [Authorize]

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
                    using (FileStream fileStream = System.IO.File.Create(path + newname))
                    {
                        objectfile.file.CopyTo(fileStream);
                        fileStream.Flush();

                        var user = await userManager.FindByEmailAsync(objectfile.useremail);
                        var user = await userManager.FindByIdAsync(objectfile.useremail);
                        Console.WriteLine("aaaaaaaaaa!!!!!!!!!!!!!!!!!!!!!!!!!!" + user.nom);
                        user.CVname = newname;
                        user.CVoriginalfilename = objectfile.file.FileName;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return Ok(new Response
                        {
                            message = "File uploaded !",
                            status = newname,
                            extrafield = objectfile.file.FileName
                        });
                    }
                }
                else
                {
                    return Ok(new Response
                    {
                        message = "you have to choose a file first !"
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getUplodedCV(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                string filename = user.CVname;
                string original = user.CVoriginalfilename;
                if(original==null || filename == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new
                    {
                        filename = filename,
                        original = original
                    });
                }   
            }
            else
            {
                return NotFound();
            }
           
        }
        [HttpDelete("{id}")]
        [Route("DeleteUploadedCV")]
        public async Task<IActionResult> deleteUplodedCV(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            if (user != null)
            {
                if (System.IO.File.Exists(Path.Combine(path, user.Photo)))
                {
                    // If file found, delete it    
                    System.IO.File.Delete(Path.Combine(path, user.CVname));
                    Console.WriteLine("File deleted.");
                }
                user.CVname = null;
                user.CVoriginalfilename = null;
                await _context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        message = "CV supprimmé avec succée  !!!"
                    });

            }
            return NotFound();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("UploadPhoto")]
        public async Task<IActionResult> PostPhoto([FromForm] UploadFile objectfile)
        {
            try
            {
                if (objectfile.file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\images\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //string.Format(@"{0}.txt", Guid.NewGuid())
                    string nnn = Path.GetFileNameWithoutExtension(objectfile.file.FileName);
                    var sss = Path.GetExtension(objectfile.file.FileName);
                    nnn = string.Format(@"{0}"+sss, Guid.NewGuid());

                    var newname = string.Format(@"{0}"+sss, Guid.NewGuid());
                    using (FileStream fileStream = System.IO.File.Create(path + newname))
                    {
                        objectfile.file.CopyTo(fileStream);
                        fileStream.Flush();
                        var user = await userManager.FindByEmailAsync(objectfile.useremail);
                        Console.WriteLine("aaaaaaaaaa!!!!!!!!!!!!!!!!!!!!!!!!!!" + user.nom);
                        user.Photo = newname;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return Ok(new Response
                        {
                            message = "File uploaded !",
                            status = newname,
                            extrafield = objectfile.file.FileName
                        });

                    }
                }
                else
                {
                    return Ok(new Response
                    {
                        message = "you have to choose a file first !"
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getUplodedCV(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                string filename = user.CVname;
                string original = user.CVoriginalfilename;
                if(original==null || filename == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new
                    {
                        filename = filename,
                        original = original
                    });
                }   
            }
            else
            {
                return NotFound();
            }
           
        }
        [HttpDelete("{id}")]
        [Route("DeleteUploadedCV")]
        public async Task<IActionResult> deleteUplodedCV(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            if (user != null)
            {
                if (System.IO.File.Exists(Path.Combine(path, user.CVname)))
                {
                    // If file found, delete it    
                    System.IO.File.Delete(Path.Combine(path, user.CVname));
                    Console.WriteLine("File deleted.");
                }
                user.CVname = null;
                user.CVoriginalfilename = null;
                await _context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        message = "CV supprimmé avec succée  !!!"
                    });

            }
            return NotFound();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("UploadPhoto")]
        public async Task<IActionResult> PostPhoto([FromForm] UploadFile objectfile)
        {
            try
            {
                if (objectfile.file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\images\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //string.Format(@"{0}.txt", Guid.NewGuid())
                    string nnn = Path.GetFileNameWithoutExtension(objectfile.file.FileName);
                    var sss = Path.GetExtension(objectfile.file.FileName);
                    nnn = string.Format(@"{0}"+sss, Guid.NewGuid());

                    var newname = string.Format(@"{0}"+sss, Guid.NewGuid());
                    using (FileStream fileStream = System.IO.File.Create(path + newname))
                    {
                        objectfile.file.CopyTo(fileStream);
                        fileStream.Flush();
                        var user = await userManager.FindByIdAsync(objectfile.useremail);
                        Console.WriteLine("aaaaaaaaaa!!!!!!!!!!!!!!!!!!!!!!!!!!" + user.nom);
                        user.Photo = newname;
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return Ok(new Response
                        {
                            message = "File uploaded !",
                            status = newname,
                            extrafield = objectfile.file.FileName
                        });
                    }
                }
                else
                {
                    return Ok(new Response
                    {
                        message = "you have to choose a file first !"
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("getUploadPhoto/{id}")]

        public async Task<IActionResult> getUplodedPhoto(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                string photo = user.Photo;
                if (photo != null)
                {
                    return Ok(new
                    {
                        photo = photo
                    });
                }
                else
                {
                    return NotFound();
                }                      
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("DeleteUploadedPhoto/{id}")]
        public async Task<IActionResult> deleteUplodedPhoto(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            string path = _webHostEnvironment.WebRootPath + "\\images\\";
                if (user != null)
                if (user != null && user.Photo != null)
                {
                if (System.IO.File.Exists(Path.Combine(path, user.Photo)))
                {
                    // If file found, delete it    
                    System.IO.File.Delete(Path.Combine(path, user.Photo));
                    Console.WriteLine("File deleted.");
                }
                user.Photo = null;
                await _context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        message = "photo supprimée avec succée  !!!"
                    });
                }
            return NotFound();
        }
    }
}
