using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaUTN.Migrations
{
    public partial class _03_AddAlumnoIdentity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdIdentity",
                table: "tbl_Alumno",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdIdentity",
                table: "tbl_Alumno");
        }
    }
}
