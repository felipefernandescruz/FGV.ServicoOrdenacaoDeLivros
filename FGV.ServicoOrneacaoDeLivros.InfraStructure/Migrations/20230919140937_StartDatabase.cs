using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FGV.ServicoOrneacaoDeLivros.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class StartDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OrderType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 19, 11, 9, 37, 800, DateTimeKind.Unspecified).AddTicks(743), null, "TitleAsc", null },
                    { 2, new DateTime(2023, 9, 19, 11, 9, 37, 800, DateTimeKind.Unspecified).AddTicks(848), null, "AuthorAscTitleDesc", null },
                    { 3, new DateTime(2023, 9, 19, 11, 9, 37, 800, DateTimeKind.Unspecified).AddTicks(854), null, "EditionDescAuthorDescTituloAsc", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderType");
        }
    }
}
