using ArsentyevaMashaKT3121.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "cd_Position";
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder
                .HasKey(p => p.PositionId)
                .HasName($"pk_{TableName}_position_id");

            builder
                .Property(p => p.PositionId)
                .ValueGeneratedOnAdd() // Указываем генерацию значения автоматически
                .HasColumnName("position_id")
                .HasComment("Идентификатор должности");

            builder
                .Property(p => p.PositionName)
                .IsRequired()
                .HasColumnName("c_position_name")
                .HasMaxLength(100)
                .HasComment("Название должности");


            builder.ToTable(TableName);

            /*// Связь с преподавателями
            builder
                .HasMany(p => p.Teachers)
                .WithMany(t => t.Positions)
                .UsingEntity(j => j.ToTable("TeacherPosition")); // Промежуточная таблица связей*/
        }
    }
}
