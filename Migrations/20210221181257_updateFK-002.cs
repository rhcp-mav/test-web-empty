using Microsoft.EntityFrameworkCore.Migrations;

namespace test_web_empty.Migrations
{
    public partial class updateFK002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CameraGroupsId",
                table: "Cameras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CameraGroupsId",
                table: "Cameras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
