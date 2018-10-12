using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotationManager.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SignificanceLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purposes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contributions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    BaseSum = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    PurposeId = table.Column<int>(nullable: false),
                    RefinancingAmount = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 1024, nullable: true),
                    InterestRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotas_Purposes_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "Purposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotaContributions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuotaId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotaContributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotaContributions_Quotas_QuotaId",
                        column: x => x.QuotaId,
                        principalTable: "Quotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "SignificanceLevel" },
                values: new object[,]
                {
                    { 1, "Красноярск", 10 },
                    { 2, "Новосибирск", 8 },
                    { 3, "Москва", 5 },
                    { 4, "Санкт-Петербург", 6 },
                    { 5, "Челябинск", 1 }
                });

            migrationBuilder.InsertData(
                table: "Purposes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ипотека" },
                    { 2, "Потребительский кредит" },
                    { 3, "Автокредит" }
                });

            migrationBuilder.InsertData(
                table: "Contributions",
                columns: new[] { "Id", "BaseSum", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 10, 1, "Плохая экология" },
                    { 2, 10, 1, "Плохие дороги" },
                    { 3, 3, 1, "Нет метро" },
                    { 4, 5, 2, "Столица Сибири" },
                    { 6, 10, 3, "Столица России" },
                    { 7, 10, 3, "Вечные пробки" },
                    { 5, 8, 4, "Красивый город" },
                    { 8, 7, 5, "Плохая экология" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_CityId",
                table: "Contributions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotaContributions_QuotaId",
                table: "QuotaContributions",
                column: "QuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotas_CityId",
                table: "Quotas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotas_PurposeId",
                table: "Quotas",
                column: "PurposeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributions");

            migrationBuilder.DropTable(
                name: "QuotaContributions");

            migrationBuilder.DropTable(
                name: "Quotas");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Purposes");
        }
    }
}
