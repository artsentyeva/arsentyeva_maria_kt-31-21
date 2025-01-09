using ArsentyevaMashaKT3121.Filters.TeacherFilters;
using ArsentyevaMashaKT3121.Interfaces.TeachersInterfaces;
using Microsoft.AspNetCore.Mvc;
using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using ArsentyevaMashaKT3121.ServiceExtensions;

namespace ArsentyevaMashaKT3121.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

            [HttpPost("GetDepartments")]
            public IActionResult GetDepartments([FromBody] DepartmentFilter filter)
            {
                var departments = _departmentService.GetDepartments(filter);
                return Ok(departments);
            }
        }
}
