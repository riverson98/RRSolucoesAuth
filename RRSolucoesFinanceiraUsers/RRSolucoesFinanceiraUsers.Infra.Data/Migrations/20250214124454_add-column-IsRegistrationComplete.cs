using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RRSolucoesFinanceiraUsers.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnIsRegistrationComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistrationComplete",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistrationComplete",
                table: "Users");
        }
    }
}
