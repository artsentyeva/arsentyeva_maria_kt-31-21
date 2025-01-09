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
                name: "cd_AcademicDegree",
                columns: table => new
                {
                    academicdegree_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_academicdegree_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Учёная степень")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_AcademicDegree_academicdegree_id", x => x.academicdegree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Department_departmet_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_Position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_position_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_Subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_subject_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Subject_subject_id", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_Teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "ФИО преподавателя"),
                    c_teacher_academic_degree_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Учёная степень преподавателя"),
                    c_teacher_department_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Кафедра на которой работает преподаватель"),
                    c_teacher_position_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Должность преподавателя"),
                    c_teacher_subject_id = table.Column<int>(type: "integer", maxLength: 100, nullable: false, comment: "Дисциплины преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_f_academic_degree_id",
                        column: x => x.c_teacher_academic_degree_id,
                        principalTable: "cd_AcademicDegree",
                        principalColumn: "academicdegree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.c_teacher_department_id,
                        principalTable: "cd_Department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_position_id",
                        column: x => x.c_teacher_position_id,
                        principalTable: "cd_Position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_subject_id",
                        column: x => x.c_teacher_subject_id,
                        principalTable: "cd_Subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_Teacher_c_teacher_academic_degree_id",
                table: "cd_Teacher",
                column: "c_teacher_academic_degree_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_Teacher_c_teacher_department_id",
                table: "cd_Teacher",
                column: "c_teacher_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_Teacher_c_teacher_position_id",
                table: "cd_Teacher",
                column: "c_teacher_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_Teacher_c_teacher_subject_id",
                table: "cd_Teacher",
                column: "c_teacher_subject_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_Teacher");

            migrationBuilder.DropTable(
                name: "cd_AcademicDegree");

            migrationBuilder.DropTable(
                name: "cd_Department");

            migrationBuilder.DropTable(
                name: "cd_Position");

            migrationBuilder.DropTable(
                name: "cd_Subject");
        }
    }
}
