using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMind.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Figi = table.Column<string>(type: "text", nullable: false),
                    Ticker = table.Column<string>(type: "text", nullable: false),
                    Lot = table.Column<int>(type: "integer", nullable: false),
                    ShortEnabledFlag = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryOfRisk = table.Column<string>(type: "text", nullable: false),
                    CountryOfRiskName = table.Column<string>(type: "text", nullable: false),
                    MinPriceIncrement = table.Column<decimal>(type: "numeric", nullable: false),
                    ForQualInvestorFlag = table.Column<bool>(type: "boolean", nullable: false),
                    WeekendFlag = table.Column<bool>(type: "boolean", nullable: false),
                    First1MinCandleDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    First1DayCandleDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LogoName = table.Column<string>(type: "text", nullable: false),
                    LogoBaseColor = table.Column<string>(type: "text", nullable: false),
                    TextColor = table.Column<string>(type: "text", nullable: false),
                    ShareId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Open = table.Column<decimal>(type: "numeric", nullable: false),
                    High = table.Column<decimal>(type: "numeric", nullable: false),
                    Low = table.Column<decimal>(type: "numeric", nullable: false),
                    Close = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<long>(type: "bigint", nullable: false),
                    Interval = table.Column<string>(type: "character varying(20)", nullable: false),
                    Time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: false),
                    CandleSourceType = table.Column<string>(type: "character varying(20)", nullable: false),
                    ShareId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candles_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ShareId",
                table: "Brands",
                column: "ShareId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candles_ShareId",
                table: "Candles",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_Figi_Ticker",
                table: "Shares",
                columns: new[] { "Figi", "Ticker" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Candles");

            migrationBuilder.DropTable(
                name: "Shares");
        }
    }
}
