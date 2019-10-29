using Microsoft.EntityFrameworkCore.Migrations;

namespace codingChallenge.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Lavender heart", "9.25" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Personalised cufflinks", "45.00" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Kids T-shirt", "19.95" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
