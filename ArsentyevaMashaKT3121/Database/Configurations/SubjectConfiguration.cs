using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "cd_Subject";
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(p => p.SubjectId)
                .HasName($"pk_{TableName}_subject_id");

            builder
                .Property(p => p.SubjectId)
                .ValueGeneratedOnAdd() 
                .HasColumnName("subject_id")
                .HasComment("Идентификатор дисциплины");

            builder
                .Property(p => p.SubjectName)
                .IsRequired()
                .HasColumnName("c_subject_name")
                .HasMaxLength(100)
                .HasComment("Название дисциплины");

            builder.ToTable(TableName);

            /*// Связь с преподавателями
            builder
                .HasMany(p => p.Teachers)
                .WithMany(t => t.Subjects)
                .UsingEntity(j => j.ToTable("TeacherSubjects")); // Промежуточная таблица связей*/
        }
    }
}
