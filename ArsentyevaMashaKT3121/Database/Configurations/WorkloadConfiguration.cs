using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        private const string TableName = "cd_Workload";
        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder
                .HasKey(p => p.id_workload)
                .HasName($"pk_{TableName}id_workload");

            builder
                .Property(p => p.id_workload)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_workload")
                .HasComment("Идентификатор нагрузки в часах: ");

            builder
                .Property(p => p.teacher_id)
                .IsRequired()
                .HasColumnName("c_workload_teacher_id")
                .HasMaxLength(100)
                .HasComment("Идентификатор преподавателя: ");

            builder
                .Property(p => p.subject_id)
                .IsRequired()
                .HasColumnName("c_workload_subject_id")
                .HasMaxLength(100)
                .HasComment("Идентификатор дисциплины: ");


            builder
                .Property(p => p.lecture_horus)
                .IsRequired()
                .HasColumnName("c_workload_lecture_horus")
                .HasMaxLength(100)
                .HasComment("Лекционные часы: ");


            builder
                .Property(p => p.practice_hours)
                .IsRequired()
                .HasColumnName("c_workload_practice_hours")
                .HasMaxLength(100)
                .HasComment("Практические часы: ");


            builder.ToTable(TableName);

            // Связь с преподавателями
            builder
                .HasMany(p => p.Teachers)
                .WithMany(t => t.Workload)
                .UsingEntity(j => j.ToTable("TeacherWorkload")); // Промежуточная таблица связей
        }
    } 
}
