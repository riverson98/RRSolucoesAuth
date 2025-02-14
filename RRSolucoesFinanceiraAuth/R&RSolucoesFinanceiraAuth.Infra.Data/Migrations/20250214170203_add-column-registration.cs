﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R_RSolucoesFinanceiraAuth.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnregistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistrationCompleted",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistrationCompleted",
                table: "AspNetUsers");
        }
    }
}
