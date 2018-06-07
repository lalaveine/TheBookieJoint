using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBookieJoint.Migrations
{
    public partial class ModelEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Products",
                newName: "Translators");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalLanguage",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicationYear",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OriginalLanguage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Translators",
                table: "Products",
                newName: "Category");
        }
    }
}
