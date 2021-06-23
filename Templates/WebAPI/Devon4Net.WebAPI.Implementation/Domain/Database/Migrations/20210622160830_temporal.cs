using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Devon4Net.WebAPI.Implementation.Domain.Database.Migrations
{
    public partial class temporal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Visitors",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 1,
                columns: new[] { "CreationTime", "StartTime" },
                values: new object[] { new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(1475), new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(1814) });

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: -1,
                column: "UserType",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 1,
                column: "UserType",
                value: true);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 2,
                column: "UserType",
                value: true);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 3,
                column: "UserType",
                value: true);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 4,
                column: "UserType",
                value: true);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 5,
                column: "UserType",
                value: true);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 6,
                column: "UserType",
                value: true);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 7,
                column: "UserType",
                value: true);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 8,
                column: "UserType",
                value: true);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 9,
                column: "UserType",
                value: true);

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "VisitorId", "AcceptedCommercial", "AcceptedTerms", "Name", "Password", "PhoneNumber", "UserType", "Username" },
                values: new object[] { 10, false, true, "testUser", "123456789", "0", true, "true@user.com" });

            migrationBuilder.InsertData(
                table: "AccessCodes",
                columns: new[] { "AccessCodeId", "CreationTime", "DailyQueueId", "Endtime", "StartTime", "TicketNumber", "VisitorId" },
                values: new object[] { 10, new DateTime(2021, 6, 22, 18, 8, 24, 53, DateTimeKind.Local).AddTicks(2558), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 1, 1, 0, DateTimeKind.Unspecified), 10, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Visitors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 1,
                columns: new[] { "CreationTime", "StartTime" },
                values: new object[] { new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(3131), new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(3527) });

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(4275));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "AccessCodes",
                keyColumn: "AccessCodeId",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2021, 6, 18, 13, 4, 10, 19, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: -1,
                column: "UserType",
                value: true);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 1,
                column: "UserType",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 2,
                column: "UserType",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 3,
                column: "UserType",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 4,
                column: "UserType",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 5,
                column: "UserType",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 6,
                column: "UserType",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 7,
                column: "UserType",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 8,
                column: "UserType",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "VisitorId",
                keyValue: 9,
                column: "UserType",
                value: false);
        }
    }
}
