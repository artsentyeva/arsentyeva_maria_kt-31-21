using ArsentyevaMashaKT3121.Database.Configurations;
using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;

namespace ArsentyevaMashaKT3121.Database
{
    public class TeacherDbContext :DbContext
    {
        //Добавление таблиц
        public DbSet<AcademicDegree> AcademicDegree { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Position>  Positions { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

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
