using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewspapperAPI.Migrations
{
    public partial class articleTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SharedTo",
                table: "Shares");

            migrationBuilder.DropColumn(
                name: "NumberOfLike",
                table: "Likes");

            migrationBuilder.AddColumn<bool>(
                name: "Shared",
                table: "Shares",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Liked",
                table: "Likes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shared",
                table: "Shares");

            migrationBuilder.DropColumn(
                name: "Liked",
                table: "Likes");

            migrationBuilder.AddColumn<string>(
                name: "SharedTo",
                table: "Shares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLike",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Text",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
