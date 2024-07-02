using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class mediaAndUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7bd53b8-4d47-450e-bf57-fcae596c4cbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5160ba8-0454-4152-a0b4-1d44c6fb3461");

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MediaType = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    RelationshipGoal = table.Column<string>(type: "text", nullable: false),
                    Education = table.Column<string>(type: "text", nullable: false),
                    Zodiac = table.Column<string>(type: "text", nullable: false),
                    LoveStyle = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45b9c87d-40ba-4b31-86a3-fa8340cbd6a6", null, "Admin", "ADMIN" },
                    { "c1b25d9c-1fb3-4d73-bd8c-dbedeb4d2f76", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050), new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050), new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050), new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050), new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050), new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4080), new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4080), new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4090), new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "LifeStyles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4090), new DateTime(2024, 7, 2, 14, 33, 40, 974, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.CreateIndex(
                name: "IX_Media_UserId",
                table: "Media",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45b9c87d-40ba-4b31-86a3-fa8340cbd6a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1b25d9c-1fb3-4d73-bd8c-dbedeb4d2f76");

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
        }
    }
}
