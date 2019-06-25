using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaUTN.Migrations
{
    public partial class _03_AddAlumnoIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_AlumnoIdentity",
                columns: table => new
                {
                    IdAlumno = table.Column<Guid>(nullable: false),
                    IdIdentity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AlumnoIdentity", x => x.IdAlumno);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AlumnoIdentity");
        }
    }
}
