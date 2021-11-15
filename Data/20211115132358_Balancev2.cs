using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorageWebAPP.Data
{
    public partial class Balancev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovementTypeModel",
                table: "MovementTypeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BalanceModel",
                table: "BalanceModel");

            migrationBuilder.RenameTable(
                name: "MovementTypeModel",
                newName: "MovementType");

            migrationBuilder.RenameTable(
                name: "BalanceModel",
                newName: "Balance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovementType",
                table: "MovementType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balance",
                table: "Balance",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovementType",
                table: "MovementType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Balance",
                table: "Balance");

            migrationBuilder.RenameTable(
                name: "MovementType",
                newName: "MovementTypeModel");

            migrationBuilder.RenameTable(
                name: "Balance",
                newName: "BalanceModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovementTypeModel",
                table: "MovementTypeModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BalanceModel",
                table: "BalanceModel",
                column: "Id");
        }
    }
}
