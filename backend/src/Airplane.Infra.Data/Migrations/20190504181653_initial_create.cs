using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airplane.Infra.Data.Migrations
{
    public partial class initial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Codigo = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Passageiros = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_Codigo",
                table: "Aircraft",
                column: "Codigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircraft");
        }
    }
}
