﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TaxReturnPolicy = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DDVs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tax = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDVs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxPayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    DDVId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxPayers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxPayers_DDVs_DDVId",
                        column: x => x.DDVId,
                        principalTable: "DDVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    DDVId = table.Column<int>(nullable: true),
                    TaxPayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_DDVs_DDVId",
                        column: x => x.DDVId,
                        principalTable: "DDVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_TaxPayers_TaxPayerId",
                        column: x => x.TaxPayerId,
                        principalTable: "TaxPayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "TaxReturnPolicy" },
                values: new object[,]
                {
                    { 1, "Macedonia", 0.14999999999999999 },
                    { 2, "USA", 0.050000000000000003 },
                    { 3, "Great Britain", 0.0050000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "DDVs",
                columns: new[] { "Id", "Tax" },
                values: new object[,]
                {
                    { 1, 0.0 },
                    { 2, 0.050000000000000003 },
                    { 3, 0.17999999999999999 }
                });

            migrationBuilder.InsertData(
                table: "TaxPayers",
                columns: new[] { "Id", "CountryId", "DDVId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, null, "Petar", "Petrevski" },
                    { 2, 1, null, "Igor", "Igorovski" },
                    { 3, 1, null, "Kire", "Kocev" },
                    { 4, 1, null, "ALeksandar", "Aleksandrovski" },
                    { 5, 2, null, "Franklin", "Short" },
                    { 6, 2, null, "George", "Wilkerson" },
                    { 7, 2, null, "Kyle", "McBride" },
                    { 8, 2, null, "Joseph", "Hudkins" },
                    { 9, 3, null, "Ben", "Duncan" },
                    { 10, 3, null, "Anthony", "Marshall" },
                    { 11, 3, null, "Jordan", "Murray" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DDVId",
                table: "Products",
                column: "DDVId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxPayerId",
                table: "Products",
                column: "TaxPayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayers_CountryId",
                table: "TaxPayers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayers_DDVId",
                table: "TaxPayers",
                column: "DDVId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TaxPayers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DDVs");
        }
    }
}
