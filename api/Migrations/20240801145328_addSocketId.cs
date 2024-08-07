﻿using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class addSocketId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72bee0f9-d80a-42b0-9eb9-bfd654f60d4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbd2f7fb-4ad3-4cd6-ad4c-2772b21953f8");

            migrationBuilder.AddColumn<JsonDocument>(
                name: "Offers",
                table: "Rooms",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocketId",
                table: "RoomParticipants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d58183a-10ad-4f8d-a0fb-d002b9a9b0be", null, "Admin", "ADMIN" },
                    { "68ba09c1-41b3-4b57-b3f9-41b32dcf7005", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5440), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5450), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5450), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5450), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5450), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5470), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5470), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5470), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5470), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5700), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5710), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5710), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5710), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5710), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5520), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5520), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5530), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5550), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5600), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5600), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5630), new DateTime(2024, 8, 1, 14, 53, 27, 744, DateTimeKind.Utc).AddTicks(5630) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d58183a-10ad-4f8d-a0fb-d002b9a9b0be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68ba09c1-41b3-4b57-b3f9-41b32dcf7005");

            migrationBuilder.DropColumn(
                name: "Offers",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "SocketId",
                table: "RoomParticipants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72bee0f9-d80a-42b0-9eb9-bfd654f60d4c", null, "User", "USER" },
                    { "cbd2f7fb-4ad3-4cd6-ad4c-2772b21953f8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6110), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6150), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6150), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6150), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6150), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6170), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6170), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6170), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6180), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6180) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6190), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6190), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6190), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6200), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6200), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6200), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6410), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6410), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6410), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6410), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6420), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6280), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6280), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6280), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6280), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6340), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6340), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6340), new DateTime(2024, 7, 30, 20, 30, 41, 414, DateTimeKind.Utc).AddTicks(6340) });
        }
    }
}