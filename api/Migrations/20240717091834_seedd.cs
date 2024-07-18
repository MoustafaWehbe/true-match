using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class seedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiveStreams_AspNetUsers_UserId",
                table: "LiveStreams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82b37f02-0af9-4d4a-91d8-95f3bc0faf20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb5405a2-f2cc-4c91-8b55-dd2f56503971");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LiveStreams",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57d55e68-f426-433e-8350-c040b7f63733", null, "Admin", "ADMIN" },
                    { "5a16270f-0d2e-44b2-8288-9e7bffbbdba2", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3500), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3500), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3500), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3500), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3510), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3540), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3540), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3540), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3540), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.InsertData(
                table: "LiveStreamContent",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Order", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3840), "Give us the scoop on the person behind the screen!", 10m, 1, "Meet & Greet", new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3840) },
                    { 2, new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3840), "Share your passions and two quirky facts about yourself!", 120m, 2, "Hobby Showcase & Fun Fact Extravaganza", new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3840) },
                    { 3, new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3840), "Brace yourself for some off-the-wall questions and give your best answers within the time limit!", 300m, 3, "Random Question Roulette", new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3840) },
                    { 4, new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3850), "Get ready to field questions from your adoring audience!", 300m, 4, "Spotlight Q&A", new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3850) },
                    { 5, new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3850), "Pop your best question to the remaining contenders, and whoever nails it gets the match!", 60m, 5, "The Final Rose", new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3850) }
                });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3550), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3550) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3600), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3600), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3600), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3610), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3610), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3630), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3630), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3640), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3640) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3690), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3750), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3750) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3750), new DateTime(2024, 7, 17, 9, 18, 33, 824, DateTimeKind.Utc).AddTicks(3750) });

            migrationBuilder.AddForeignKey(
                name: "FK_LiveStreams_AspNetUsers_UserId",
                table: "LiveStreams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiveStreams_AspNetUsers_UserId",
                table: "LiveStreams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57d55e68-f426-433e-8350-c040b7f63733");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a16270f-0d2e-44b2-8288-9e7bffbbdba2");

            migrationBuilder.DeleteData(
                table: "LiveStreamContent",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LiveStreamContent",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LiveStreamContent",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LiveStreamContent",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LiveStreamContent",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LiveStreams",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82b37f02-0af9-4d4a-91d8-95f3bc0faf20", null, "Admin", "ADMIN" },
                    { "eb5405a2-f2cc-4c91-8b55-dd2f56503971", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6840), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6840), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6890), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.AddForeignKey(
                name: "FK_LiveStreams_AspNetUsers_UserId",
                table: "LiveStreams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
