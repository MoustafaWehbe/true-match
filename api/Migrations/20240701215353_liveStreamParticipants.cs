using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class liveStreamParticipants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f55c99b-7c1b-4ef8-9505-646dcffb3d0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84fdb6a6-71be-44ab-acfc-2e18caf3576f");

            migrationBuilder.CreateTable(
                name: "LiveStreamParticipants",
                columns: table => new
                {
                    LiveStreamId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsInterested = table.Column<bool>(type: "boolean", nullable: false),
                    Attended = table.Column<bool>(type: "boolean", nullable: false),
                    AttendedFromTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AttendedToTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveStreamParticipants", x => new { x.LiveStreamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LiveStreamParticipants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiveStreamParticipants_LiveStreams_LiveStreamId",
                        column: x => x.LiveStreamId,
                        principalTable: "LiveStreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d7bd53b8-4d47-450e-bf57-fcae596c4cbd", null, "Admin", "ADMIN" },
                    { "f5160ba8-0454-4152-a0b4-1d44c6fb3461", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(1990), new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(1990) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000), new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000), new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000), new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000), new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020), new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020), new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020), new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2030), new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2030) });

            migrationBuilder.CreateIndex(
                name: "IX_LiveStreamParticipants_UserId",
                table: "LiveStreamParticipants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiveStreamParticipants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7bd53b8-4d47-450e-bf57-fcae596c4cbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5160ba8-0454-4152-a0b4-1d44c6fb3461");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f55c99b-7c1b-4ef8-9505-646dcffb3d0d", null, "Admin", "ADMIN" },
                    { "84fdb6a6-71be-44ab-acfc-2e18caf3576f", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020), new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020), new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020), new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020), new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020), new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2020) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2050), new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2050), new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2050), new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2050), new DateTime(2024, 7, 1, 21, 28, 15, 371, DateTimeKind.Utc).AddTicks(2050) });
        }
    }
}
