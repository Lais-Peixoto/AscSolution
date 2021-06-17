using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class ModeloV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Media",
                table: "Aluno",
                type: "float(2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Media",
                table: "Aluno",
                type: "float(1)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(2)");
        }
    }
}
