using ArsentyevaMashaKT3121.Database;
using ArsentyevaMashaKT3121.Filters.TeacherFilters;
using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System.Threading;

namespace ArsentyevaMashaKT3121.Interfaces.TeachersInterfaces
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments(DepartmentFilter filter); // Объявление метода в интерфейсе
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly TeacherDbContext _dbContext;

        public DepartmentService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Department> GetDepartments(DepartmentFilter filter)
        {
            var query = _dbContext.Department
                .Include(d => d.DepartmentHeadId) // Загрузка заведующего кафедрой
                .Include(d => d.Teachers) // Загрузка преподавателей
                .AsQueryable();

            // Фильтрация по количеству преподавателей
            if (filter.MinTeachers.HasValue)
                query = query.Where(d => d.Teachers.Count >= filter.MinTeachers.Value);

            if (filter.MaxTeachers.HasValue)
                query = query.Where(d => d.Teachers.Count <= filter.MaxTeachers.Value);

            return query.ToList();

            /*// Фильтрация по дате основания
            if (filter.FoundedAfter.HasValue)
                query = query.Where(d => d.FoundationDate >= filter.FoundedAfter.Value);

            if (filter.FoundedBefore.HasValue)
                query = query.Where(d => d.FoundationDate <= filter.FoundedBefore.Value);*/

        }
    }
}
