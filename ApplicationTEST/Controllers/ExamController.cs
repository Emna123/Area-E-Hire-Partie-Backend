using ApplicationTEST.Models;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationTEST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;

        public ExamController(UserManager<Candidat> userManager, TodoContext context)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: api/<ExamController>
        [Route("getExam/{idcandidature}/{idexam}")]
        [HttpPost]
        public async Task<IActionResult> verifExam([FromBody] Response res, int idcandidature, int idexam)
        {
            Console.WriteLine(res.extrafield);
            var user = await userManager.FindByIdAsync(res.extrafield);
            var exam = await _context.Examens.FindAsync(idexam);
            var candidature = await _context.Candidatures.FindAsync(idcandidature);
            if (user != null && exam != null && candidature != null)
            {
                var passesExam = user.examenresults.Where(x => x.candidat.Id == user.Id && x.examen.id == exam.id).FirstOrDefault();

                if (candidature.candidat.Id == user.Id && passesExam != null)
                {
                    if (candidature.etat.ToLower() == "présélectionné" &&
                        passesExam.passed == false && passesExam.date_expiration > DateTime.Now)
                    {
                        List<Note_Question> randomArray = new List<Note_Question>();
                        List<int> indexarray = new List<int>();
                        Console.WriteLine("Length notequestion ;" + exam.notes_questions.Count);
                        while (exam.nbr_questions > indexarray.Count)
                        {
                            Random random = new Random();
                            var randomIndex = random.Next(0, exam.notes_questions.Count);
                            Console.WriteLine("randomIndex" + randomIndex);
                            if (indexarray.Contains(randomIndex))
                            {
                                Console.WriteLine("existe deja  ;");
                            }
                            else
                            {
                                indexarray.Add(randomIndex);
                            }
                        }
                        Console.WriteLine("index array length :" + randomArray.Count);
                        for (int j = 0; j < indexarray.Count; j++)
                        {
                            randomArray.Add(exam.notes_questions.ElementAt(indexarray[j]));
                        }
                        Console.WriteLine("random array length :" + randomArray.Count);
                        return Ok(new
                        {
                            exam,
                            randomArray
                        });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "etat candidature not allowed or exam expired or exam has been passed !!", status = "Error 500 !!" });
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "candidarure not for you !", status = "Error 500 !!" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Something went wrog , candidat or candidature or exam not found!", status = "Error 500 !!" });
            }
        }

        [Route("setPassedExam/{idexam}/{idcandidat}")]
        [HttpPut]
        public async Task<IActionResult> setPassedExam(string idcandidat, int idexam)
        {
                try
                {
                    var user = await userManager.FindByIdAsync(idcandidat);
                    var passedExam = user.examenresults.Where(x => x.candidat.Id == idcandidat && x.examen.id == idexam)
                                             .FirstOrDefault();
                    passedExam.passed = true;
                    _context.SaveChanges();
                    return Ok(new{msg= "exam result updated succefully !"});
                }
                catch
                {
                    return NotFound();
                }
        }

        [Route("addExamenResult/{idexam}/{idcandidat}/{etat}")]
        [HttpPut]
        public async Task<IActionResult> addPassedExam([FromBody] Result_Examen resexam,string idcandidat, int idexam,string etat)
        {
            try
            {
                var user = await userManager.FindByIdAsync(idcandidat);
                var passedExam = user.examenresults.Where(x => x.candidat.Id == idcandidat && x.examen.id == idexam)
                                         .FirstOrDefault();
                var candidature = user.candidatures.Where(c => c.id == resexam.id).FirstOrDefault();
                candidature.etat = etat;
                passedExam.date_result =  DateTime.Now;
                passedExam.note_totale = resexam.note_totale;
                passedExam.passed = true;
                _context.SaveChanges();
                return Ok(new { msg = "exam result added succefully !" });
            }
            catch
            {
                return NotFound();
            }
        }

    }
}

    
