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
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Offers = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    QuestionsCategories = table.Column<List<int>>(type: "integer[]", nullable: false),
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
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsInterested = table.Column<bool>(type: "boolean", nullable: false),
                    Attended = table.Column<bool>(type: "boolean", nullable: false),
                    AttendedFromTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AttendedToTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SocketId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomParticipants", x => new { x.RoomId, x.UserId });
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13c2733a-dc50-42ff-865d-770ee9d7c205", null, "Admin", "ADMIN" },
                    { "7efdfe83-cb0e-49f6-bb06-cedb225d23dc", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2530), "Travel", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2530) },
                    { 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2530), "Cooking", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2530) },
                    { 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2540), "Sports", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2540) },
                    { 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2540), "Music", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2540) },
                    { 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2540), "Movies", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2540) }
                });

            migrationBuilder.InsertData(
                table: "LifeStyles",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2560), "Smoking", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2560) },
                    { 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2570), "Workout", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2570) },
                    { 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2570), "Drinking", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2570) },
                    { 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2570), "Pets", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2570) }
                });

            migrationBuilder.InsertData(
                table: "QuestionCategories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580), "Sexual", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580) },
                    { 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580), "Funny", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580) },
                    { 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580), "Flirty", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580) },
                    { 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580), "Edgy", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580) },
                    { 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580), "Connection-building", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580) },
                    { 6, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580), "Dilemma", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2580) }
                });

            migrationBuilder.InsertData(
                table: "RoomContent",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Order", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2770), "Give us the scoop on the person behind the screen!", 10m, 1, "Meet & Greet", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2770) },
                    { 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2780), "Share your passions and two quirky facts about yourself!", 120m, 2, "Hobby Showcase & Fun Fact Extravaganza", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2780) },
                    { 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2780), "Brace yourself for some off-the-wall questions and give your best answers within the time limit!", 300m, 3, "Random Question Roulette", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2780) },
                    { 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2780), "Get ready to field questions from your adoring audience!", 300m, 4, "Spotlight Q&A", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2780) },
                    { 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2780), "Pop your best question to the remaining contenders, and whoever nails it gets the match!", 60m, 5, "The Final Rose", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2780) }
                });

            migrationBuilder.InsertData(
                table: "SystemQuestions",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620), "What physical act gives you the most pleasure?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620) },
                    { 2, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620), "Do you prefer firm or light touches?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620) },
                    { 3, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620), "Do guy-on-guy videos turn you on more than guy-on-girl?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620) },
                    { 4, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620), "Do you think it’s okay if a guy wants to be submissive in the bedroom?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620) },
                    { 5, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620), "Would you rather receive or give oral?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620) },
                    { 6, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620), "Do you prefer to make out with the lights on or off?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620) },
                    { 7, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620), "Would you rather end a good first date with a passionate kiss or sex?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2620) },
                    { 8, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "Are you more dominant or submissive in bed?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 9, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "What do you fantasize about when you touch yourself?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 10, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "Do you like to roleplay?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 11, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "Have you ever had sex with someone you just met?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 12, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "What’s the dirtiest thought you’ve ever had about a stranger?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 13, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "What does your ideal one-night stand look like?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 14, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "If a cute couple asked you to do a threesome, would you say yes?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 15, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "What are your thoughts on toys?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 16, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "What’s the dirtiest thing someone said to you during sex?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 17, 1, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630), "Where do you like to be touched most?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2630) },
                    { 18, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640), "What meal or snack will you never refuse?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640) },
                    { 19, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640), "Zombies are overrunning the world. How do you defend yourself?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640) },
                    { 20, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640), "What’s the weirdest thing you carry in your purse?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640) },
                    { 21, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640), "Do you think that men can be gynecologists? (Second question) What if he sniffs his finger?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640) },
                    { 22, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640), "What was the last time you went skinny dipping?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640) },
                    { 23, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640), "Would you date someone who’s cute but mega dumb?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640) },
                    { 24, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640), "What’s the last time you did something scary?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640) },
                    { 25, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640), "You have to assassinate someone who really deserves it. How do you do it?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2640) },
                    { 26, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650), "If your friends and family hear that you were arrested, what would they think you did?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650) },
                    { 27, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650), "You and all your friends have to enter a mixed martial arts tournament. Do you win?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650) },
                    { 28, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650), "You’re on a first date with a dude you like and you let out an audible fart. What do you do?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650) },
                    { 29, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650), "You find out your best friend is a lesbian and she’s in love with you. How do you react?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650) },
                    { 30, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650), "Do you prefer the smell of freshly cut grass or freshly baked bread?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650) },
                    { 31, 2, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650), "You’re at a party and really need to drop a deuce. But their toilet doesn’t flush. Do you use the toilet anyway, or do your business in the yard?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650) },
                    { 32, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650), "What’s your favorite way to be seduced by a man?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650) },
                    { 33, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650), "What do you miss most about being single? (She has to pick something.)", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650) },
                    { 34, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650), "What’s the best romantic surprise you’ve ever had?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2650) },
                    { 35, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "What do you find the most attractive in a man?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 36, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "What does good sex mean to you?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 37, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "What are your biggest turn-offs?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 38, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "What do you think is the most important thing a woman can give to a man?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 39, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "What makes you feel sexy?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 40, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "What’s the hottest thing a guy can do for you?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 41, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "Can you surrender to love or is it something that scares you?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 42, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "Do you prefer cuddling or kissing?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 43, 3, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "What do you wear when you go to sleep?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 44, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "Would you rather have a cat with a human face or a dog with human hands?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 45, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "Would you rather have a boyfriend who’s stinking rich and ugly? Or a friend who’s dirt poor and handsome?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660) },
                    { 46, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2660), "Would you rather have hiccups for the rest of your life or constantly feel like you have to sneeze?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 47, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "Would you rather fight young Mike Tyson once or talk like Mike Tyson for the rest of your life?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 48, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "Would you rather be surrounded by people who brag all the time or by people who constantly complain?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 49, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "Would you rather speak every language fluently or play every instrument perfectly?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 50, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "Would you rather Win $50,000 or let your best friend win $500,000?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 51, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "Would you rather be stung by a thousand bees or stomp a kitten?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 52, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "Would you rather be with the person you love forever, but also wear a shirt made out of their pubes, or be alone for the rest of your life but wear whatever you want?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 53, 4, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "Your dad and boyfriend switch bodies (Freaky Friday style). The only way to switch them back is to have sex with them, lights on and sober. Who do you pick?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 54, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "Name three things that you can do to get out of a funk.", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 55, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "What’s a recent book you read or movie you saw that taught you something?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 56, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "Would you rather travel to the past or the future?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 57, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670), "If you could travel the universe on the condition that you were never allowed to set foot on earth again, would you go?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2670) },
                    { 58, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "If you could make one decision to change the world, what would you do?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 59, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "What’s the first thing you do when you get back home from work?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 60, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "If you could ask your pet 3 questions, what would they be?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 70, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "What’s something you’d like to be remembered for?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 71, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "Is there a way you could fall head over heels for a man? What would that look like?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 72, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "What’s the most romantic thing you’ve ever done for someone?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 73, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "If you were the mayor of your city, what rule would you instantly enforce?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 74, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "What’s your favorite and least favorite household chore?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 75, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "What’s one responsibility of yours that you’d prefer to delegate to a professional?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 76, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "What’s something you’ve always wanted to do, but haven’t?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 77, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680), "Would you continue working if you were rich and didn’t need to?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2680) },
                    { 78, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "What does your ideal night look like? Do you go out or are you at home with friends?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 79, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "If you could change one thing about the way you were raised, what would that be?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 80, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "What’s something that gives your life meaning?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 90, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "What dating advice would you give your younger self?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 91, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "What song would you want to play on your wedding day?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 92, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "What would you like to get for your birthday?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 93, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "If you could only put on one piece of makeup, what would it be?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 94, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "What’s the one compliment you get the most?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 95, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "Where do you feel the most at home?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 96, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "What do you wish you cared less about?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 97, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690), "What do your friends and family call you?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2690) },
                    { 98, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "Where do you go if you want to escape?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 99, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "What’s something you swear by?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 100, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "What’s the most important thing your life is missing?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 101, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "What do you wish more people knew about you?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 102, 5, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "How long ago did you tell someone you loved them?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 103, 6, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "Flight or invisibility?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 104, 6, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "Peanut butter or Nutella?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 105, 6, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "Quit coffee or never have snacks during films and series?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 106, 6, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "Bath or shower?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 107, 6, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "Love or money?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 108, 6, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "Burger or pizza?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700) },
                    { 109, 6, new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2700), "Dine-in or delivery?", new DateTime(2024, 8, 25, 23, 8, 27, 157, DateTimeKind.Utc).AddTicks(2710) }
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
                name: "RoomParticipants");

            migrationBuilder.DropTable(
                name: "SystemQuestions");

            migrationBuilder.DropTable(
                name: "UserProfileInterests");

            migrationBuilder.DropTable(
                name: "UserProfileLifeStyles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "QuestionCategories");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "LifeStyles");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
