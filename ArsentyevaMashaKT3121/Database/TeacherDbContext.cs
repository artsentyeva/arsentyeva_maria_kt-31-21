using ArsentyevaMashaKT3121.Database.Configurations;
using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;

namespace ArsentyevaMashaKT3121.Database
{
    public class TeacherDbContext :DbContext
    {
        //Добавление таблиц
        DbSet<AcademicDegrees> AcademicDegrees { get; set; }
        DbSet<Department> Department { get; set; }
        DbSet<Positions>  Positions { get; set; }
        DbSet<Subjects> Subjects { get; set; }
        DbSet<Teachers> Teachers { get; set; }
        DbSet<Workload> Workloads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new AcademicDegreesConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PositionsConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectsConfiguration());
            modelBuilder.ApplyConfiguration(new TeachersConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
        }

        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) { }
    }
}
