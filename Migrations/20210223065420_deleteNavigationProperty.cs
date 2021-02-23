using Microsoft.EntityFrameworkCore.Migrations;

namespace test_web_empty.Migrations
{
    public partial class deleteNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_CameraGroups_CameraGroupId",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_CameraGroupId",
                table: "Cameras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cameras_CameraGroupId",
                table: "Cameras",
                column: "CameraGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_CameraGroups_CameraGroupId",
                table: "Cameras",
                column: "CameraGroupId",
                principalTable: "CameraGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
