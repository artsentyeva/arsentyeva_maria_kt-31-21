using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class TeachersConfiguration : IEntityTypeConfiguration<Teachers>
    {
        private const string TableName = "cd_Teachers";
        public void Configure(EntityTypeBuilder<Teachers> builder)
        {
            builder
                .HasKey(p => p.id_teachers)
                .HasName($"pk_{TableName}id_teachers");

            builder
                .Property(p => p.id_teachers)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_teachers")
                .HasComment("Идентификатор преподавателя: ");

            builder
                .Property(p => p.full_name)
                .IsRequired()
                .HasColumnName("c_teachers_full_name")
                .HasMaxLength(100)
                .HasComment("ФИО преподавателя: ");

            builder
                .Property(p => p.department_id)
                .IsRequired()
                .HasColumnName("c_teachers_department_id")
                .HasMaxLength(100)
                .HasComment("Кафедра на которой работает преподаватель: ");


            builder
                .Property(p => p.academic_degree_id)
                .IsRequired()
                .HasColumnName("c_teachers_academic_degree_id")
                .HasMaxLength(100)
                .HasComment("Учёная степень преподавателя: ");


            builder
                .Property(p => p.position_id)
                .IsRequired()
                .HasColumnName("c_teachers_position_id")
                .HasMaxLength(100)
                .HasComment("Должность преподавателя: ");


            builder.ToTable(TableName);
        }
    }
}

