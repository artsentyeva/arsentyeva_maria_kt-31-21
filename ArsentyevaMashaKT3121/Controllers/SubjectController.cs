using ArsentyevaMashaKT3121.Models;
using ArsentyevaMashaKT3121.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ArsentyevaMashaKT3121.Interfaces.SubjectInterfaces;

namespace ArsentyevaMashaKT3121.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // Получить все дисциплины
        [HttpGet("GetAllSubjects")]
        public IActionResult GetAllSubjects()
        {
            var subjects = _subjectService.GetAllSubjects();
            return Ok(subjects);
        }

        // Добавить дисциплину
        [HttpPost("AddSubject")]
        public IActionResult AddSubject([FromBody] Subject subject)
        {
            _subjectService.AddSubject(subject);
            return Ok(new { message = "Subject added successfully" });
        }

        // Обновить дисциплину
        [HttpPut("UpdateSubject/{subjectId}")]
        public IActionResult UpdateSubject(int subjectId, [FromBody] Subject updatedSubject)
        {
            _subjectService.UpdateSubject(subjectId, updatedSubject);
            return Ok(new { message = "Subject updated successfully" });
        }

        // Удалить дисциплину
        [HttpDelete("DeleteSubject/{subjectId}")]
        public IActionResult DeleteSubject(int subjectId)
        {
            _subjectService.DeleteSubject(subjectId);
            return Ok(new { message = "Subject deleted successfully" });
        }
    }
}
