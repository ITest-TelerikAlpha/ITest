using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ITest.Data.Migrations
{
    public partial class author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_AuthorId1",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_AuthorId1",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Tests");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Tests",
                nullable: true,
                oldClrType: typeof(Guid));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_AuthorId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_AuthorId",
                table: "Tests");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Tests",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId1",
                table: "Tests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_AuthorId1",
                table: "Tests",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_AuthorId1",
                table: "Tests",
                column: "AuthorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
