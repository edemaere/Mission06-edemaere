using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_edemaere.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    EntryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<short>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.EntryId);
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "EntryId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Sci-Fi", "Christopher Nolan", false, null, "It's lit bro", "PG-13", "Inception", (short)2010 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "EntryId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Sci-Fi", "Christopher Nolan", false, null, "It's lit too", "PG-13", "Interstellar", (short)2014 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "EntryId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Action", "Christopher Nolan", false, null, "Chris Nolan = Chad", "PG-13", "The Dark Knight", (short)2008 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
