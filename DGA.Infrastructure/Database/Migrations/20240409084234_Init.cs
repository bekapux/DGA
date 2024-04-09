using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DGA.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMovies",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovies", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_UserMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { new Guid("0345fa26-b2a8-4dad-8109-48084181eb90"), "Description of Movie 3", "Director 3", 2023, "Movie 3" },
                    { new Guid("2b5c9bfb-332a-4841-9a35-1c52f669473b"), "Description of Movie 1", "Director 1", 2021, "Movie 1" },
                    { new Guid("792dbafe-b439-41e8-9379-176d89f5d04d"), "Description of Movie 2", "Director 2", 2022, "Movie 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { new Guid("484d3bbb-5d7e-4f79-abcf-49a134467259"), "beka@example.com", "Beka", "Pukhashvili" },
                    { new Guid("e328e89b-b810-442f-a886-6343d21d4367"), "lasha@example.com", "Lasha", "Pukhashvili" }
                });

            migrationBuilder.InsertData(
                table: "UserMovies",
                columns: new[] { "MovieId", "UserId", "IsSeen" },
                values: new object[,]
                {
                    { new Guid("0345fa26-b2a8-4dad-8109-48084181eb90"), new Guid("484d3bbb-5d7e-4f79-abcf-49a134467259"), true },
                    { new Guid("2b5c9bfb-332a-4841-9a35-1c52f669473b"), new Guid("484d3bbb-5d7e-4f79-abcf-49a134467259"), true }
                });

            migrationBuilder.InsertData(
                table: "UserMovies",
                columns: new[] { "MovieId", "UserId" },
                values: new object[] { new Guid("792dbafe-b439-41e8-9379-176d89f5d04d"), new Guid("484d3bbb-5d7e-4f79-abcf-49a134467259") });

            migrationBuilder.InsertData(
                table: "UserMovies",
                columns: new[] { "MovieId", "UserId", "IsSeen" },
                values: new object[] { new Guid("2b5c9bfb-332a-4841-9a35-1c52f669473b"), new Guid("e328e89b-b810-442f-a886-6343d21d4367"), true });

            migrationBuilder.InsertData(
                table: "UserMovies",
                columns: new[] { "MovieId", "UserId" },
                values: new object[] { new Guid("792dbafe-b439-41e8-9379-176d89f5d04d"), new Guid("e328e89b-b810-442f-a886-6343d21d4367") });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_MovieId",
                table: "UserMovies",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovies");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
