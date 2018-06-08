using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBookieJoint.Migrations
{
    public partial class PrductsRemovedAvailableCopies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableCopies",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AvailableCopies",
                table: "Products",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
