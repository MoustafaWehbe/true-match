using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LifeStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User1Id = table.Column<string>(type: "text", nullable: false),
                    User2Id = table.Column<string>(type: "text", nullable: false),
                    Origin = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_AspNetUsers_User1Id",
                        column: x => x.User1Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_AspNetUsers_User2Id",
                        column: x => x.User2Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Offers = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    QuestionsCategories = table.Column<List<int>>(type: "integer[]", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_AspNetUsers_UserId",
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
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Nationality = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    PlaceToLive = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Bio = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Height = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    RelationshipGoal = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Education = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Zodiac = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    LoveStyle = table.Column<string>(type: "VARCHAR(50)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "SystemQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemQuestions_QuestionCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "QuestionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomParticipants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomParticipants_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileInterests",
                columns: table => new
                {
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    InterestId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileInterests", x => new { x.UserProfileId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_UserProfileInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileInterests_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileLifeStyles",
                columns: table => new
                {
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    LifeStyleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileLifeStyles", x => new { x.UserProfileId, x.LifeStyleId });
                    table.ForeignKey(
                        name: "FK_UserProfileLifeStyles_LifeStyles_LifeStyleId",
                        column: x => x.LifeStyleId,
                        principalTable: "LifeStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileLifeStyles_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomParticipantEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomParticipantId = table.Column<int>(type: "integer", nullable: false),
                    Left = table.Column<bool>(type: "boolean", nullable: false),
                    AttendedFromTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AttendedToTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SocketId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomParticipantEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomParticipantEvents_RoomParticipants_RoomParticipantId",
                        column: x => x.RoomParticipantId,
                        principalTable: "RoomParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50b5cd97-dc68-4c0c-8e9b-a2d136f82b18", null, "Admin", "ADMIN" },
                    { "b28eabad-63d4-467a-8acf-c0f46b3a54a4", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(500), "Travel", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(500) },
                    { 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(510), "Cooking", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(510) },
                    { 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(510), "Sports", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(510) },
                    { 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(510), "Music", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(510) },
                    { 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(510), "Movies", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(510) }
                });

            migrationBuilder.InsertData(
                table: "LifeStyles",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(530), "Smoking", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(530) },
                    { 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(530), "Workout", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(530) },
                    { 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(530), "Drinking", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(530) },
                    { 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(540), "Pets", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(540) }
                });

            migrationBuilder.InsertData(
                table: "QuestionCategories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(540), "Sexual", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(540) },
                    { 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550), "Funny", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550) },
                    { 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550), "Flirty", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550) },
                    { 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550), "Edgy", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550) },
                    { 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550), "Connection-building", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550) },
                    { 6, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550), "Dilemma", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(550) }
                });

            migrationBuilder.InsertData(
                table: "RoomContent",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Order", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(760), "Give us the scoop on the person behind the screen!", 10m, 1, "Meet & Greet", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(760) },
                    { 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(760), "Share your passions and two quirky facts about yourself!", 120m, 2, "Hobby Showcase & Fun Fact Extravaganza", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(760) },
                    { 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(770), "Brace yourself for some off-the-wall questions and give your best answers within the time limit!", 300m, 3, "Random Question Roulette", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(770) },
                    { 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(770), "Get ready to field questions from your adoring audience!", 300m, 4, "Spotlight Q&A", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(770) },
                    { 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(770), "Pop your best question to the remaining contenders, and whoever nails it gets the match!", 60m, 5, "The Final Rose", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(770) }
                });

            migrationBuilder.InsertData(
                table: "SystemQuestions",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(590), "What physical act gives you the most pleasure?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(590) },
                    { 2, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(590), "Do you prefer firm or light touches?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(590) },
                    { 3, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(590), "Do guy-on-guy videos turn you on more than guy-on-girl?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(590) },
                    { 4, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(590), "Do you think it’s okay if a guy wants to be submissive in the bedroom?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600) },
                    { 5, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600), "Would you rather receive or give oral?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600) },
                    { 6, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600), "Do you prefer to make out with the lights on or off?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600) },
                    { 7, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600), "Would you rather end a good first date with a passionate kiss or sex?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600) },
                    { 8, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600), "Are you more dominant or submissive in bed?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600) },
                    { 9, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600), "What do you fantasize about when you touch yourself?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600) },
                    { 10, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600), "Do you like to roleplay?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600) },
                    { 11, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600), "Have you ever had sex with someone you just met?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600) },
                    { 12, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600), "What’s the dirtiest thought you’ve ever had about a stranger?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600) },
                    { 13, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(600), "What does your ideal one-night stand look like?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 14, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "If a cute couple asked you to do a threesome, would you say yes?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 15, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "What are your thoughts on toys?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 16, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "What’s the dirtiest thing someone said to you during sex?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 17, 1, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "Where do you like to be touched most?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 18, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "What meal or snack will you never refuse?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 19, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "Zombies are overrunning the world. How do you defend yourself?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 20, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "What’s the weirdest thing you carry in your purse?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 21, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "Do you think that men can be gynecologists? (Second question) What if he sniffs his finger?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 22, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "What was the last time you went skinny dipping?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610) },
                    { 23, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(610), "Would you date someone who’s cute but mega dumb?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 24, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "What’s the last time you did something scary?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 25, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "You have to assassinate someone who really deserves it. How do you do it?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 26, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "If your friends and family hear that you were arrested, what would they think you did?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 27, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "You and all your friends have to enter a mixed martial arts tournament. Do you win?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 28, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "You’re on a first date with a dude you like and you let out an audible fart. What do you do?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 29, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "You find out your best friend is a lesbian and she’s in love with you. How do you react?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 30, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "Do you prefer the smell of freshly cut grass or freshly baked bread?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 31, 2, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "You’re at a party and really need to drop a deuce. But their toilet doesn’t flush. Do you use the toilet anyway, or do your business in the yard?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 32, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "What’s your favorite way to be seduced by a man?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 33, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620), "What do you miss most about being single? (She has to pick something.)", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(620) },
                    { 34, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "What’s the best romantic surprise you’ve ever had?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 35, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "What do you find the most attractive in a man?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 36, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "What does good sex mean to you?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 37, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "What are your biggest turn-offs?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 38, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "What do you think is the most important thing a woman can give to a man?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 39, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "What makes you feel sexy?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 40, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "What’s the hottest thing a guy can do for you?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 41, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "Can you surrender to love or is it something that scares you?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 42, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "Do you prefer cuddling or kissing?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 43, 3, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "What do you wear when you go to sleep?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 44, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "Would you rather have a cat with a human face or a dog with human hands?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 45, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630), "Would you rather have a boyfriend who’s stinking rich and ugly? Or a friend who’s dirt poor and handsome?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(630) },
                    { 46, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640), "Would you rather have hiccups for the rest of your life or constantly feel like you have to sneeze?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640) },
                    { 47, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640), "Would you rather fight young Mike Tyson once or talk like Mike Tyson for the rest of your life?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640) },
                    { 48, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640), "Would you rather be surrounded by people who brag all the time or by people who constantly complain?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640) },
                    { 49, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640), "Would you rather speak every language fluently or play every instrument perfectly?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640) },
                    { 50, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640), "Would you rather Win $50,000 or let your best friend win $500,000?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640) },
                    { 51, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640), "Would you rather be stung by a thousand bees or stomp a kitten?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640) },
                    { 52, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640), "Would you rather be with the person you love forever, but also wear a shirt made out of their pubes, or be alone for the rest of your life but wear whatever you want?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640) },
                    { 53, 4, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640), "Your dad and boyfriend switch bodies (Freaky Friday style). The only way to switch them back is to have sex with them, lights on and sober. Who do you pick?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(640) },
                    { 54, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(660), "Name three things that you can do to get out of a funk.", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(660) },
                    { 55, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(660), "What’s a recent book you read or movie you saw that taught you something?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(660) },
                    { 56, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(660), "Would you rather travel to the past or the future?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(660) },
                    { 57, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(660), "If you could travel the universe on the condition that you were never allowed to set foot on earth again, would you go?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(660) },
                    { 58, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(660), "If you could make one decision to change the world, what would you do?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 59, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "What’s the first thing you do when you get back home from work?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 60, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "If you could ask your pet 3 questions, what would they be?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 70, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "What’s something you’d like to be remembered for?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 71, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "Is there a way you could fall head over heels for a man? What would that look like?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 72, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "What’s the most romantic thing you’ve ever done for someone?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 73, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "If you were the mayor of your city, what rule would you instantly enforce?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 74, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "What’s your favorite and least favorite household chore?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 75, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "What’s one responsibility of yours that you’d prefer to delegate to a professional?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 76, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "What’s something you’ve always wanted to do, but haven’t?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 77, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670), "Would you continue working if you were rich and didn’t need to?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(670) },
                    { 78, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "What does your ideal night look like? Do you go out or are you at home with friends?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 79, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "If you could change one thing about the way you were raised, what would that be?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 80, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "What’s something that gives your life meaning?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 90, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "What dating advice would you give your younger self?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 91, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "What song would you want to play on your wedding day?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 92, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "What would you like to get for your birthday?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 93, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "If you could only put on one piece of makeup, what would it be?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 94, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "What’s the one compliment you get the most?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 95, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "Where do you feel the most at home?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 96, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "What do you wish you cared less about?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 97, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "What do your friends and family call you?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 98, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680), "Where do you go if you want to escape?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(680) },
                    { 99, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "What’s something you swear by?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 100, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "What’s the most important thing your life is missing?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 101, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "What do you wish more people knew about you?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 102, 5, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "How long ago did you tell someone you loved them?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 103, 6, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "Flight or invisibility?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 104, 6, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "Peanut butter or Nutella?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 105, 6, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "Quit coffee or never have snacks during films and series?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 106, 6, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "Bath or shower?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 107, 6, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "Love or money?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 108, 6, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "Burger or pizza?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) },
                    { 109, 6, new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690), "Dine-in or delivery?", new DateTime(2024, 9, 2, 9, 42, 45, 275, DateTimeKind.Utc).AddTicks(690) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_User1Id",
                table: "Matches",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_User2Id",
                table: "Matches",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Media_UserId",
                table: "Media",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomParticipantEvents_RoomParticipantId",
                table: "RoomParticipantEvents",
                column: "RoomParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomParticipants_RoomId",
                table: "RoomParticipants",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomParticipants_UserId",
                table: "RoomParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemQuestions_CategoryId",
                table: "SystemQuestions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileInterests_InterestId",
                table: "UserProfileInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileLifeStyles_LifeStyleId",
                table: "UserProfileLifeStyles",
                column: "LifeStyleId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "RoomContent");

            migrationBuilder.DropTable(
                name: "RoomParticipantEvents");

            migrationBuilder.DropTable(
                name: "SystemQuestions");

            migrationBuilder.DropTable(
                name: "UserProfileInterests");

            migrationBuilder.DropTable(
                name: "UserProfileLifeStyles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RoomParticipants");

            migrationBuilder.DropTable(
                name: "QuestionCategories");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "LifeStyles");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
