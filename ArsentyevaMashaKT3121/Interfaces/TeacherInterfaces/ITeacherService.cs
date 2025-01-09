using ArsentyevaMashaKT3121.Database;
using ArsentyevaMashaKT3121.Filters.TeacherFilters;
using ArsentyevaMashaKT3121.Models;
using Microsoft.EntityFrameworkCore;


namespace ArsentyevaMashaKT3121.Interfaces.TeacherInterfaces
{
    public interface ITeacherService
    {
        List<Teacher> GetTeachers(TeacherFilter filter); // Метод для получения списка преподавателей
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Teacher> GetTeachers(TeacherFilter filter)
        {
            var query = _dbContext.Teacher
                .Include(t => t.Department) // Подгружаем кафедру
                .AsQueryable();

            // Фильтрация по кафедре
            if (filter.DepartmentId.HasValue)
            {
                query = query.Where(t => t.DepartmentId == filter.DepartmentId.Value);
            }

            // Фильтрация по учёной степени
            if (filter.AcademicDegreeId.HasValue)
            {
                query = query.Where(t => t.AcademicDegreeId == filter.AcademicDegreeId.Value);
            }

            // Фильтрация по должности
            if (filter.PositionId.HasValue)
            {
                query = query.Where(t => t.PositionId == filter.PositionId.Value);
            }


            return query.ToList();
        }
    }
}
