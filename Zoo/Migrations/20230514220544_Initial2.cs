using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoo.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageSource = table.Column<string>(type: "text", nullable: true),
                    CategoryID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalID);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Visitor = table.Column<string>(type: "text", nullable: true),
                    AnimalID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Animals_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "AnimalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Mammal" },
                    { 2, "Birds" },
                    { 3, "Fish" },
                    { 4, "Amphibians" },
                    { 5, "reptiles" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Age", "CategoryID", "Description", "ImageSource", "Name" },
                values: new object[,]
                {
                    { 1, 5, 1, "description for lion", "animal1.jpg", "Lion" },
                    { 2, 2, 1, "description for dog", "animal2.jpg", "Dog" },
                    { 3, 12, 2, "description for eagle", "animal3.webp", "Eagle" },
                    { 4, 3, 3, "description for shark", "animal4.jpg", "Shark" },
                    { 5, 4, 1, "description for cat", "animal5.jpg", "Cat" },
                    { 6, 1, 5, "description for chameleon", "animal6.webp", "Chameleon" },
                    { 7, 15, 3, "description for whale", "animal7.jpg", "Whale" },
                    { 8, 2, 2, "description for pigeon", "animal8.jfif", "Pigeon" },
                    { 9, 4, 5, "description for alligator", "animal9.webp", "Alligator" },
                    { 10, 9, 2, "description for owl", "animal10.jpg", "Owl" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "AnimalID", "Content", "Visitor" },
                values: new object[,]
                {
                    { 1, 1, "king of animals", "Admin" },
                    { 2, 2, "the man's best friend", "Shmuel" },
                    { 3, 1, "Simba is his brother", null },
                    { 4, 5, "licks itself", "Moshe" },
                    { 5, 6, "can change colors", "David" },
                    { 6, 7, "the biggest fish in the world", "Yossi" },
                    { 7, 9, "you don't want to mess with this guy...", null },
                    { 8, 10, "the smartest bird", "Avi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryID",
                table: "Animals",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalID",
                table: "Comments",
                column: "AnimalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
