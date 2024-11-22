using ArsentyevaMashaKT3121.Database.Configurations;
using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;

namespace ArsentyevaMashaKT3121.Database
{
    public class TeacherDbContext :DbContext
    {
        //Добавление таблиц
        DbSet<AcademicDegree> AcademicDegree { get; set; }
        DbSet<Department> Department { get; set; }
        DbSet<Position>  Positions { get; set; }
        DbSet<Subject> Subject { get; set; }
        DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        }

        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) { }
    }
}
