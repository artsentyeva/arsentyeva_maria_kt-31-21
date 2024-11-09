using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class SubjectsConfiguration : IEntityTypeConfiguration<Subjects>
    {
        private const string TableName = "cd_Subjects";
        public void Configure(EntityTypeBuilder<Subjects> builder)
        {
            builder
                .HasKey(p => p.id_subjects)
                .HasName($"pk_{TableName}id_subjects");

            builder
                .Property(p => p.id_subjects)
                .ValueGeneratedOnAdd() 
                .HasColumnName("id_subjects")
                .HasComment("Идентификатор дисциплины: ");

            builder
                .Property(p => p.name)
                .IsRequired()
                .HasColumnName("c_subjects_name")
                .HasMaxLength(100)
                .HasComment("Название дисциплины: ");

            builder
                .Property(p => p.department_id)
                .IsRequired()
                .HasColumnName("c_subjects_department_id")
                .HasMaxLength(100)
                .HasComment("Название кафедры: ");


            builder.ToTable(TableName);

            // Связь с преподавателями
            builder
                .HasMany(p => p.Teachers)
                .WithMany(t => t.Subjects)
                .UsingEntity(j => j.ToTable("TeacherSubjects")); // Промежуточная таблица связей
        }
    }
}
