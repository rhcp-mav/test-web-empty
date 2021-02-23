using Microsoft.EntityFrameworkCore.Migrations;

namespace test_web_empty.Migrations
{
    public partial class createFK001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_CameraGroups_TCameraGroupsId",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_TCameraGroupsId",
                table: "Cameras");

            migrationBuilder.RenameColumn(
                name: "TCameraGroupsId",
                table: "Cameras",
                newName: "CameraGroupsId");

            migrationBuilder.AddColumn<int>(
                name: "CameraGroupId",
                table: "Cameras",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_CameraGroups_CameraGroupId",
                table: "Cameras");

            migrationBuilder.DropIndex(
                name: "IX_Cameras_CameraGroupId",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "CameraGroupId",
                table: "Cameras");

            migrationBuilder.RenameColumn(
                name: "CameraGroupsId",
                table: "Cameras",
                newName: "TCameraGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_TCameraGroupsId",
                table: "Cameras",
                column: "TCameraGroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_CameraGroups_TCameraGroupsId",
                table: "Cameras",
                column: "TCameraGroupsId",
                principalTable: "CameraGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
