using ExamService.Models;
using ExamService.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExamService.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        private readonly ExamRepository _examRepository;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public ExamController(ExamRepository examRepository)
        {
            _examRepository = examRepository;

        }
        // GET: api/Exam
        [HttpGet]
        public ActionResult<List<Exam>> Get()
        {
            //HttpResponse currentResponse = _httpContextAccessor.HttpContext.Response;
            //var currentRequestOrigin = HttpContext.Request.Headers["Origin"].ToString();
            //if (currentRequestOrigin != null)
            //{
            //    currentResponse.Headers.Add("Access-Control-Allow-Origin", currentRequestOrigin);
            //}
            return _examRepository.Get();
        }


        // GET: api/Exam/5
        [HttpGet("{id}", Name = "GetExam")]
        public ActionResult<Exam> Get(string examKey)
        {
            var exam = _examRepository.Get(examKey);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        /// <summary>
        /// Creates Exam in the Exam Database
        /// </summary>
        /// <param name="exam">Exam that is to be created</param>
        /// <returns>Returns the created Exam Object</returns>
        ///<remarks>Exam Key need not be sent as the DB can Auto Generate it
        ///</remarks>
        [HttpPost]
        public ActionResult<Exam> Create(Exam exam)
        {
            _examRepository.Create(exam);

            return CreatedAtRoute("GetExam", new { ExamKey = exam.ExamKey.ToString() }, exam);
        }

        /// <summary>
        /// Updates an Exam by passing the Exam Key along with the newly changed Exam
        /// </summary>
        /// <param name="examKey">ExamKey of the Exam to be updated</param>
        /// <param name="exam">Updated Exam</param>
        /// <returns>Returns the Updated Exam</returns>
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string examKey, Exam exam)
        {
            var examTemp = _examRepository.Get(examKey);

            if (examTemp == null)
            {
                return NotFound();
            }

            _examRepository.Update(examKey, exam);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string examKey)
        {
            var exam = _examRepository.Get(examKey);

            if (exam == null)
            {
                return NotFound();
            }

            _examRepository.Remove(exam.ExamKey);
            return NoContent();
        }
    }
}
