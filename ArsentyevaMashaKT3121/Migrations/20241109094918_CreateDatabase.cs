using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArsentyevaMashaKT3121.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_AcademicDegrees",
                columns: table => new
                {
                    id_academicdegrees = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_academicdegrees_title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Учёная степень")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_AcademicDegrees_id_academicdegrees", x => x.id_academicdegrees);
                });

            migrationBuilder.CreateTable(
                name: "cd_Department",
                columns: table => new
                {
                    id_departmet = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название кафедры:"),
                    c_department_head_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Заведущий кафедры:")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Department_id_departmet", x => x.id_departmet);
                });

            migrationBuilder.CreateTable(
                name: "cd_Position",
                columns: table => new
                {
                    id_positions = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор должности: ")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_position_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название должности: ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Positionid_positions", x => x.id_positions);
                });

            migrationBuilder.CreateTable(
                name: "cd_Subjects",
                columns: table => new
                {
                    id_subjects = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор дисциплины: ")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_subjects_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название дисциплины: "),
                    c_subjects_department_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Название кафедры: ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Subjectsid_subjects", x => x.id_subjects);
                });

            migrationBuilder.CreateTable(
                name: "cd_Teachers",
                columns: table => new
                {
                    id_teachers = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор преподавателя: ")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teachers_full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "ФИО преподавателя: "),
                    c_teachers_department_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Кафедра на которой работает преподаватель: "),
                    c_teachers_academic_degree_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Учёная степень преподавателя: "),
                    c_teachers_position_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Должность преподавателя: ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Teachersid_teachers", x => x.id_teachers);
                });

            migrationBuilder.CreateTable(
                name: "cd_Workload",
                columns: table => new
                {
                    id_workload = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор нагрузки в часах: ")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_workload_teacher_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Идентификатор преподавателя: "),
                    c_workload_subject_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Идентификатор дисциплины: "),
                    c_workload_lecture_horus = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Лекционные часы: "),
                    c_workload_practice_hours = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Практические часы: ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Workloadid_workload", x => x.id_workload);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAcademicDegrees",
                columns: table => new
                {
                    AcademicDegreesid_academicdegrees = table.Column<int>(type: "integer", nullable: false),
                    Teachersid_teachers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAcademicDegrees", x => new { x.AcademicDegreesid_academicdegrees, x.Teachersid_teachers });
                    table.ForeignKey(
                        name: "FK_TeacherAcademicDegrees_cd_AcademicDegrees_AcademicDegreesid~",
                        column: x => x.AcademicDegreesid_academicdegrees,
                        principalTable: "cd_AcademicDegrees",
                        principalColumn: "id_academicdegrees",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherAcademicDegrees_cd_Teachers_Teachersid_teachers",
                        column: x => x.Teachersid_teachers,
                        principalTable: "cd_Teachers",
                        principalColumn: "id_teachers",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDepartment",
                columns: table => new
                {
                    Departmentid_departmet = table.Column<int>(type: "integer", nullable: false),
                    Teachersid_teachers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDepartment", x => new { x.Departmentid_departmet, x.Teachersid_teachers });
                    table.ForeignKey(
                        name: "FK_TeacherDepartment_cd_Department_Departmentid_departmet",
                        column: x => x.Departmentid_departmet,
                        principalTable: "cd_Department",
                        principalColumn: "id_departmet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherDepartment_cd_Teachers_Teachersid_teachers",
                        column: x => x.Teachersid_teachers,
                        principalTable: "cd_Teachers",
                        principalColumn: "id_teachers",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherPosition",
                columns: table => new
                {
                    Positionsid_positions = table.Column<int>(type: "integer", nullable: false),
                    Teachersid_teachers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPosition", x => new { x.Positionsid_positions, x.Teachersid_teachers });
                    table.ForeignKey(
                        name: "FK_TeacherPosition_cd_Position_Positionsid_positions",
                        column: x => x.Positionsid_positions,
                        principalTable: "cd_Position",
                        principalColumn: "id_positions",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherPosition_cd_Teachers_Teachersid_teachers",
                        column: x => x.Teachersid_teachers,
                        principalTable: "cd_Teachers",
                        principalColumn: "id_teachers",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    Subjectsid_subjects = table.Column<int>(type: "integer", nullable: false),
                    Teachersid_teachers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.Subjectsid_subjects, x.Teachersid_teachers });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_cd_Subjects_Subjectsid_subjects",
                        column: x => x.Subjectsid_subjects,
                        principalTable: "cd_Subjects",
                        principalColumn: "id_subjects",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_cd_Teachers_Teachersid_teachers",
                        column: x => x.Teachersid_teachers,
                        principalTable: "cd_Teachers",
                        principalColumn: "id_teachers",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherWorkload",
                columns: table => new
                {
                    Teachersid_teachers = table.Column<int>(type: "integer", nullable: false),
                    Workloadid_workload = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherWorkload", x => new { x.Teachersid_teachers, x.Workloadid_workload });
                    table.ForeignKey(
                        name: "FK_TeacherWorkload_cd_Teachers_Teachersid_teachers",
                        column: x => x.Teachersid_teachers,
                        principalTable: "cd_Teachers",
                        principalColumn: "id_teachers",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherWorkload_cd_Workload_Workloadid_workload",
                        column: x => x.Workloadid_workload,
                        principalTable: "cd_Workload",
                        principalColumn: "id_workload",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAcademicDegrees_Teachersid_teachers",
                table: "TeacherAcademicDegrees",
                column: "Teachersid_teachers");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDepartment_Teachersid_teachers",
                table: "TeacherDepartment",
                column: "Teachersid_teachers");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPosition_Teachersid_teachers",
                table: "TeacherPosition",
                column: "Teachersid_teachers");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_Teachersid_teachers",
                table: "TeacherSubjects",
                column: "Teachersid_teachers");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherWorkload_Workloadid_workload",
                table: "TeacherWorkload",
                column: "Workloadid_workload");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherAcademicDegrees");

            migrationBuilder.DropTable(
                name: "TeacherDepartment");

            migrationBuilder.DropTable(
                name: "TeacherPosition");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "TeacherWorkload");

            migrationBuilder.DropTable(
                name: "cd_AcademicDegrees");

            migrationBuilder.DropTable(
                name: "cd_Department");

            migrationBuilder.DropTable(
                name: "cd_Position");

            migrationBuilder.DropTable(
                name: "cd_Subjects");

            migrationBuilder.DropTable(
                name: "cd_Teachers");

            migrationBuilder.DropTable(
                name: "cd_Workload");
        }
    }
}
