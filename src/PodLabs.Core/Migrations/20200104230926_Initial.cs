using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PodLabs.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alliances",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AllianceId = table.Column<long>(nullable: false),
                    CreatorCorporationId = table.Column<long>(nullable: false),
                    CreatorId = table.Column<long>(nullable: false),
                    DateFounded = table.Column<DateTime>(nullable: false),
                    ExecutorCorporationId = table.Column<long>(nullable: true),
                    FactionId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Ticker = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alliances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corporations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CorporationId = table.Column<long>(nullable: false),
                    AllianceId = table.Column<long>(nullable: true),
                    CeoId = table.Column<long>(nullable: false),
                    CreatorId = table.Column<long>(nullable: false),
                    DateFounded = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FactionId = table.Column<long>(nullable: true),
                    HomeStationId = table.Column<long>(nullable: true),
                    MemberCount = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Shares = table.Column<long>(nullable: true),
                    TaxRate = table.Column<double>(nullable: false),
                    Ticker = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    WarEligible = table.Column<short>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    X = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false),
                    Z = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trackers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TrackerId = table.Column<long>(nullable: false),
                    IsAlliance = table.Column<short>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trackers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zkb",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    LocationId = table.Column<long>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    FittedValue = table.Column<double>(nullable: false),
                    TotalValue = table.Column<double>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    NPC = table.Column<short>(type: "bit", nullable: false),
                    Solo = table.Column<short>(type: "bit", nullable: false),
                    Awox = table.Column<short>(type: "bit", nullable: false),
                    Esi = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zkb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Victim",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CharacterId = table.Column<long>(nullable: false),
                    AllianceId = table.Column<long>(nullable: false),
                    CorporationId = table.Column<long>(nullable: false),
                    ShipTypeId = table.Column<long>(nullable: false),
                    DamageTaken = table.Column<long>(nullable: false),
                    PositionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Victim_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Flag = table.Column<int>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: false),
                    QuantityDropped = table.Column<long>(nullable: true),
                    QuantityDestroyed = table.Column<long>(nullable: true),
                    Singleton = table.Column<int>(nullable: false),
                    VictimId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Victim_VictimId",
                        column: x => x.VictimId,
                        principalTable: "Victim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Killmails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    KillmailId = table.Column<long>(nullable: false),
                    KillmailTime = table.Column<DateTime>(nullable: false),
                    SolarSystemId = table.Column<long>(nullable: false),
                    VictimId = table.Column<long>(nullable: true),
                    ZkbId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Killmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Killmails_Victim_VictimId",
                        column: x => x.VictimId,
                        principalTable: "Victim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Killmails_Zkb_ZkbId",
                        column: x => x.ZkbId,
                        principalTable: "Zkb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attacker",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CharacterId = table.Column<long>(nullable: false),
                    AllianceId = table.Column<long>(nullable: false),
                    CorporationId = table.Column<long>(nullable: false),
                    ShipTypeId = table.Column<long>(nullable: false),
                    DamageDone = table.Column<long>(nullable: false),
                    FactionId = table.Column<long>(nullable: false),
                    FinalBlow = table.Column<short>(type: "bit", nullable: false),
                    SecurityStatus = table.Column<float>(nullable: false),
                    WeaponTypeID = table.Column<long>(nullable: false),
                    KillmailId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attacker_Killmails_KillmailId",
                        column: x => x.KillmailId,
                        principalTable: "Killmails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Trackers",
                columns: new[] { "Id", "IsAlliance", "TrackerId" },
                values: new object[,]
                {
                    { 1L, (short)0, 98614694L },
                    { 2L, (short)1, 99007237L },
                    { 3L, (short)1, 99003144L },
                    { 4L, (short)1, 99009583L },
                    { 5L, (short)1, 99006113L },
                    { 6L, (short)1, 99006319L },
                    { 7L, (short)1, 99007192L },
                    { 8L, (short)1, 99006117L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attacker_KillmailId",
                table: "Attacker",
                column: "KillmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_VictimId",
                table: "Item",
                column: "VictimId");

            migrationBuilder.CreateIndex(
                name: "IX_Killmails_VictimId",
                table: "Killmails",
                column: "VictimId");

            migrationBuilder.CreateIndex(
                name: "IX_Killmails_ZkbId",
                table: "Killmails",
                column: "ZkbId");

            migrationBuilder.CreateIndex(
                name: "IX_Victim_PositionId",
                table: "Victim",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alliances");

            migrationBuilder.DropTable(
                name: "Attacker");

            migrationBuilder.DropTable(
                name: "Corporations");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Trackers");

            migrationBuilder.DropTable(
                name: "Killmails");

            migrationBuilder.DropTable(
                name: "Victim");

            migrationBuilder.DropTable(
                name: "Zkb");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
