using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Pages.Data.Migrations
{
    public partial class SublocationAdd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sublocations_Location_LocationId",
                table: "Sublocations");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Sublocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sublocations_Location_LocationId",
                table: "Sublocations",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sublocations_Location_LocationId",
                table: "Sublocations");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Sublocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sublocations_Location_LocationId",
                table: "Sublocations",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
