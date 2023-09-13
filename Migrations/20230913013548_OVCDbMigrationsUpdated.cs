using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOOK_STORE_DEMO.Migrations
{
    /// <inheritdoc />
    public partial class OVCDbMigrationsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CartItems");
        }
    }
}
