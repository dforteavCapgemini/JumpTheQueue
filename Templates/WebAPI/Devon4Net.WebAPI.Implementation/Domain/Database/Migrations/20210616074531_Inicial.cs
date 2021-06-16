using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Devon4Net.WebAPI.Implementation.Domain.Database.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyQueues",
                columns: table => new
                {
                    DailyQueueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CurrentNumber = table.Column<int>(nullable: false),
                    AttentionTime = table.Column<DateTime>(nullable: false),
                    MinAttentionTime = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Customers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyQueues", x => x.DailyQueueId);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AcceptedCommercial = table.Column<bool>(nullable: false),
                    AcceptedTerms = table.Column<bool>(nullable: false),
                    UserType = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                });

            migrationBuilder.CreateTable(
                name: "AccessCodes",
                columns: table => new
                {
                    AccessCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Endtime = table.Column<DateTime>(nullable: false),
                    VisitorId = table.Column<int>(nullable: false),
                    DailyQueueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCodes", x => x.AccessCodeId);
                    table.ForeignKey(
                        name: "FK_AccessCodes_DailyQueues_DailyQueueId",
                        column: x => x.DailyQueueId,
                        principalTable: "DailyQueues",
                        principalColumn: "DailyQueueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessCodes_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "VisitorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DailyQueues",
                columns: new[] { "DailyQueueId", "Active", "AttentionTime", "CurrentNumber", "Customers", "Logo", "MinAttentionTime", "Name", "Password" },
                values: new object[] { 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9, "C:/logos/Day1Logo.png", new DateTime(1970, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified), "Day2", null });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "VisitorId", "AcceptedCommercial", "AcceptedTerms", "Name", "Password", "PhoneNumber", "UserType", "Username" },
                values: new object[,]
                {
                    { -1, false, true, "test", "123456789", "0", true, "mike@mail.com" },
                    { 1, true, true, "test", "123456789", "1", false, "peter@mail.com" },
                    { 2, true, true, "test", "123456789", "0", false, "pablo@mail.com" },
                    { 3, true, true, "test", "123456789", "0", false, "test1@mail.com" },
                    { 4, true, true, "test", "123456789", "1", false, "test2@mail.com" },
                    { 5, true, true, "test", "123456789", "0", false, "test3@mail.com" },
                    { 6, true, true, "test", "123456789", "0", false, "test4@mail.com" },
                    { 7, true, true, "test", "123456789", "1", false, "test5@mail.com" },
                    { 8, true, true, "test", "123456789", "0", false, "test6@mail.com" },
                    { 9, true, true, "test", "123456789", "0", false, "test7@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AccessCodes",
                columns: new[] { "AccessCodeId", "CreationTime", "DailyQueueId", "Endtime", "StartTime", "TicketNumber", "VisitorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(1584), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(1947), 1, 1 },
                    { 2, new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2750), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2800), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2850), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2855), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), 5, 5 },
                    { 6, new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2860), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), 6, 6 },
                    { 7, new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2864), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), 7, 7 },
                    { 8, new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2868), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), 8, 8 },
                    { 9, new DateTime(2021, 6, 16, 9, 45, 30, 653, DateTimeKind.Local).AddTicks(2872), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), 9, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessCodes_DailyQueueId",
                table: "AccessCodes",
                column: "DailyQueueId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessCodes_VisitorId",
                table: "AccessCodes",
                column: "VisitorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessCodes");

            migrationBuilder.DropTable(
                name: "DailyQueues");

            migrationBuilder.DropTable(
                name: "Visitors");
        }
    }
}
