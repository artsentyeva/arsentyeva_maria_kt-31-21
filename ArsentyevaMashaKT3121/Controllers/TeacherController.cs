/*using ArsentyevaMashaKT3121.Filters.TeacherFilters;
using ArsentyevaMashaKT3121.Interfaces.TeachersInterfaces;
using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ArsentyevaMashaKT3121.ServiceExtensions
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly ITeacherService _teacherService;

        public TeacherController(ILogger<TeacherController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost(Name = "GetTeachersByDepartment")]
        public async Task<IActionResult> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = )
        {
            var teachers = await _teacherService.GetTeachersByDepartmentAsync(filter, cancellationToken);

            return Ok(teachers);
        }
    }
}
*/