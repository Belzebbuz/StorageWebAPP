using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorageWebAPP.Data
{
    public partial class NomenclatureMeasure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Measure",
                table: "Nomenclature",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measure",
                table: "Nomenclature");
        }
    }
}
