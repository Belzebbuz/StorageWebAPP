using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorageWebAPP.Data
{
    public partial class Balance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NomenclatureId = table.Column<int>(type: "INTEGER", nullable: true),
                    Count = table.Column<int>(type: "INTEGER", nullable: true),
                    ResponsibleId = table.Column<int>(type: "INTEGER", nullable: true),
                    MovementTypeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovementTypeModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementTypeModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MovementTypeModel",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Obtaining" });

            migrationBuilder.InsertData(
                table: "MovementTypeModel",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2L, "Consumption" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceModel");

            migrationBuilder.DropTable(
                name: "MovementTypeModel");
        }
    }
}
