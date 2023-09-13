using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DesafioFullStack_Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompaniesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompaniesId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SuppliersId = table.Column<Guid>(type: "uuid", nullable: false),
                    CnpjCpf = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Rg = table.Column<string>(type: "text", nullable: true),
                    Uf = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SuppliersId);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesSuppliers",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesSuppliers", x => new { x.CompanyId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_CompaniesSuppliers_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompaniesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompaniesSuppliers_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SuppliersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompaniesId", "Cep", "Cnpj", "Name" },
                values: new object[,]
                {
                    { new Guid("744fe497-d126-411a-a83a-031f31bd73f7"), "05439010", "54413724000196", "Empresa2" },
                    { new Guid("a13c546e-0c15-4a1f-b522-09dcb6e5529f"), "83514320", "56269892000185", "Empresa1" },
                    { new Guid("d461d4d4-6d47-416c-9faf-bfc5786c1a22"), "04089972", "75782208000109", "Empresa3" }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "SuppliersId", "Birthday", "Cep", "CnpjCpf", "Email", "Name", "Rg", "Uf" },
                values: new object[,]
                {
                    { new Guid("2eaf8ee9-7d3e-4dfb-a9d4-196421b2b29a"), new DateTime(2023, 9, 13, 15, 51, 53, 618, DateTimeKind.Local).AddTicks(8152), "04176000", "14090702046", "fornecedor2@hmail.com", "Fornecedor2", "348235963", "SP" },
                    { new Guid("41886c1d-402c-4425-979a-4fa18f5f1696"), new DateTime(2023, 9, 13, 15, 51, 53, 618, DateTimeKind.Local).AddTicks(8133), "84910970", "34994179018", "fornecedor1@gmail.com", "Fornecedor1", "475169621", "PR" },
                    { new Guid("7d7bfc4c-f67e-4591-8ffe-bcadda6d4e17"), null, "05545160", "70357563000117", "fornecedor3@gmail.com", "Fornecedor3", null, "SP" }
                });

            migrationBuilder.InsertData(
                table: "CompaniesSuppliers",
                columns: new[] { "CompanyId", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("a13c546e-0c15-4a1f-b522-09dcb6e5529f"), new Guid("2eaf8ee9-7d3e-4dfb-a9d4-196421b2b29a") },
                    { new Guid("a13c546e-0c15-4a1f-b522-09dcb6e5529f"), new Guid("7d7bfc4c-f67e-4591-8ffe-bcadda6d4e17") },
                    { new Guid("d461d4d4-6d47-416c-9faf-bfc5786c1a22"), new Guid("41886c1d-402c-4425-979a-4fa18f5f1696") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesSuppliers_SupplierId",
                table: "CompaniesSuppliers",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesSuppliers");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
