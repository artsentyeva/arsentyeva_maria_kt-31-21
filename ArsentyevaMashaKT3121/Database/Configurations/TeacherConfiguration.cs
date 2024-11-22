using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArsentyevaMashaKT3121.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_Teacher";
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasKey(p => p.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            builder
                .Property(p => p.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор преподавателя");

            builder
                .Property(p => p.TeacherName)
                .IsRequired()
                .HasColumnName("c_teacher_name")
                .HasMaxLength(100)
                .HasComment("ФИО преподавателя");

            builder
                .Property(p => p.DepartmentId)
                .IsRequired()
                .HasColumnName("c_teacher_department_id")
                .HasMaxLength(100)
                .HasComment("Кафедра на которой работает преподаватель");


            builder
                .Property(p => p.AcademicDegreeId)
                .IsRequired()
                .HasColumnName("c_teacher_academic_degree_id")
                .HasMaxLength(100)
                .HasComment("Учёная степень преподавателя");


            builder
                .Property(p => p.PositionId)
                .IsRequired()
                .HasColumnName("c_teacher_position_id")
                .HasMaxLength(100)
                .HasComment("Должность преподавателя");

            builder
                .Property(p => p.SubjectId)
                .IsRequired()
                .HasColumnName("c_teacher_subject_id")
                .HasMaxLength(100)
                .HasComment("Дисциплины преподавателя");

            builder.ToTable(TableName);

            /////////////////////////////////////////////////////
            builder.Property(p => p.AcademicDegreeId).IsRequired()
            .HasColumnName("c_teacher_academic_degree_id");

            builder.HasOne(p => p.AcademicDegree)
                .WithMany()
                .HasForeignKey(p => p.AcademicDegreeId)
                .HasConstraintName("fk_f_academic_degree_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.AcademicDegree)
                .AutoInclude();

            /////////////////////////////////////////////////////
            ///
            builder.Property(p => p.DepartmentId).IsRequired()
            .HasColumnName("c_teacher_department_id");

            builder.HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId)
                .HasConstraintName("fk_f_department_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.Department)
                .AutoInclude();

            /////////////////////////////////////////////////////
            ///
            builder.Property(p => p.PositionId).IsRequired()
           .HasColumnName("c_teacher_position_id");

            builder.HasOne(p => p.Position)
                .WithMany()
                .HasForeignKey(p => p.PositionId)
                .HasConstraintName("fk_f_position_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.Position)
                .AutoInclude();

            /////////////////////////////////////////////////////
            ///
            builder.Property(p => p.SubjectId).IsRequired()
           .HasColumnName("c_teacher_subject_id");

            builder.HasOne(p => p.Subject)
                .WithMany()
                .HasForeignKey(p => p.SubjectId)
                .HasConstraintName("fk_f_subject_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.Subject)
                .AutoInclude();
        }
    }
}

