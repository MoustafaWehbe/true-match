﻿using System;
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
                name: "LiveStreamContent",
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
                    table.PrimaryKey("PK_LiveStreamContent", x => x.Id);
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
                name: "LiveStreams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HasStarted = table.Column<bool>(type: "boolean", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveStreams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveStreams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Nationality = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    PlaceToLive = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Bio = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Height = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
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
                    { "82b37f02-0af9-4d4a-91d8-95f3bc0faf20", null, "Admin", "ADMIN" },
                    { "eb5405a2-f2cc-4c91-8b55-dd2f56503971", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6840), "Travel", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6840) },
                    { 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6840), "Cooking", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6840) },
                    { 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850), "Sports", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850) },
                    { 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850), "Music", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850) },
                    { 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850), "Movies", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6850) }
                });

            migrationBuilder.InsertData(
                table: "LifeStyles",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870), "Smoking", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870) },
                    { 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870), "Workout", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870) },
                    { 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870), "Drinking", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870) },
                    { 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870), "Pets", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6870) }
                });

            migrationBuilder.InsertData(
                table: "QuestionCategories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), "Sexual", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880) },
                    { 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), "Funny", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880) },
                    { 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), "Flirty", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880) },
                    { 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), "Edgy", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880) },
                    { 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6880), "Connection-building", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6890) },
                    { 6, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6890), "Dilemma", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6890) }
                });

            migrationBuilder.InsertData(
                table: "SystemQuestions",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), "What physical act gives you the most pleasure?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) },
                    { 2, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), "Do you prefer firm or light touches?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) },
                    { 3, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), "Do guy-on-guy videos turn you on more than guy-on-girl?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) },
                    { 4, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), "Do you think it’s okay if a guy wants to be submissive in the bedroom?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) },
                    { 5, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), "Would you rather receive or give oral?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) },
                    { 6, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930), "Do you prefer to make out with the lights on or off?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6930) },
                    { 7, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "Would you rather end a good first date with a passionate kiss or sex?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 8, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "Are you more dominant or submissive in bed?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 9, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "What do you fantasize about when you touch yourself?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 10, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "Do you like to roleplay?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 11, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "Have you ever had sex with someone you just met?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 12, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "What’s the dirtiest thought you’ve ever had about a stranger?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 13, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "What does your ideal one-night stand look like?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 14, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "If a cute couple asked you to do a threesome, would you say yes?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 15, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "What are your thoughts on toys?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 16, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "What’s the dirtiest thing someone said to you during sex?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 17, 1, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940), "Where do you like to be touched most?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6940) },
                    { 18, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "What meal or snack will you never refuse?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 19, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "Zombies are overrunning the world. How do you defend yourself?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 20, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "What’s the weirdest thing you carry in your purse?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 21, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "Do you think that men can be gynecologists? (Second question) What if he sniffs his finger?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 22, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "What was the last time you went skinny dipping?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 23, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "Would you date someone who’s cute but mega dumb?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 24, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "What’s the last time you did something scary?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 25, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "You have to assassinate someone who really deserves it. How do you do it?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 26, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "If your friends and family hear that you were arrested, what would they think you did?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 27, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "You and all your friends have to enter a mixed martial arts tournament. Do you win?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 28, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950), "You’re on a first date with a dude you like and you let out an audible fart. What do you do?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6950) },
                    { 29, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), "You find out your best friend is a lesbian and she’s in love with you. How do you react?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) },
                    { 30, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), "Do you prefer the smell of freshly cut grass or freshly baked bread?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) },
                    { 31, 2, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), "You’re at a party and really need to drop a deuce. But their toilet doesn’t flush. Do you use the toilet anyway, or do your business in the yard?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) },
                    { 32, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), "What’s your favorite way to be seduced by a man?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) },
                    { 33, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), "What do you miss most about being single? (She has to pick something.)", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) },
                    { 34, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960), "What’s the best romantic surprise you’ve ever had?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6960) },
                    { 35, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "What do you find the most attractive in a man?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 36, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "What does good sex mean to you?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 37, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "What are your biggest turn-offs?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 38, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "What do you think is the most important thing a woman can give to a man?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 39, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "What makes you feel sexy?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 40, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "What’s the hottest thing a guy can do for you?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 41, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "Can you surrender to love or is it something that scares you?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 42, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "Do you prefer cuddling or kissing?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 43, 3, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "What do you wear when you go to sleep?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 44, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "Would you rather have a cat with a human face or a dog with human hands?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 45, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "Would you rather have a boyfriend who’s stinking rich and ugly? Or a friend who’s dirt poor and handsome?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 46, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "Would you rather have hiccups for the rest of your life or constantly feel like you have to sneeze?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970) },
                    { 47, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6970), "Would you rather fight young Mike Tyson once or talk like Mike Tyson for the rest of your life?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 48, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "Would you rather be surrounded by people who brag all the time or by people who constantly complain?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 49, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "Would you rather speak every language fluently or play every instrument perfectly?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 50, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "Would you rather Win $50,000 or let your best friend win $500,000?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 51, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "Would you rather be stung by a thousand bees or stomp a kitten?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 52, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "Would you rather be with the person you love forever, but also wear a shirt made out of their pubes, or be alone for the rest of your life but wear whatever you want?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 53, 4, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "Your dad and boyfriend switch bodies (Freaky Friday style). The only way to switch them back is to have sex with them, lights on and sober. Who do you pick?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 54, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "Name three things that you can do to get out of a funk.", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 55, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "What’s a recent book you read or movie you saw that taught you something?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 56, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "Would you rather travel to the past or the future?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 57, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "If you could travel the universe on the condition that you were never allowed to set foot on earth again, would you go?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 58, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980), "If you could make one decision to change the world, what would you do?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6980) },
                    { 59, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "What’s the first thing you do when you get back home from work?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 60, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "If you could ask your pet 3 questions, what would they be?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 70, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "What’s something you’d like to be remembered for?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 71, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "Is there a way you could fall head over heels for a man? What would that look like?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 72, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "What’s the most romantic thing you’ve ever done for someone?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 73, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "If you were the mayor of your city, what rule would you instantly enforce?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 74, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "What’s your favorite and least favorite household chore?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 75, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "What’s one responsibility of yours that you’d prefer to delegate to a professional?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 76, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "What’s something you’ve always wanted to do, but haven’t?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 77, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "Would you continue working if you were rich and didn’t need to?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 78, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990), "What does your ideal night look like? Do you go out or are you at home with friends?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(6990) },
                    { 79, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "If you could change one thing about the way you were raised, what would that be?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 80, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "What’s something that gives your life meaning?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 90, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "What dating advice would you give your younger self?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 91, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "What song would you want to play on your wedding day?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 92, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "What would you like to get for your birthday?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 93, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "If you could only put on one piece of makeup, what would it be?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 94, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "What’s the one compliment you get the most?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 95, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "Where do you feel the most at home?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 96, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "What do you wish you cared less about?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 97, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "What do your friends and family call you?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 98, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000), "Where do you go if you want to escape?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7000) },
                    { 99, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "What’s something you swear by?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 100, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "What’s the most important thing your life is missing?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 101, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "What do you wish more people knew about you?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 102, 5, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "How long ago did you tell someone you loved them?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 103, 6, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "Flight or invisibility?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 104, 6, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "Peanut butter or Nutella?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 105, 6, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "Quit coffee or never have snacks during films and series?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 106, 6, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "Bath or shower?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 107, 6, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "Love or money?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 108, 6, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "Burger or pizza?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) },
                    { 109, 6, new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010), "Dine-in or delivery?", new DateTime(2024, 7, 15, 20, 22, 2, 161, DateTimeKind.Utc).AddTicks(7010) }
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
                name: "IX_LiveStreamParticipants_UserId",
                table: "LiveStreamParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveStreams_UserId",
                table: "LiveStreams",
                column: "UserId");

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
                name: "LiveStreamContent");

            migrationBuilder.DropTable(
                name: "LiveStreamParticipants");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "SystemQuestions");

            migrationBuilder.DropTable(
                name: "UserProfileInterests");

            migrationBuilder.DropTable(
                name: "UserProfileLifeStyles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "LiveStreams");

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
