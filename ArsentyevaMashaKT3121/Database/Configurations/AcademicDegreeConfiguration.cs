using ArsentyevaMashaKT3121.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "cd_AcademicDegree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder
                .HasKey(p => p.AcademicDegreeId)
                .HasName($"pk_{TableName}_academicdegree_id");

            builder
                .Property(p => p.AcademicDegreeId)
                .ValueGeneratedOnAdd() // Указываем генерацию значения автоматически
                .HasColumnName("academicdegree_id")
                .HasComment("Идентификатор степени");

            builder
                .Property(p => p.AcademicDegreeName)
                .IsRequired()
                .HasColumnName("c_academicdegree_name")
                .HasMaxLength(100)
                .HasComment("Учёная степень");

            builder.ToTable(TableName);

           /* // Связь с преподавателями
            builder
                .HasMany(p => p.Teachers)
                .WithMany(t => t.AcademicDegrees)
                .UsingEntity(j => j.ToTable("TeacherAcademicDegrees")); // Промежуточная таблица связей*/
        }
    }
}
