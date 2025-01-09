using ArsentyevaMashaKT3121.Models;
using System.Collections.Generic;
using ArsentyevaMashaKT3121.Database;
using ArsentyevaMashaKT3121.Filters.SubjectFilters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ArsentyevaMashaKT3121.Interfaces.SubjectInterfaces
{
    public interface ISubjectService
    {
        void AddSubject(Subject subject);
        void UpdateSubject(int subjectId, Subject updatedSubject);
        void DeleteSubject(int subjectId);
        List<Subject> GetAllSubjects();

    }

    public class SubjectService : ISubjectService
    {
        private readonly TeacherDbContext _dbContext;

        public SubjectService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Добавление дисциплины
        public void AddSubject(Subject subject)
        {
            _dbContext.Subject.Add(subject);
            _dbContext.SaveChanges();
        }

        // Обновление дисциплины
        public void UpdateSubject(int subjectId, Subject updatedSubject)
        {
            var existingSubject = _dbContext.Subject
                .FirstOrDefault(s => s.SubjectId == subjectId);

            if (existingSubject != null)
            {
                existingSubject.SubjectName = updatedSubject.SubjectName;
                _dbContext.SaveChanges();
            }
        }

        // Удаление дисциплины
        public void DeleteSubject(int subjectId)
        {
            var subjectToDelete = _dbContext.Subject
                .FirstOrDefault(s => s.SubjectId == subjectId);

            if (subjectToDelete != null)
            {
                _dbContext.Subject.Remove(subjectToDelete);
                _dbContext.SaveChanges();
            }
        }

        // Получить все дисциплины
        public List<Subject> GetAllSubjects()
        {
            return _dbContext.Subject.ToList();
        }
    }
}
