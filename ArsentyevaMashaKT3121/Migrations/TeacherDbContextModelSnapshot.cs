﻿// <auto-generated />
using ArsentyevaMashaKT3121.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArsentyevaMashaKT3121.Migrations
{
    [DbContext(typeof(TeacherDbContext))]
    partial class TeacherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ArsentyevaMashaKT3121.Models.AcademicDegree", b =>
                {
                    b.Property<int>("AcademicDegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("academicdegree_id")
                        .HasComment("Идентификатор степени");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AcademicDegreeId"));

                    b.Property<string>("AcademicDegreeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("c_academicdegree_name")
                        .HasComment("Учёная степень");

                    b.HasKey("AcademicDegreeId")
                        .HasName("pk_cd_AcademicDegree_academicdegree_id");

                    b.ToTable("cd_AcademicDegree", (string)null);
                });

            modelBuilder.Entity("ArsentyevaMashaKT3121.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор кафедры");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("c_department_name")
                        .HasComment("Название кафедры");

                    b.HasKey("DepartmentId")
                        .HasName("pk_cd_Department_departmet_id");

                    b.ToTable("cd_Department", (string)null);
                });

            modelBuilder.Entity("ArsentyevaMashaKT3121.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("position_id")
                        .HasComment("Идентификатор должности");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PositionId"));

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("c_position_name")
                        .HasComment("Название должности");

                    b.HasKey("PositionId")
                        .HasName("pk_cd_Position_position_id");

                    b.ToTable("cd_Position", (string)null);
                });

            modelBuilder.Entity("ArsentyevaMashaKT3121.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subject_id")
                        .HasComment("Идентификатор дисциплины");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("c_subject_name")
                        .HasComment("Название дисциплины");

                    b.HasKey("SubjectId")
                        .HasName("pk_cd_Subject_subject_id");

                    b.ToTable("cd_Subject", (string)null);
                });

            modelBuilder.Entity("ArsentyevaMashaKT3121.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("teacher_id")
                        .HasComment("Идентификатор преподавателя");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeacherId"));

                    b.Property<int>("AcademicDegreeId")
                        .HasMaxLength(100)
                        .HasColumnType("integer")
                        .HasColumnName("c_teacher_academic_degree_id")
                        .HasComment("Учёная степень преподавателя");

                    b.Property<int>("DepartmentId")
                        .HasMaxLength(100)
                        .HasColumnType("integer")
                        .HasColumnName("c_teacher_department_id")
                        .HasComment("Кафедра на которой работает преподаватель");

                    b.Property<int>("PositionId")
                        .HasMaxLength(100)
                        .HasColumnType("integer")
                        .HasColumnName("c_teacher_position_id")
                        .HasComment("Должность преподавателя");

                    b.Property<int>("SubjectId")
                        .HasMaxLength(100)
                        .HasColumnType("integer")
                        .HasColumnName("c_teacher_subject_id")
                        .HasComment("Дисциплины преподавателя");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("c_teacher_name")
                        .HasComment("ФИО преподавателя");

                    b.HasKey("TeacherId")
                        .HasName("pk_cd_Teacher_teacher_id");

                    b.HasIndex("AcademicDegreeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionId");

                    b.HasIndex("SubjectId");

                    b.ToTable("cd_Teacher", (string)null);
                });

            modelBuilder.Entity("ArsentyevaMashaKT3121.Models.Teacher", b =>
                {
                    b.HasOne("ArsentyevaMashaKT3121.Models.AcademicDegree", "AcademicDegree")
                        .WithMany()
                        .HasForeignKey("AcademicDegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_academic_degree_id");

                    b.HasOne("ArsentyevaMashaKT3121.Models.Department", "Department")
                        .WithMany("Teacher")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_department_id");

                    b.HasOne("ArsentyevaMashaKT3121.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_position_id");

                    b.HasOne("ArsentyevaMashaKT3121.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_subject_id");

                    b.Navigation("AcademicDegree");

                    b.Navigation("Department");

                    b.Navigation("Position");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ArsentyevaMashaKT3121.Models.Department", b =>
                {
                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
