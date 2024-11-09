using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class AcademicDegreesConfiguration : IEntityTypeConfiguration<AcademicDegrees>
    {
        private const string TableName = "cd_AcademicDegrees";

        public void Configure(EntityTypeBuilder<AcademicDegrees> builder)
        {
            builder
                .HasKey(p => p.id_academicdegrees)
                .HasName($"pk_{TableName}_id_academicdegrees");

            builder
                .Property(p => p.id_academicdegrees)
                .ValueGeneratedOnAdd() // Указываем генерацию значения автоматически
                .HasColumnName("id_academicdegrees")
                .HasComment("Идентификатор степени");

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasColumnName("c_academicdegrees_title")
                .HasMaxLength(100)
                .HasComment("Учёная степень");

            builder.ToTable(TableName);

            // Связь с преподавателями
            builder
                .HasMany(p => p.Teachers)
                .WithMany(t => t.AcademicDegrees)
                .UsingEntity(j => j.ToTable("TeacherAcademicDegrees")); // Промежуточная таблица связей
        }
    }
}
