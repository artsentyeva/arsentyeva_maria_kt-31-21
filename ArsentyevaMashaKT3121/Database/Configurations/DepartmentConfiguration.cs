using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_Department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasKey(p => p.id_departmet)
                .HasName($"pk_{TableName}_id_departmet");

            builder
                .Property(p => p.id_departmet)
                .ValueGeneratedOnAdd() // Указываем генерацию значения автоматически
                .HasColumnName("id_departmet")
                .HasComment("Идентификатор кафедры");

            builder
                .Property(p => p.name)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasMaxLength(100)
                .HasComment("Название кафедры:");

            builder
                .Property(p => p.head_id)
                .IsRequired()
                .HasColumnName("c_department_head_id")
                .HasMaxLength(100)
                .HasComment("Заведущий кафедры:");

            builder.ToTable(TableName);

            // Связь с преподавателями
            builder
                .HasMany(p => p.Teachers)
                .WithMany(t => t.Department)
                .UsingEntity(j => j.ToTable("TeacherDepartment")); // Промежуточная таблица связей
        }
    }
}
