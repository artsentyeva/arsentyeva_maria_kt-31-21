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
                .HasKey(p => p.DepartmentId)
                .HasName($"pk_{TableName}_departmet_id");

            builder
                .Property(p => p.DepartmentId)
                .ValueGeneratedOnAdd() // Указываем генерацию значения автоматически
                .HasColumnName("departmet_id")
                .HasComment("Идентификатор кафедры");

            builder
                .Property(p => p.DepartmentName)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasMaxLength(100)
                .HasComment("Название кафедры");

           builder
                .Property(p => p.DepartmentHeadId)
                .IsRequired()
                .HasColumnName("c_department_head_id")
                .HasMaxLength(100)
                .HasComment("Заведущий кафедры");

/*            // Настройка связи с преподавателями
            builder
                 .HasOne(d => d.DepartmentHead) // Связь с заведующим
                 .WithMany() // У заведующего нет списка кафедр
                 .HasForeignKey(d => d.DepartmentHeadId)
                 .OnDelete(DeleteBehavior.SetNull); // Ограничение удаления
*/
            builder.ToTable(TableName);
        }

    }
}
