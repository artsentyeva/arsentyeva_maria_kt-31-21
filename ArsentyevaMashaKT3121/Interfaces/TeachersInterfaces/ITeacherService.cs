/*using ArsentyevaMashaKT3121.Database;
using ArsentyevaMashaKT3121.Filters.TeacherFilters;
using ArsentyevaMashaKT3121.Models;
using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System.Threading;

namespace ArsentyevaMashaKT3121.Interfaces.TeachersInterfaces
{
    public interface ITeacherService
    {

    }
    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher[]> GetTeacherByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>.Where(w => w.Department.DepartmentId == filter.DepartmentId).ToArrayAsync(cancellationToken);


            return teachers;
        }
    }
}
*/