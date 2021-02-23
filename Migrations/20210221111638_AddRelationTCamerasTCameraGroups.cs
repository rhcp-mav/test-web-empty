using Microsoft.EntityFrameworkCore.Migrations;

namespace test_web_empty.Migrations
{
    public partial class AddRelationTCamerasTCameraGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CameraGroupsId",
                table: "Cameras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_CameraGroupsId",
                table: "Cameras",
                column: "CameraGroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_CameraGroups_CameraGroupsId",
                table: "Cameras",
                column: "CameraGroupsId",
                principalTable: "CameraGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_CameraGroups_CameraGroupsId",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_CameraGroupsId",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "CameraGroupsId",
                table: "Cameras");
        }
    }
}
