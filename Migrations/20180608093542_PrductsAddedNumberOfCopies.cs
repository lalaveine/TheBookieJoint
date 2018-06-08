using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBookieJoint.Migrations
{
    public partial class PrductsAddedNumberOfCopies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AvailableCopies",
                table: "Products",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "NumberOfCopies",
                table: "Products",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableCopies",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NumberOfCopies",
                table: "Products");
        }
    }
}
