using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestForInterView.Model.Entity;
using TestForInterView.Repository.Interface;

namespace TestForInterView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectInterface _subject;

        public SubjectController(ISubjectInterface _subject)
        {
            this._subject = _subject;
        }
        [HttpPost("CreateSubject")]
        public async Task<ActionResult> CreateSubject(Subject subject)
        {
            await _subject.CreateSubject(subject);
            return CreatedAtAction("GetSubjects", new { id = subject.Sid }, subject);
        }
        [HttpGet("GetSubjects")]
        public async Task<ActionResult> GetSubjects()
        {
            return Ok(await _subject.GetSubjects());
        }
        
    }
}
