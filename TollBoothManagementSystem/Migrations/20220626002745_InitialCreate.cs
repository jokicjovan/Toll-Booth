using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TollBoothManagementSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectronicTollCollections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LicencePlateNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Credit = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicTollCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaultReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    TollBoothId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReporterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateOfReport = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TollBoothId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EnterTollStationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EnterTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false),
                    Distance = table.Column<double>(type: "REAL", nullable: false),
                    AvarageSpeed = table.Column<double>(type: "REAL", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    ElectronicTollCollectionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LicencePlateNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_ElectronicTollCollections_ElectronicTollCollectionId",
                        column: x => x.ElectronicTollCollectionId,
                        principalTable: "ElectronicTollCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SectionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoadTollPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PriceListId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoadTollId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadTollPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadTollPrices_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoadTolls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TollStationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadTolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadTolls_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SectionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TollStationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Distance = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OriginId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DestinationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TollBoothId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReferentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TollBooths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    IsETC = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpen = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsTrafficLightFunctional = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsTollGateFunctional = table.Column<bool>(type: "INTEGER", nullable: false),
                    TollStationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TollBooths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TollStations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LocationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BossId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SectionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TollStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TollStations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TollStations_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    TollStationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_TollStations_TollStationId",
                        column: x => x.TollStationId,
                        principalTable: "TollStations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaultReports_ReporterId",
                table: "FaultReports",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultReports_TollBoothId",
                table: "FaultReports",
                column: "TollBoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ElectronicTollCollectionId",
                table: "Payments",
                column: "ElectronicTollCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EnterTollStationId",
                table: "Payments",
                column: "EnterTollStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TollBoothId",
                table: "Payments",
                column: "TollBoothId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_SectionId",
                table: "PriceLists",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadTollPrices_PriceListId",
                table: "RoadTollPrices",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadTollPrices_RoadTollId",
                table: "RoadTollPrices",
                column: "RoadTollId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadTolls_CurrencyId",
                table: "RoadTolls",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadTolls_TollStationId",
                table: "RoadTolls",
                column: "TollStationId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionInfos_SectionId",
                table: "SectionInfos",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionInfos_TollStationId",
                table: "SectionInfos",
                column: "TollStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DestinationId",
                table: "Sections",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_OriginId",
                table: "Sections",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ReferentId",
                table: "Shifts",
                column: "ReferentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_TollBoothId",
                table: "Shifts",
                column: "TollBoothId");

            migrationBuilder.CreateIndex(
                name: "IX_TollBooths_TollStationId",
                table: "TollBooths",
                column: "TollStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TollStations_BossId",
                table: "TollStations",
                column: "BossId");

            migrationBuilder.CreateIndex(
                name: "IX_TollStations_LocationId",
                table: "TollStations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TollStations_SectionId",
                table: "TollStations",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TollStationId",
                table: "Users",
                column: "TollStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultReports_TollBooths_TollBoothId",
                table: "FaultReports",
                column: "TollBoothId",
                principalTable: "TollBooths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaultReports_Users_ReporterId",
                table: "FaultReports",
                column: "ReporterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_TollBooths_TollBoothId",
                table: "Payments",
                column: "TollBoothId",
                principalTable: "TollBooths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_TollStations_EnterTollStationId",
                table: "Payments",
                column: "EnterTollStationId",
                principalTable: "TollStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Sections_SectionId",
                table: "PriceLists",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoadTollPrices_RoadTolls_RoadTollId",
                table: "RoadTollPrices",
                column: "RoadTollId",
                principalTable: "RoadTolls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoadTolls_TollStations_TollStationId",
                table: "RoadTolls",
                column: "TollStationId",
                principalTable: "TollStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionInfos_Sections_SectionId",
                table: "SectionInfos",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionInfos_TollStations_TollStationId",
                table: "SectionInfos",
                column: "TollStationId",
                principalTable: "TollStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_TollStations_DestinationId",
                table: "Sections",
                column: "DestinationId",
                principalTable: "TollStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_TollStations_OriginId",
                table: "Sections",
                column: "OriginId",
                principalTable: "TollStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_TollBooths_TollBoothId",
                table: "Shifts",
                column: "TollBoothId",
                principalTable: "TollBooths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Users_ReferentId",
                table: "Shifts",
                column: "ReferentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TollBooths_TollStations_TollStationId",
                table: "TollBooths",
                column: "TollStationId",
                principalTable: "TollStations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TollStations_Users_BossId",
                table: "TollStations",
                column: "BossId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TollStations_Users_BossId",
                table: "TollStations");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_TollStations_DestinationId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_TollStations_OriginId",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "FaultReports");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RoadTollPrices");

            migrationBuilder.DropTable(
                name: "SectionInfos");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "ElectronicTollCollections");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "RoadTolls");

            migrationBuilder.DropTable(
                name: "TollBooths");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TollStations");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
