using ArsentyevaMashaKT3121.Filters.TeacherFilters;
using ArsentyevaMashaKT3121.Interfaces.TeacherInterfaces;
using Microsoft.AspNetCore.Mvc;


namespace ArsentyevaMashaKT3121.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TeacherController: ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("GetTeachers")]
        public IActionResult GetTeachers([FromBody] TeacherFilter filter)
        {
            var teachers = _teacherService.GetTeachers(filter);
            return Ok(teachers);
        }
    }
}
