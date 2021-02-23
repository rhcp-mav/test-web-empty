using Microsoft.EntityFrameworkCore.Migrations;

namespace test_web_empty.Migrations
{
    public partial class createFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CameraGroupId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "CameraGroupId");
        }
    }
}
