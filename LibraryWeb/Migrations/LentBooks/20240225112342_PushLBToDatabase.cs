using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryWeb.Migrations.LentBooks
{
    /// <inheritdoc />
    public partial class PushLBToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lent_books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                        
                    Lent_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Due_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Lent = table.Column<int>(type: "int", nullable: false),
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lent_books", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lent_books");
        }
    }
}
