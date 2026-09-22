using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeanProductionAnalytics.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    JobId = table.Column<string>(type: "TEXT", nullable: true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    Operation = table.Column<string>(type: "TEXT", nullable: true),
                    MachineId = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorId = table.Column<string>(type: "TEXT", nullable: true),
                    Shift = table.Column<string>(type: "TEXT", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProcessingTime = table.Column<int>(type: "INTEGER", nullable: true),
                    QueueTime = table.Column<int>(type: "INTEGER", nullable: true),
                    RejectQuantity = table.Column<int>(type: "INTEGER", nullable: true),
                    JigExchangeRequired = table.Column<bool>(type: "INTEGER", nullable: true),
                    SetupTime = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JigExchange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SetupId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JigExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JigExchange_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JigStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    JigExchangeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: false),
                    Step = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JigStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JigStep_JigExchange_JigExchangeId",
                        column: x => x.JigExchangeId,
                        principalTable: "JigExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JigExchange_ProductionId",
                table: "JigExchange",
                column: "ProductionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JigStep_JigExchangeId",
                table: "JigStep",
                column: "JigExchangeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JigStep");

            migrationBuilder.DropTable(
                name: "JigExchange");

            migrationBuilder.DropTable(
                name: "Productions");
        }
    }
}
