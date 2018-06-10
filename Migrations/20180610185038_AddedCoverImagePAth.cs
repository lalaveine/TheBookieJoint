using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBookieJoint.Migrations
{
    public partial class AddedCoverImagePAth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImgPath",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImgPath",
                table: "Products");
        }
    }
}
