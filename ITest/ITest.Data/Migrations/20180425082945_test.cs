using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ITest.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_AuthorId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_AuthorId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Tests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Tests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_AuthorId",
                table: "Tests",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_AuthorId",
                table: "Tests",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
