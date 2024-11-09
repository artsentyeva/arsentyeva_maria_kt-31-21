using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class PositionsConfiguration : IEntityTypeConfiguration<Positions>
    {
        private const string TableName = "cd_Position";
        public void Configure(EntityTypeBuilder<Positions> builder)
        {
            builder
                .HasKey(p => p.id_positions)
                .HasName($"pk_{TableName}id_positions");

            builder
                .Property(p => p.id_positions)
                .ValueGeneratedOnAdd() // Указываем генерацию значения автоматически
                .HasColumnName("id_positions")
                .HasComment("Идентификатор должности: ");

            builder
                .Property(p => p.title)
                .IsRequired()
                .HasColumnName("c_position_name")
                .HasMaxLength(100)
                .HasComment("Название должности: ");


            builder.ToTable(TableName);

            // Связь с преподавателями
            builder
                .HasMany(p => p.Teachers)
                .WithMany(t => t.Positions)
                .UsingEntity(j => j.ToTable("TeacherPosition")); // Промежуточная таблица связей
        }
    }
}
