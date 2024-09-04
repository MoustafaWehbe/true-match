using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class hiddenrooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21a62b1d-d676-4eb0-908b-84a92ec6ba8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d38840a-69b7-43ca-b23d-cf0f3ec64496");

            migrationBuilder.CreateTable(
                name: "HiddenRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    HiddenAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiddenRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiddenRooms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiddenRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27bd20a9-dd1a-409a-a902-a3b502ed1bee", null, "User", "USER" },
                    { "5784cb3c-24c1-4e2c-b83e-c1e00acb1501", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8690), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8690) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8700), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8700), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8700), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8700), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8720), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8720), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8720), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8730), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8740), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8740), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8750), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8750), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8750), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8750), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8990), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(9000), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(9000), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(9000), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(9000), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8780), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8780) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8790), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8800), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8810), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8810), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8810), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8810), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8850), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8880), new DateTime(2024, 9, 4, 22, 33, 54, 85, DateTimeKind.Utc).AddTicks(8880) });

            migrationBuilder.CreateIndex(
                name: "IX_HiddenRooms_RoomId",
                table: "HiddenRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HiddenRooms_UserId",
                table: "HiddenRooms",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HiddenRooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27bd20a9-dd1a-409a-a902-a3b502ed1bee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5784cb3c-24c1-4e2c-b83e-c1e00acb1501");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21a62b1d-d676-4eb0-908b-84a92ec6ba8e", null, "Admin", "ADMIN" },
                    { "6d38840a-69b7-43ca-b23d-cf0f3ec64496", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(780), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(780) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(780), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(780) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(790), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(790), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(790), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(810), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(810), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(810), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(810), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(820), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(820), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(830), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(830), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(830), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(830), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(860), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(860), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(890), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(900), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(930), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(940), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(970), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(970), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(970), new DateTime(2024, 9, 4, 21, 23, 23, 495, DateTimeKind.Utc).AddTicks(970) });
        }
    }
}
