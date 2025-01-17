﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
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
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:messagestatus.message_status", "sent,delivered,read")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

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
                name: "AvailableDescriptors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectionName = table.Column<string>(type: "text", nullable: true),
                    DisplayType = table.Column<string>(type: "text", nullable: true),
                    Prompt = table.Column<string>(type: "text", nullable: true),
                    Descriptors = table.Column<JsonDocument>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableDescriptors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsoA2 = table.Column<string>(type: "text", nullable: true),
                    IsoA3 = table.Column<string>(type: "text", nullable: true),
                    WkbGeometry = table.Column<Geometry>(type: "geometry", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genders_Genders_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "BlockedUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BlockerUserId = table.Column<string>(type: "text", nullable: false),
                    BlockedUserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_AspNetUsers_BlockedUserId",
                        column: x => x.BlockedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_AspNetUsers_BlockerUserId",
                        column: x => x.BlockerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<string>(type: "text", nullable: false),
                    ReceiverId = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Offers = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    RoomStateJson = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    QuestionsCategories = table.Column<List<Guid>>(type: "uuid[]", nullable: false),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Bio = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    AgeFilterMax = table.Column<int>(type: "integer", nullable: true),
                    AgeFilterMin = table.Column<int>(type: "integer", nullable: true),
                    DistanceFilter = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    pos = table.Column<Point>(type: "geometry (point)", nullable: true),
                    Location = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    Job = table.Column<string>(type: "text", nullable: true),
                    School = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    SelectedDescriptors = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    UserProfileGenderPreferences = table.Column<List<Guid>>(type: "uuid[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "HiddenRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "RoomParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NotifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                name: "UserProfileGenders",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    isMain = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileGenders", x => new { x.UserProfileId, x.GenderId });
                    table.ForeignKey(
                        name: "FK_UserProfileGenders_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileGenders_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomParticipantEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomParticipantId = table.Column<Guid>(type: "uuid", nullable: true),
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
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cccb8157-3943-44a8-8c5c-e9171cf9bd2e", null, "Admin", "ADMIN" },
                    { "ef6c560e-da0b-46b4-bba5-eeddf7d5fe60", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AvailableDescriptors",
                columns: new[] { "Id", "Descriptors", "DisplayType", "Prompt", "SectionName" },
                values: new object[,]
                {
                    { 1, System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_30\",\n          \"prompt\": \"Here’s where you can add your height to your profile.\",\n          \"type\": \"measurement\",\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/height@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/height@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 16,\n              \"height\": 16\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/height@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 32,\n              \"height\": 32\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/height@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 48,\n              \"height\": 48\n            }\n          ],\n          \"backgroundText\": \"Add height\",\n          \"measurableDetails\": {\n            \"min\": 90,\n            \"max\": 241,\n            \"unitOfMeasure\": \"cm\",\n            \"defaultUnitOfMeasure\": \"cm\"\n          },\n          \"sectionId\": 1,\n          \"sectionName\": \"Height\",\n          \"matchGroupKey\": \"height\",\n          \"discoveryPreferencesEnabled\": false\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()), "section", "Here’s where you can add your height to your profile", "Height" },
                    { 2, System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_37\",\n          \"type\": \"multiSelectionSet\",\n          \"choices\": [\n            {\n              \"id\": \"it_2275\",\n              \"name\": \"Harry Potter\"\n            },\n            {\n              \"id\": \"it_2033\",\n              \"name\": \"’90s kid\"\n            },\n            {\n              \"id\": \"it_2396\",\n              \"name\": \"SoundCloud\"\n            },\n            {\n              \"id\": \"it_2397\",\n              \"name\": \"Spa\"\n            },\n            {\n              \"id\": \"it_2155\",\n              \"name\": \"Self-care\"\n            },\n            {\n              \"id\": \"it_2276\",\n              \"name\": \"Heavy metal\"\n            },\n            {\n              \"id\": \"it_2031\",\n              \"name\": \"House parties\"\n            },\n            {\n              \"id\": \"it_2152\",\n              \"name\": \"Gin & tonic\"\n            },\n            {\n              \"id\": \"it_2273\",\n              \"name\": \"Gymnastics\"\n            },\n            {\n              \"id\": \"it_2279\",\n              \"name\": \"Hot yoga\"\n            },\n            {\n              \"id\": \"it_2159\",\n              \"name\": \"Meditation\"\n            },\n            {\n              \"id\": \"it_2398\",\n              \"name\": \"Spotify\"\n            },\n            {\n              \"id\": \"it_2035\",\n              \"name\": \"Sushi\"\n            },\n            {\n              \"id\": \"it_2277\",\n              \"name\": \"Hockey\"\n            },\n            {\n              \"id\": \"it_2156\",\n              \"name\": \"Basketball\"\n            },\n            {\n              \"id\": \"it_2036\",\n              \"name\": \"Slam poetry\"\n            },\n            {\n              \"id\": \"it_2278\",\n              \"name\": \"Home workouts\"\n            },\n            {\n              \"id\": \"it_2157\",\n              \"name\": \"Theatre\"\n            },\n            {\n              \"id\": \"it_33\",\n              \"name\": \"Café hopping\"\n            },\n            {\n              \"id\": \"it_36\",\n              \"name\": \"Aquarium\"\n            },\n            {\n              \"id\": \"it_2039\",\n              \"name\": \"Trainers\"\n            },\n            {\n              \"id\": \"it_35\",\n              \"name\": \"Instagram\"\n            },\n            {\n              \"id\": \"it_30\",\n              \"name\": \"Hot springs\"\n            },\n            {\n              \"id\": \"it_31\",\n              \"name\": \"Walking\"\n            },\n            {\n              \"id\": \"it_4\",\n              \"name\": \"Running\"\n            },\n            {\n              \"id\": \"it_7\",\n              \"name\": \"Travel\"\n            },\n            {\n              \"id\": \"it_6\",\n              \"name\": \"Language exchange\"\n            },\n            {\n              \"id\": \"it_9\",\n              \"name\": \"Films\"\n            },\n            {\n              \"id\": \"it_2271\",\n              \"name\": \"Guitarists\"\n            },\n            {\n              \"id\": \"it_2392\",\n              \"name\": \"Social development\"\n            },\n            {\n              \"id\": \"it_2272\",\n              \"name\": \"Gym\"\n            },\n            {\n              \"id\": \"it_2393\",\n              \"name\": \"Social media\"\n            },\n            {\n              \"id\": \"it_2030\",\n              \"name\": \"Hip hop\"\n            },\n            {\n              \"id\": \"it_2390\",\n              \"name\": \"Skincare\"\n            },\n            {\n              \"id\": \"it_2022\",\n              \"name\": \"J-Pop\"\n            },\n            {\n              \"id\": \"it_2386\",\n              \"name\": \"Shisha\"\n            },\n            {\n              \"id\": \"it_2023\",\n              \"name\": \"Cricket\"\n            },\n            {\n              \"id\": \"it_2262\",\n              \"name\": \"Freelance\"\n            },\n            {\n              \"id\": \"it_2389\",\n              \"name\": \"Skateboarding\"\n            },\n            {\n              \"id\": \"it_2268\",\n              \"name\": \"Gospel\"\n            },\n            {\n              \"id\": \"it_27\",\n              \"name\": \"K-Pop\"\n            },\n            {\n              \"id\": \"it_2027\",\n              \"name\": \"Potterhead\"\n            },\n            {\n              \"id\": \"it_26\",\n              \"name\": \"Trying new things\"\n            },\n            {\n              \"id\": \"it_29\",\n              \"name\": \"Photography\"\n            },\n            {\n              \"id\": \"it_2024\",\n              \"name\": \"Bollywood\"\n            },\n            {\n              \"id\": \"it_28\",\n              \"name\": \"Reading\"\n            },\n            {\n              \"id\": \"it_2388\",\n              \"name\": \"Singing\"\n            },\n            {\n              \"id\": \"it_23\",\n              \"name\": \"Sports\"\n            },\n            {\n              \"id\": \"it_2028\",\n              \"name\": \"Poetry\"\n            },\n            {\n              \"id\": \"it_2029\",\n              \"name\": \"Stand-up comedy\"\n            },\n            {\n              \"id\": \"it_1\",\n              \"name\": \"Coffee\"\n            },\n            {\n              \"id\": \"it_3\",\n              \"name\": \"Karaoke\"\n            },\n            {\n              \"id\": \"it_2260\",\n              \"name\": \"Fortnite\"\n            },\n            {\n              \"id\": \"it_2261\",\n              \"name\": \"Free diving\"\n            },\n            {\n              \"id\": \"it_2382\",\n              \"name\": \"Self-development\"\n            },\n            {\n              \"id\": \"it_2055\",\n              \"name\": \"Mental health awareness\"\n            },\n            {\n              \"id\": \"it_19\",\n              \"name\": \"Foodie tour\"\n            },\n            {\n              \"id\": \"it_2053\",\n              \"name\": \"Voter rights\"\n            },\n            {\n              \"id\": \"it_2295\",\n              \"name\": \"Jiu-jitsu\"\n            },\n            {\n              \"id\": \"it_2054\",\n              \"name\": \"Climate change\"\n            },\n            {\n              \"id\": \"it_16\",\n              \"name\": \"Exhibition\"\n            },\n            {\n              \"id\": \"it_15\",\n              \"name\": \"Walking my dog\"\n            },\n            {\n              \"id\": \"it_2057\",\n              \"name\": \"LGBTQIA+ rights\"\n            },\n            {\n              \"id\": \"it_2058\",\n              \"name\": \"Feminism\"\n            },\n            {\n              \"id\": \"it_12\",\n              \"name\": \"VR room\"\n            },\n            {\n              \"id\": \"it_11\",\n              \"name\": \"Escape café\"\n            },\n            {\n              \"id\": \"it_14\",\n              \"name\": \"Shopping\"\n            },\n            {\n              \"id\": \"it_10\",\n              \"name\": \"Brunch\"\n            },\n            {\n              \"id\": \"it_2290\",\n              \"name\": \"Investment\"\n            },\n            {\n              \"id\": \"it_2293\",\n              \"name\": \"Jet skiing\"\n            },\n            {\n              \"id\": \"it_2172\",\n              \"name\": \"Reggaeton\"\n            },\n            {\n              \"id\": \"it_2051\",\n              \"name\": \"Vintage clothing\"\n            },\n            {\n              \"id\": \"it_2052\",\n              \"name\": \"Black Lives Matter\"\n            },\n            {\n              \"id\": \"it_2294\",\n              \"name\": \"Jogging\"\n            },\n            {\n              \"id\": \"it_2050\",\n              \"name\": \"Road trips\"\n            },\n            {\n              \"id\": \"it_2171\",\n              \"name\": \"Vintage fashion\"\n            },\n            {\n              \"id\": \"it_2165\",\n              \"name\": \"Voguing\"\n            },\n            {\n              \"id\": \"it_2166\",\n              \"name\": \"Sofa surfing\"\n            },\n            {\n              \"id\": \"it_2163\",\n              \"name\": \"Happy hour\"\n            },\n            {\n              \"id\": \"it_2285\",\n              \"name\": \"Inclusivity\"\n            },\n            {\n              \"id\": \"it_2048\",\n              \"name\": \"Country music\"\n            },\n            {\n              \"id\": \"it_2049\",\n              \"name\": \"Football\"\n            },\n            {\n              \"id\": \"it_2288\",\n              \"name\": \"Rollerblading\"\n            },\n            {\n              \"id\": \"it_2289\",\n              \"name\": \"Investing\"\n            },\n            {\n              \"id\": \"it_2161\",\n              \"name\": \"Tennis\"\n            },\n            {\n              \"id\": \"it_2282\",\n              \"name\": \"Ice cream\"\n            },\n            {\n              \"id\": \"it_2283\",\n              \"name\": \"Ice skating\"\n            },\n            {\n              \"id\": \"it_2280\",\n              \"name\": \"Human rights\"\n            },\n            {\n              \"id\": \"it_2160\",\n              \"name\": \"Exhibitions\"\n            },\n            {\n              \"id\": \"it_2352\",\n              \"name\": \"Pig roast\"\n            },\n            {\n              \"id\": \"it_1021\",\n              \"name\": \"Skiing\"\n            },\n            {\n              \"id\": \"it_2232\",\n              \"name\": \"Canoeing\"\n            },\n            {\n              \"id\": \"it_2111\",\n              \"name\": \"West End musicals\"\n            },\n            {\n              \"id\": \"it_1022\",\n              \"name\": \"Snowboarding\"\n            },\n            {\n              \"id\": \"it_2353\",\n              \"name\": \"Pilates\"\n            },\n            {\n              \"id\": \"it_2351\",\n              \"name\": \"Pentathlon\"\n            },\n            {\n              \"id\": \"it_2230\",\n              \"name\": \"Broadway\"\n            },\n            {\n              \"id\": \"it_2356\",\n              \"name\": \"PlayStation\"\n            },\n            {\n              \"id\": \"it_2235\",\n              \"name\": \"Cheerleading\"\n            },\n            {\n              \"id\": \"it_2236\",\n              \"name\": \"Choir\"\n            },\n            {\n              \"id\": \"it_2357\",\n              \"name\": \"Pole dancing\"\n            },\n            {\n              \"id\": \"it_2115\",\n              \"name\": \"Five-a-side football\"\n            },\n            {\n              \"id\": \"it_2233\",\n              \"name\": \"Car racing\"\n            },\n            {\n              \"id\": \"it_2354\",\n              \"name\": \"Pinterest\"\n            },\n            {\n              \"id\": \"it_2113\",\n              \"name\": \"Pub quiz\"\n            },\n            {\n              \"id\": \"it_1024\",\n              \"name\": \"Festivals\"\n            },\n            {\n              \"id\": \"it_2234\",\n              \"name\": \"Catan\"\n            },\n            {\n              \"id\": \"it_2239\",\n              \"name\": \"Cosplay\"\n            },\n            {\n              \"id\": \"it_2119\",\n              \"name\": \"Motor sports\"\n            },\n            {\n              \"id\": \"it_2237\",\n              \"name\": \"Coffee stands\"\n            },\n            {\n              \"id\": \"it_2238\",\n              \"name\": \"Content creation\"\n            },\n            {\n              \"id\": \"it_2117\",\n              \"name\": \"E-sports\"\n            },\n            {\n              \"id\": \"it_2220\",\n              \"name\": \"Bicycle racing\"\n            },\n            {\n              \"id\": \"it_2221\",\n              \"name\": \"Binge-watching TV series\"\n            },\n            {\n              \"id\": \"it_1011\",\n              \"name\": \"Songwriter\"\n            },\n            {\n              \"id\": \"it_2224\",\n              \"name\": \"Bodycombat\"\n            },\n            {\n              \"id\": \"it_1014\",\n              \"name\": \"Tattoos\"\n            },\n            {\n              \"id\": \"it_2346\",\n              \"name\": \"Painting\"\n            },\n            {\n              \"id\": \"it_2225\",\n              \"name\": \"Bodyjam\"\n            },\n            {\n              \"id\": \"it_2343\",\n              \"name\": \"Paddle boarding\"\n            },\n            {\n              \"id\": \"it_2344\",\n              \"name\": \"Padel\"\n            },\n            {\n              \"id\": \"it_2223\",\n              \"name\": \"Blackpink\"\n            },\n            {\n              \"id\": \"it_1013\",\n              \"name\": \"Surfing\"\n            },\n            {\n              \"id\": \"it_2228\",\n              \"name\": \"Bowling\"\n            },\n            {\n              \"id\": \"it_2107\",\n              \"name\": \"Grime\"\n            },\n            {\n              \"id\": \"it_2108\",\n              \"name\": \"’90s Britpop\"\n            },\n            {\n              \"id\": \"it_2226\",\n              \"name\": \"Bodypump\"\n            },\n            {\n              \"id\": \"it_2106\",\n              \"name\": \"Beach bars\"\n            },\n            {\n              \"id\": \"it_2227\",\n              \"name\": \"Bodystep\"\n            },\n            {\n              \"id\": \"it_2348\",\n              \"name\": \"Paragliding\"\n            },\n            {\n              \"id\": \"it_2109\",\n              \"name\": \"Upcycling\"\n            },\n            {\n              \"id\": \"it_2253\",\n              \"name\": \"Equality\"\n            },\n            {\n              \"id\": \"it_2011\",\n              \"name\": \"Astrology\"\n            },\n            {\n              \"id\": \"it_2133\",\n              \"name\": \"Motorcycles\"\n            },\n            {\n              \"id\": \"it_2254\",\n              \"name\": \"Equestrian\"\n            },\n            {\n              \"id\": \"it_2251\",\n              \"name\": \"Entrepreneurship\"\n            },\n            {\n              \"id\": \"it_2372\",\n              \"name\": \"Sake\"\n            },\n            {\n              \"id\": \"it_2131\",\n              \"name\": \"BTS\"\n            },\n            {\n              \"id\": \"it_2010\",\n              \"name\": \"Cooking\"\n            },\n            {\n              \"id\": \"it_2252\",\n              \"name\": \"Environmental protection\"\n            },\n            {\n              \"id\": \"it_2257\",\n              \"name\": \"Fencing\"\n            },\n            {\n              \"id\": \"it_2015\",\n              \"name\": \"Football\"\n            },\n            {\n              \"id\": \"it_2378\",\n              \"name\": \"Saxophonist\"\n            },\n            {\n              \"id\": \"it_2379\",\n              \"name\": \"Sci-fi\"\n            },\n            {\n              \"id\": \"it_2016\",\n              \"name\": \"Dancing\"\n            },\n            {\n              \"id\": \"it_2258\",\n              \"name\": \"Film festivals\"\n            },\n            {\n              \"id\": \"it_2013\",\n              \"name\": \"Gardening\"\n            },\n            {\n              \"id\": \"it_2135\",\n              \"name\": \"Amateur cook\"\n            },\n            {\n              \"id\": \"it_2256\",\n              \"name\": \"Exchange programmes\"\n            },\n            {\n              \"id\": \"it_2377\",\n              \"name\": \"Sauna\"\n            },\n            {\n              \"id\": \"it_2014\",\n              \"name\": \"Art\"\n            },\n            {\n              \"id\": \"it_2019\",\n              \"name\": \"Politics\"\n            },\n            {\n              \"id\": \"it_2259\",\n              \"name\": \"Flamenco\"\n            },\n            {\n              \"id\": \"it_2017\",\n              \"name\": \"Museum\"\n            },\n            {\n              \"id\": \"it_2018\",\n              \"name\": \"Activism\"\n            },\n            {\n              \"id\": \"it_2242\",\n              \"name\": \"DAOs\"\n            },\n            {\n              \"id\": \"it_2363\",\n              \"name\": \"Real estate\"\n            },\n            {\n              \"id\": \"it_2121\",\n              \"name\": \"Podcasts\"\n            },\n            {\n              \"id\": \"it_2243\",\n              \"name\": \"Disability rights\"\n            },\n            {\n              \"id\": \"it_2362\",\n              \"name\": \"Rave\"\n            },\n            {\n              \"id\": \"it_2120\",\n              \"name\": \"Pimms\"\n            },\n            {\n              \"id\": \"it_2246\",\n              \"name\": \"Drive-in cinema\"\n            },\n            {\n              \"id\": \"it_2367\",\n              \"name\": \"Rock climbing\"\n            },\n            {\n              \"id\": \"it_2125\",\n              \"name\": \"BBQ\"\n            },\n            {\n              \"id\": \"it_2004\",\n              \"name\": \"Craft beer\"\n            },\n            {\n              \"id\": \"it_2126\",\n              \"name\": \"Iced tea\"\n            },\n            {\n              \"id\": \"it_2247\",\n              \"name\": \"Drummer\"\n            },\n            {\n              \"id\": \"it_2005\",\n              \"name\": \"Tea\"\n            },\n            {\n              \"id\": \"it_2002\",\n              \"name\": \"Board games\"\n            },\n            {\n              \"id\": \"it_2365\",\n              \"name\": \"Roblox\"\n            },\n            {\n              \"id\": \"it_2123\",\n              \"name\": \"Pubs\"\n            },\n            {\n              \"id\": \"it_2366\",\n              \"name\": \"Rock\"\n            },\n            {\n              \"id\": \"it_2124\",\n              \"name\": \"Tango\"\n            },\n            {\n              \"id\": \"it_2245\",\n              \"name\": \"Drawing\"\n            },\n            {\n              \"id\": \"it_2003\",\n              \"name\": \"Trivia\"\n            },\n            {\n              \"id\": \"it_2129\",\n              \"name\": \"Pho\"\n            },\n            {\n              \"id\": \"it_2008\",\n              \"name\": \"Volunteering\"\n            },\n            {\n              \"id\": \"it_2009\",\n              \"name\": \"Environmentalism\"\n            },\n            {\n              \"id\": \"it_2369\",\n              \"name\": \"Rollerskating\"\n            },\n            {\n              \"id\": \"it_2006\",\n              \"name\": \"Wine\"\n            },\n            {\n              \"id\": \"it_2248\",\n              \"name\": \"Dungeons & Dragons\"\n            },\n            {\n              \"id\": \"it_2007\",\n              \"name\": \"Vlogging\"\n            },\n            {\n              \"id\": \"it_2249\",\n              \"name\": \"Electronic music\"\n            },\n            {\n              \"id\": \"it_2360\",\n              \"name\": \"Ramen\"\n            },\n            {\n              \"id\": \"it_2430\",\n              \"name\": \"Weightlifting\"\n            },\n            {\n              \"id\": \"it_2312\",\n              \"name\": \"Live music\"\n            },\n            {\n              \"id\": \"it_2433\",\n              \"name\": \"Writing\"\n            },\n            {\n              \"id\": \"it_2434\",\n              \"name\": \"Xbox\"\n            },\n            {\n              \"id\": \"it_2431\",\n              \"name\": \"World peace\"\n            },\n            {\n              \"id\": \"it_2432\",\n              \"name\": \"Wrestling\"\n            },\n            {\n              \"id\": \"it_2311\",\n              \"name\": \"Literature\"\n            },\n            {\n              \"id\": \"it_2316\",\n              \"name\": \"Manga\"\n            },\n            {\n              \"id\": \"it_2437\",\n              \"name\": \"Pride\"\n            },\n            {\n              \"id\": \"it_2317\",\n              \"name\": \"Marathon\"\n            },\n            {\n              \"id\": \"it_2314\",\n              \"name\": \"Make-up\"\n            },\n            {\n              \"id\": \"it_2435\",\n              \"name\": \"Youth empowerment\"\n            },\n            {\n              \"id\": \"it_2436\",\n              \"name\": \"YouTube\"\n            },\n            {\n              \"id\": \"it_2318\",\n              \"name\": \"Martial arts\"\n            },\n            {\n              \"id\": \"it_2319\",\n              \"name\": \"Marvel\"\n            },\n            {\n              \"id\": \"it_5020\",\n              \"name\": \"Luge\"\n            },\n            {\n              \"id\": \"it_5021\",\n              \"name\": \"Ice hockey\"\n            },\n            {\n              \"id\": \"it_5016\",\n              \"name\": \"Taekwondo\"\n            },\n            {\n              \"id\": \"it_5017\",\n              \"name\": \"Trampolining\"\n            },\n            {\n              \"id\": \"it_5018\",\n              \"name\": \"Water polo\"\n            },\n            {\n              \"id\": \"it_5012\",\n              \"name\": \"Rhythmic gymnastics\"\n            },\n            {\n              \"id\": \"it_2422\",\n              \"name\": \"Vegan cooking\"\n            },\n            {\n              \"id\": \"it_5013\",\n              \"name\": \"Rowing\"\n            },\n            {\n              \"id\": \"it_2423\",\n              \"name\": \"Vermouth\"\n            },\n            {\n              \"id\": \"it_2302\",\n              \"name\": \"Korean food\"\n            },\n            {\n              \"id\": \"it_5014\",\n              \"name\": \"Sports shooting\"\n            },\n            {\n              \"id\": \"it_2420\",\n              \"name\": \"Twitter\"\n            },\n            {\n              \"id\": \"it_5015\",\n              \"name\": \"Squash\"\n            },\n            {\n              \"id\": \"it_2426\",\n              \"name\": \"Volleyball\"\n            },\n            {\n              \"id\": \"it_2427\",\n              \"name\": \"Walking tours\"\n            },\n            {\n              \"id\": \"it_2424\",\n              \"name\": \"Vinyasa\"\n            },\n            {\n              \"id\": \"it_2425\",\n              \"name\": \"Virtual reality\"\n            },\n            {\n              \"id\": \"it_2309\",\n              \"name\": \"League of Legends\"\n            },\n            {\n              \"id\": \"it_5010\",\n              \"name\": \"Karate\"\n            },\n            {\n              \"id\": \"it_5011\",\n              \"name\": \"Lacrosse\"\n            },\n            {\n              \"id\": \"it_2334\",\n              \"name\": \"NFTs\"\n            },\n            {\n              \"id\": \"it_2213\",\n              \"name\": \"Pub crawls\"\n            },\n            {\n              \"id\": \"it_2335\",\n              \"name\": \"Nintendo\"\n            },\n            {\n              \"id\": \"it_2214\",\n              \"name\": \"Baseball\"\n            },\n            {\n              \"id\": \"it_1001\",\n              \"name\": \"Parties\"\n            },\n            {\n              \"id\": \"it_2211\",\n              \"name\": \"Ballet\"\n            },\n            {\n              \"id\": \"it_2212\",\n              \"name\": \"Bands\"\n            },\n            {\n              \"id\": \"it_2338\",\n              \"name\": \"Online games\"\n            },\n            {\n              \"id\": \"it_2217\",\n              \"name\": \"Battle Ground\"\n            },\n            {\n              \"id\": \"it_2218\",\n              \"name\": \"Beach tennis\"\n            },\n            {\n              \"id\": \"it_99\",\n              \"name\": \"Nightlife\"\n            },\n            {\n              \"id\": \"it_2339\",\n              \"name\": \"Online shopping\"\n            },\n            {\n              \"id\": \"it_1005\",\n              \"name\": \"Sailing\"\n            },\n            {\n              \"id\": \"it_2215\",\n              \"name\": \"Bassist\"\n            },\n            {\n              \"id\": \"it_2337\",\n              \"name\": \"Online broker\"\n            },\n            {\n              \"id\": \"it_94\",\n              \"name\": \"Military\"\n            },\n            {\n              \"id\": \"it_2320\",\n              \"name\": \"Memes\"\n            },\n            {\n              \"id\": \"it_2202\",\n              \"name\": \"Among Us\"\n            },\n            {\n              \"id\": \"it_2323\",\n              \"name\": \"Motorbike racing\"\n            },\n            {\n              \"id\": \"it_5155\",\n              \"name\": \"Muay Thai\"\n            },\n            {\n              \"id\": \"it_2324\",\n              \"name\": \"Motorcycling\"\n            },\n            {\n              \"id\": \"it_2321\",\n              \"name\": \"Metaverse\"\n            },\n            {\n              \"id\": \"it_2322\",\n              \"name\": \"Mindfulness\"\n            },\n            {\n              \"id\": \"it_2201\",\n              \"name\": \"Acapella\"\n            },\n            {\n              \"id\": \"it_2327\",\n              \"name\": \"Playing a musical instrument\"\n            },\n            {\n              \"id\": \"it_2206\",\n              \"name\": \"Art galleries\"\n            },\n            {\n              \"id\": \"it_2328\",\n              \"name\": \"Writing musicals\"\n            },\n            {\n              \"id\": \"it_88\",\n              \"name\": \"Hiking\"\n            },\n            {\n              \"id\": \"it_2207\",\n              \"name\": \"Artistic gymnastics\"\n            },\n            {\n              \"id\": \"it_2325\",\n              \"name\": \"Mountains\"\n            },\n            {\n              \"id\": \"it_2205\",\n              \"name\": \"Archery\"\n            },\n            {\n              \"id\": \"it_2208\",\n              \"name\": \"Atari\"\n            },\n            {\n              \"id\": \"it_2209\",\n              \"name\": \"Backpacking\"\n            },\n            {\n              \"id\": \"it_86\",\n              \"name\": \"Fishing\"\n            },\n            {\n              \"id\": \"it_2075\",\n              \"name\": \"Clubbing\"\n            },\n            {\n              \"id\": \"it_2079\",\n              \"name\": \"Street food\"\n            },\n            {\n              \"id\": \"it_78\",\n              \"name\": \"Crossfit\"\n            },\n            {\n              \"id\": \"it_76\",\n              \"name\": \"Concerts\"\n            },\n            {\n              \"id\": \"it_75\",\n              \"name\": \"Climbing\"\n            },\n            {\n              \"id\": \"it_70\",\n              \"name\": \"Baking\"\n            },\n            {\n              \"id\": \"it_72\",\n              \"name\": \"Camping\"\n            },\n            {\n              \"id\": \"it_71\",\n              \"name\": \"Blogging\"\n            },\n            {\n              \"id\": \"it_2070\",\n              \"name\": \"Collecting\"\n            },\n            {\n              \"id\": \"it_2072\",\n              \"name\": \"Cars\"\n            },\n            {\n              \"id\": \"it_2066\",\n              \"name\": \"Start-ups\"\n            },\n            {\n              \"id\": \"it_2067\",\n              \"name\": \"Boba tea\"\n            },\n            {\n              \"id\": \"it_2064\",\n              \"name\": \"High-school baseketball league (TW)\"\n            },\n            {\n              \"id\": \"it_2069\",\n              \"name\": \"Badminton\"\n            },\n            {\n              \"id\": \"it_66\",\n              \"name\": \"Active lifestyle\"\n            },\n            {\n              \"id\": \"it_63\",\n              \"name\": \"Fashion\"\n            },\n            {\n              \"id\": \"it_62\",\n              \"name\": \"Anime\"\n            },\n            {\n              \"id\": \"it_2062\",\n              \"name\": \"NBA\"\n            },\n            {\n              \"id\": \"it_2063\",\n              \"name\": \"MLB\"\n            },\n            {\n              \"id\": \"it_2099\",\n              \"name\": \"Funk music\"\n            },\n            {\n              \"id\": \"it_5006\",\n              \"name\": \"Diving\"\n            },\n            {\n              \"id\": \"it_2097\",\n              \"name\": \"Caipirinha\"\n            },\n            {\n              \"id\": \"it_5007\",\n              \"name\": \"American flag football\"\n            },\n            {\n              \"id\": \"it_5008\",\n              \"name\": \"Handball\"\n            },\n            {\n              \"id\": \"it_5001\",\n              \"name\": \"Artistic swimming\"\n            },\n            {\n              \"id\": \"it_5002\",\n              \"name\": \"Athletics\"\n            },\n            {\n              \"id\": \"it_59\",\n              \"name\": \"Indoor activities\"\n            },\n            {\n              \"id\": \"it_5003\",\n              \"name\": \"Softball\"\n            },\n            {\n              \"id\": \"it_5004\",\n              \"name\": \"Beach volleyball\"\n            },\n            {\n              \"id\": \"it_2410\",\n              \"name\": \"Tempeh\"\n            },\n            {\n              \"id\": \"it_56\",\n              \"name\": \"DIY\"\n            },\n            {\n              \"id\": \"it_2416\",\n              \"name\": \"Town festivities\"\n            },\n            {\n              \"id\": \"it_55\",\n              \"name\": \"Cycling\"\n            },\n            {\n              \"id\": \"it_58\",\n              \"name\": \"Outdoors\"\n            },\n            {\n              \"id\": \"it_2414\",\n              \"name\": \"TikTok\"\n            },\n            {\n              \"id\": \"it_57\",\n              \"name\": \"Picnicking\"\n            },\n            {\n              \"id\": \"it_2419\",\n              \"name\": \"Twitch\"\n            },\n            {\n              \"id\": \"it_5009\",\n              \"name\": \"Judo\"\n            },\n            {\n              \"id\": \"it_51\",\n              \"name\": \"Comedy\"\n            },\n            {\n              \"id\": \"it_2417\",\n              \"name\": \"Trap music\"\n            },\n            {\n              \"id\": \"it_54\",\n              \"name\": \"Music\"\n            },\n            {\n              \"id\": \"it_2418\",\n              \"name\": \"Triathlon\"\n            },\n            {\n              \"id\": \"it_53\",\n              \"name\": \"Netflix\"\n            },\n            {\n              \"id\": \"it_50\",\n              \"name\": \"Disney\"\n            },\n            {\n              \"id\": \"it_2090\",\n              \"name\": \"Rugby\"\n            },\n            {\n              \"id\": \"it_2095\",\n              \"name\": \"Açaí\"\n            },\n            {\n              \"id\": \"it_2093\",\n              \"name\": \"Samba\"\n            },\n            {\n              \"id\": \"it_2094\",\n              \"name\": \"Tarot\"\n            },\n            {\n              \"id\": \"it_2400\",\n              \"name\": \"Stock exchange\"\n            },\n            {\n              \"id\": \"it_2401\",\n              \"name\": \"Stocks\"\n            },\n            {\n              \"id\": \"it_48\",\n              \"name\": \"Swimming\"\n            },\n            {\n              \"id\": \"it_2404\",\n              \"name\": \"Table tennis\"\n            },\n            {\n              \"id\": \"it_41\",\n              \"name\": \"Killing time\"\n            },\n            {\n              \"id\": \"it_43\",\n              \"name\": \"Working out\"\n            },\n            {\n              \"id\": \"it_42\",\n              \"name\": \"Yoga\"\n            },\n            {\n              \"id\": \"it_2080\",\n              \"name\": \"Horror films\"\n            },\n            {\n              \"id\": \"it_2081\",\n              \"name\": \"Boxing\"\n            },\n            {\n              \"id\": \"it_2082\",\n              \"name\": \"Chilling at a bar\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"minSelections\": 3,\n          \"maxSelections\": 5,\n          \"backgroundText\": \"Add interests\",\n          \"searchBackgroundText\": \"Search interests\",\n          \"sectionId\": 2,\n          \"sectionName\": \"Interests\",\n          \"matchGroupKey\": \"languages\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": false\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()), "section", "Tell us about your interests", "Interests" },
                    { 3, System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_29\",\n          \"name\": \"Looking for\",\n          \"prompt\": \"What are you looking for?\",\n          \"type\": \"choice_selector_v1\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Long-term partner\",\n              \"style\": \"purple\",\n              \"emoji\": \"💘\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_cupid@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_cupid@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_cupid@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"Serious\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Long-term, but short-term OK\",\n              \"style\": \"pink\",\n              \"emoji\": \"😍\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_heart_eyes@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_heart_eyes@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_heart_eyes@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ]\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Short-term, but long-term OK\",\n              \"style\": \"yellow\",\n              \"emoji\": \"🥂\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_clinking_glasses@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_clinking_glasses@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_clinking_glasses@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ]\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Short-term fun\",\n              \"style\": \"green\",\n              \"emoji\": \"🎉\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_tada@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_tada@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_tada@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"Casual\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"New friends\",\n              \"style\": \"teal\",\n              \"emoji\": \"👋\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_wave@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_wave@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_wave@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"Friends\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Still figuring it out\",\n              \"style\": \"blue\",\n              \"emoji\": \"🤔\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_thinking_face@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_thinking_face@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_thinking_face@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"DontKnow\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"subPrompt\": \"All good if it changes. There’s something for everyone.\",\n          \"sectionId\": 3,\n          \"sectionName\": \"Relationship Goals\",\n          \"matchGroupKey\": \"intent\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()), "section", null, "Relationship Goals" },
                    { 4, System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_37\",\n          \"type\": \"multiSelectionSet\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Afrikaans\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Albanian\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Amharic\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Arabic\",\n              \"matchGroupKey\": \"Arabic\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Armenian\",\n              \"matchGroupKey\": \"Armenian\"\n            },\n            {\n              \"id\": \"133\",\n              \"name\": \"ASL\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Assamese\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Aymara\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Azerbaijani\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Bambara\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Basque\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"Belarusian\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Bengali\",\n              \"matchGroupKey\": \"Bengali\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"Bhojpuri\"\n            },\n            {\n              \"id\": \"14\",\n              \"name\": \"Bosnian\"\n            },\n            {\n              \"id\": \"134\",\n              \"name\": \"Breton\"\n            },\n            {\n              \"id\": \"15\",\n              \"name\": \"Bulgarian\",\n              \"matchGroupKey\": \"Bulgarian\"\n            },\n            {\n              \"id\": \"16\",\n              \"name\": \"Burmese\"\n            },\n            {\n              \"id\": \"17\",\n              \"name\": \"Cantonese\",\n              \"matchGroupKey\": \"Cantonese\"\n            },\n            {\n              \"id\": \"18\",\n              \"name\": \"Catalan\"\n            },\n            {\n              \"id\": \"19\",\n              \"name\": \"Cebuano\"\n            },\n            {\n              \"id\": \"20\",\n              \"name\": \"Chichewa\"\n            },\n            {\n              \"id\": \"21\",\n              \"name\": \"Corsican\"\n            },\n            {\n              \"id\": \"22\",\n              \"name\": \"Croatian\"\n            },\n            {\n              \"id\": \"23\",\n              \"name\": \"Czech\",\n              \"matchGroupKey\": \"Czech\"\n            },\n            {\n              \"id\": \"24\",\n              \"name\": \"Danish\",\n              \"matchGroupKey\": \"Danish\"\n            },\n            {\n              \"id\": \"25\",\n              \"name\": \"Dhivehi\"\n            },\n            {\n              \"id\": \"26\",\n              \"name\": \"Dogri\"\n            },\n            {\n              \"id\": \"27\",\n              \"name\": \"Dutch\",\n              \"matchGroupKey\": \"Dutch\"\n            },\n            {\n              \"id\": \"28\",\n              \"name\": \"English\",\n              \"matchGroupKey\": \"English\"\n            },\n            {\n              \"id\": \"29\",\n              \"name\": \"Esperanto\"\n            },\n            {\n              \"id\": \"30\",\n              \"name\": \"Estonian\"\n            },\n            {\n              \"id\": \"31\",\n              \"name\": \"Ewe\"\n            },\n            {\n              \"id\": \"32\",\n              \"name\": \"Filipino\"\n            },\n            {\n              \"id\": \"33\",\n              \"name\": \"Finnish\",\n              \"matchGroupKey\": \"Finnish\"\n            },\n            {\n              \"id\": \"34\",\n              \"name\": \"French\",\n              \"matchGroupKey\": \"French\"\n            },\n            {\n              \"id\": \"35\",\n              \"name\": \"Frisian\"\n            },\n            {\n              \"id\": \"36\",\n              \"name\": \"Galician\"\n            },\n            {\n              \"id\": \"37\",\n              \"name\": \"Georgian\"\n            },\n            {\n              \"id\": \"38\",\n              \"name\": \"German\",\n              \"matchGroupKey\": \"German\"\n            },\n            {\n              \"id\": \"39\",\n              \"name\": \"Greek\",\n              \"matchGroupKey\": \"Greek\"\n            },\n            {\n              \"id\": \"40\",\n              \"name\": \"Guaraní\"\n            },\n            {\n              \"id\": \"41\",\n              \"name\": \"Gujarati\",\n              \"matchGroupKey\": \"Gujarati\"\n            },\n            {\n              \"id\": \"42\",\n              \"name\": \"Haitian Creole\"\n            },\n            {\n              \"id\": \"43\",\n              \"name\": \"Hausa\"\n            },\n            {\n              \"id\": \"44\",\n              \"name\": \"Hawaiian\"\n            },\n            {\n              \"id\": \"45\",\n              \"name\": \"Hebrew\",\n              \"matchGroupKey\": \"Hebrew\"\n            },\n            {\n              \"id\": \"46\",\n              \"name\": \"Hindi\",\n              \"matchGroupKey\": \"Hindi\"\n            },\n            {\n              \"id\": \"47\",\n              \"name\": \"Hmong\"\n            },\n            {\n              \"id\": \"48\",\n              \"name\": \"Hungarian\",\n              \"matchGroupKey\": \"Hungarian\"\n            },\n            {\n              \"id\": \"49\",\n              \"name\": \"Icelandic\"\n            },\n            {\n              \"id\": \"50\",\n              \"name\": \"Igbo\"\n            },\n            {\n              \"id\": \"51\",\n              \"name\": \"Ilocano\"\n            },\n            {\n              \"id\": \"52\",\n              \"name\": \"Indonesian\",\n              \"matchGroupKey\": \"Indonesian\"\n            },\n            {\n              \"id\": \"53\",\n              \"name\": \"Irish\",\n              \"matchGroupKey\": \"Irish\"\n            },\n            {\n              \"id\": \"54\",\n              \"name\": \"Italian\",\n              \"matchGroupKey\": \"Italian\"\n            },\n            {\n              \"id\": \"55\",\n              \"name\": \"Japanese\",\n              \"matchGroupKey\": \"Japanese\"\n            },\n            {\n              \"id\": \"56\",\n              \"name\": \"Javanese\"\n            },\n            {\n              \"id\": \"57\",\n              \"name\": \"Kannada\"\n            },\n            {\n              \"id\": \"58\",\n              \"name\": \"Kazakh\"\n            },\n            {\n              \"id\": \"59\",\n              \"name\": \"Khmer\",\n              \"matchGroupKey\": \"Khmer\"\n            },\n            {\n              \"id\": \"60\",\n              \"name\": \"Kinyarwanda\"\n            },\n            {\n              \"id\": \"61\",\n              \"name\": \"Konkani\"\n            },\n            {\n              \"id\": \"62\",\n              \"name\": \"Korean\",\n              \"matchGroupKey\": \"Korean\"\n            },\n            {\n              \"id\": \"63\",\n              \"name\": \"Krio\"\n            },\n            {\n              \"id\": \"64\",\n              \"name\": \"Kurdish\"\n            },\n            {\n              \"id\": \"65\",\n              \"name\": \"Kyrgyz\"\n            },\n            {\n              \"id\": \"66\",\n              \"name\": \"Lao\"\n            },\n            {\n              \"id\": \"67\",\n              \"name\": \"Latin\"\n            },\n            {\n              \"id\": \"68\",\n              \"name\": \"Latvian\",\n              \"matchGroupKey\": \"Latvian\"\n            },\n            {\n              \"id\": \"69\",\n              \"name\": \"Lingala\"\n            },\n            {\n              \"id\": \"70\",\n              \"name\": \"Lithuanian\",\n              \"matchGroupKey\": \"Lithuanian\"\n            },\n            {\n              \"id\": \"71\",\n              \"name\": \"Luganda\"\n            },\n            {\n              \"id\": \"72\",\n              \"name\": \"Luxembourgish\"\n            },\n            {\n              \"id\": \"73\",\n              \"name\": \"Macedonian\"\n            },\n            {\n              \"id\": \"74\",\n              \"name\": \"Maithili\"\n            },\n            {\n              \"id\": \"75\",\n              \"name\": \"Malagasy\"\n            },\n            {\n              \"id\": \"76\",\n              \"name\": \"Malay\",\n              \"matchGroupKey\": \"Malay\"\n            },\n            {\n              \"id\": \"77\",\n              \"name\": \"Malayalam\"\n            },\n            {\n              \"id\": \"78\",\n              \"name\": \"Maltese\"\n            },\n            {\n              \"id\": \"79\",\n              \"name\": \"Mandarin Chinese\",\n              \"matchGroupKey\": \"Chinese\"\n            },\n            {\n              \"id\": \"80\",\n              \"name\": \"Manipuri\"\n            },\n            {\n              \"id\": \"81\",\n              \"name\": \"Maori\"\n            },\n            {\n              \"id\": \"82\",\n              \"name\": \"Marathi\"\n            },\n            {\n              \"id\": \"83\",\n              \"name\": \"Mizo\"\n            },\n            {\n              \"id\": \"84\",\n              \"name\": \"Mongolian\"\n            },\n            {\n              \"id\": \"85\",\n              \"name\": \"Nepali\"\n            },\n            {\n              \"id\": \"86\",\n              \"name\": \"Norwegian\",\n              \"matchGroupKey\": \"Norwegian\"\n            },\n            {\n              \"id\": \"87\",\n              \"name\": \"Odia\"\n            },\n            {\n              \"id\": \"88\",\n              \"name\": \"Oromo\"\n            },\n            {\n              \"id\": \"89\",\n              \"name\": \"Pashto\"\n            },\n            {\n              \"id\": \"90\",\n              \"name\": \"Persian\",\n              \"matchGroupKey\": \"Persian\"\n            },\n            {\n              \"id\": \"91\",\n              \"name\": \"Polish\",\n              \"matchGroupKey\": \"Polish\"\n            },\n            {\n              \"id\": \"92\",\n              \"name\": \"Portuguese\",\n              \"matchGroupKey\": \"Portuguese\"\n            },\n            {\n              \"id\": \"93\",\n              \"name\": \"Punjabi\",\n              \"matchGroupKey\": \"Punjabi\"\n            },\n            {\n              \"id\": \"94\",\n              \"name\": \"Quechua\"\n            },\n            {\n              \"id\": \"95\",\n              \"name\": \"Romanian\",\n              \"matchGroupKey\": \"Romanian\"\n            },\n            {\n              \"id\": \"96\",\n              \"name\": \"Russian\",\n              \"matchGroupKey\": \"Russian\"\n            },\n            {\n              \"id\": \"97\",\n              \"name\": \"Samoan\"\n            },\n            {\n              \"id\": \"98\",\n              \"name\": \"Sanskrit\"\n            },\n            {\n              \"id\": \"99\",\n              \"name\": \"Scots Gaelic\"\n            },\n            {\n              \"id\": \"100\",\n              \"name\": \"Sepedi\"\n            },\n            {\n              \"id\": \"101\",\n              \"name\": \"Serbian\"\n            },\n            {\n              \"id\": \"102\",\n              \"name\": \"Sesotho\"\n            },\n            {\n              \"id\": \"103\",\n              \"name\": \"Shona\"\n            },\n            {\n              \"id\": \"104\",\n              \"name\": \"Sindhi\"\n            },\n            {\n              \"id\": \"105\",\n              \"name\": \"Sinhala\"\n            },\n            {\n              \"id\": \"106\",\n              \"name\": \"Slovak\",\n              \"matchGroupKey\": \"Slovak\"\n            },\n            {\n              \"id\": \"107\",\n              \"name\": \"Slovenian\",\n              \"matchGroupKey\": \"Slovenian\"\n            },\n            {\n              \"id\": \"108\",\n              \"name\": \"Somali\"\n            },\n            {\n              \"id\": \"109\",\n              \"name\": \"Spanish\",\n              \"matchGroupKey\": \"Spanish\"\n            },\n            {\n              \"id\": \"110\",\n              \"name\": \"Sundanese\"\n            },\n            {\n              \"id\": \"111\",\n              \"name\": \"Swahili\",\n              \"matchGroupKey\": \"Swahili\"\n            },\n            {\n              \"id\": \"112\",\n              \"name\": \"Swedish\",\n              \"matchGroupKey\": \"Swedish\"\n            },\n            {\n              \"id\": \"113\",\n              \"name\": \"Tajik\"\n            },\n            {\n              \"id\": \"114\",\n              \"name\": \"Tamil\",\n              \"matchGroupKey\": \"Tamil\"\n            },\n            {\n              \"id\": \"115\",\n              \"name\": \"Tatar\"\n            },\n            {\n              \"id\": \"116\",\n              \"name\": \"Telugu\"\n            },\n            {\n              \"id\": \"117\",\n              \"name\": \"Thai\",\n              \"matchGroupKey\": \"Thai\"\n            },\n            {\n              \"id\": \"118\",\n              \"name\": \"Tigrinya\"\n            },\n            {\n              \"id\": \"119\",\n              \"name\": \"Tsonga\"\n            },\n            {\n              \"id\": \"120\",\n              \"name\": \"Turkish\",\n              \"matchGroupKey\": \"Turkish\"\n            },\n            {\n              \"id\": \"121\",\n              \"name\": \"Turkmen\"\n            },\n            {\n              \"id\": \"122\",\n              \"name\": \"Twi\"\n            },\n            {\n              \"id\": \"123\",\n              \"name\": \"Ukrainian\",\n              \"matchGroupKey\": \"Ukranian\"\n            },\n            {\n              \"id\": \"124\",\n              \"name\": \"Urdu\",\n              \"matchGroupKey\": \"Urdu\"\n            },\n            {\n              \"id\": \"125\",\n              \"name\": \"Uyghur\"\n            },\n            {\n              \"id\": \"126\",\n              \"name\": \"Uzbek\"\n            },\n            {\n              \"id\": \"127\",\n              \"name\": \"Vietnamese\",\n              \"matchGroupKey\": \"Vietnamese\"\n            },\n            {\n              \"id\": \"128\",\n              \"name\": \"Welsh\"\n            },\n            {\n              \"id\": \"129\",\n              \"name\": \"Xhosa\"\n            },\n            {\n              \"id\": \"130\",\n              \"name\": \"Yiddish\"\n            },\n            {\n              \"id\": \"131\",\n              \"name\": \"Yoruba\"\n            },\n            {\n              \"id\": \"132\",\n              \"name\": \"Zulu\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"minSelections\": 1,\n          \"maxSelections\": 5,\n          \"backgroundText\": \"Add languages\",\n          \"searchBackgroundText\": \"Search languages\",\n          \"sectionId\": 4,\n          \"sectionName\": \"Languages I know\",\n          \"matchGroupKey\": \"languages\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": false\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()), "section", "Select up to 5 languages you know and add them to your profile", "Languages I know" },
                    { 5, System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_1\",\n          \"name\": \"Zodiac\",\n          \"prompt\": \"What’s your star sign?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Capricorn\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Aquarius\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Pisces\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Aries\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Taurus\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Gemini\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Cancer\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Leo\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Virgo\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Libra\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"Scorpio\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Sagittarius\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_9\",\n          \"name\": \"Education\",\n          \"prompt\": \"What is your education level?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Bachelor degree\",\n              \"matchGroupKey\": \"Bachelors\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"At uni\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"High school\",\n              \"matchGroupKey\": \"Highschool\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"PhD\",\n              \"matchGroupKey\": \"PhD\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"On a graduate programme\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Master degree\",\n              \"matchGroupKey\": \"Masters\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Trade school\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/education@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/education@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/education@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/education@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"matchGroupKey\": \"education\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_33\",\n          \"name\": \"Family plans\",\n          \"prompt\": \"Do you want children?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"I want children\",\n              \"matchGroupKey\": \"Yes\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"I don’t want children\",\n              \"matchGroupKey\": \"No\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"I have children and want more\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"I have children and don’t want more\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Not sure yet\",\n              \"matchGroupKey\": \"Maybe\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/kids@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/kids@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/kids@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/kids@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"matchGroupKey\": \"wants_children\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_34\",\n          \"name\": \"COVID vaccine\",\n          \"prompt\": \"Are you vaccinated?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Vaccinated\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Unvaccinated\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Prefer not to say\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_13\",\n          \"name\": \"Personality type\",\n          \"prompt\": \"What’s your personality type?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"INTJ\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"INTP\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"ENTJ\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"ENTP\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"INFJ\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"INFP\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"ENFJ\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"ENFP\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"ISTJ\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"ISFJ\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"ESTJ\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"ESFJ\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"ISTP\"\n            },\n            {\n              \"id\": \"14\",\n              \"name\": \"ISFP\"\n            },\n            {\n              \"id\": \"15\",\n              \"name\": \"ESTP\"\n            },\n            {\n              \"id\": \"16\",\n              \"name\": \"ESFP\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_2\",\n          \"name\": \"Communication style\",\n          \"prompt\": \"What’s your communication style?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Big time texter\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Phone caller\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Video chatter\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Bad texter\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Better in person\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_35\",\n          \"name\": \"Love style\",\n          \"prompt\": \"How do you receive love?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Thoughtful gestures\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Presents\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Touch\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Compliments\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Time together\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()), "section", "Put your best self forward by adding more about you", "More about me" },
                    { 6, System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_3\",\n          \"name\": \"Pets\",\n          \"prompt\": \"Do you have any pets?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Dog\",\n              \"matchGroupKey\": \"Dogs\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Cat\",\n              \"matchGroupKey\": \"Cats\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Reptile\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Amphibian\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Bird\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Fish\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Don’t have, but love\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"Other\",\n              \"matchGroupKey\": \"Other\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Turtle\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"Hamster\"\n            },\n            {\n              \"id\": \"14\",\n              \"name\": \"Rabbit\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Pet-free\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"All the pets\"\n            },\n            {\n              \"id\": \"16\",\n              \"name\": \"Want a pet\"\n            },\n            {\n              \"id\": \"17\",\n              \"name\": \"Allergic to pets\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/pets@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/pets@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/pets@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/pets@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"pets\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_22\",\n          \"name\": \"Drinking\",\n          \"prompt\": \"How often do you drink?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"8\",\n              \"name\": \"Not for me\",\n              \"matchGroupKey\": \"No\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Newly teetotal\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Sober curious\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"On special occasions\",\n              \"matchGroupKey\": \"Sometimes\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Socially, at the weekend\",\n              \"matchGroupKey\": \"Socially\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"Most nights\",\n              \"matchGroupKey\": \"Yes\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"drinking\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_11\",\n          \"name\": \"How often do you smoke?\",\n          \"prompt\": \"How often do you smoke?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Social smoker\",\n              \"matchGroupKey\": \"Socially\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Smoker when drinking\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Non-smoker\",\n              \"matchGroupKey\": \"No\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Smoker\",\n              \"matchGroupKey\": \"Yes\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Trying to quit\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"drinking\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_10\",\n          \"name\": \"Workout\",\n          \"prompt\": \"Do you exercise?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"4\",\n              \"name\": \"Every day\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Often\",\n              \"matchGroupKey\": \"Often\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Sometimes\",\n              \"matchGroupKey\": \"Sometimes\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Never\",\n              \"matchGroupKey\": \"Never\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/workout@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/workout@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/workout@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/workout@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"exercise\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_7\",\n          \"name\": \"Dietary preference\",\n          \"prompt\": \"What are your dietary preferences?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Vegan\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Vegetarian\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Pescatarian\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Kosher\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Halal\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Carnivore\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Omnivore\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Other\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_4\",\n          \"name\": \"Social media\",\n          \"prompt\": \"How active are you on social media?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Influencer status\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Socially active\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Off the grid\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Passive scroller\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_17\",\n          \"name\": \"Sleeping habits\",\n          \"prompt\": \"What are your sleeping habits?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Early bird\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Night owl\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"It varies\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()), "section", "Put your best self forward by adding your lifestyle", "Lifestyle" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("2d27b138-6276-48f7-ab83-7b3573b6cb3a"), null, "Woman", null },
                    { new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856"), null, "Beyond binary", null },
                    { new Guid("a176153d-6d94-4107-89aa-1943268cdc6a"), null, "Man", null }
                });

            migrationBuilder.InsertData(
                table: "QuestionCategories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4940), "Connection-building", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4940) },
                    { new Guid("37f07a7d-170b-4dba-a217-10ad3c53cc4b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4950), "Dilemma", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4950) },
                    { new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4940), "Edgy", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4940) },
                    { new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4920), "Flirty", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4920) },
                    { new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4920), "Funny", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4920) },
                    { new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4900), "Sexual", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(4900) }
                });

            migrationBuilder.InsertData(
                table: "RoomContent",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Order", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("03d36160-aca1-42f9-b462-62a68b23a71e"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5880), "Get Ready to pick exactly two profiles!", 60m, 5, "Pick Two", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5880) },
                    { new Guid("0fac1907-8795-4043-b245-6c0379c62f39"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5860), "Brace yourself for some off-the-wall questions and give your best answers within the time limit!", 300m, 3, "Random Question Roulette", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5860) },
                    { new Guid("3f732f34-5626-4b37-b59d-05bd1b2d8908"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5890), "Pop your best question to the remaining contenders, and whoever nails it gets the match!", 60m, 6, "The Final Rose", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5890) },
                    { new Guid("4cde094a-0f71-4dbd-ac9a-8f23b739b6a8"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5860), "Share your passions and two quirky facts about yourself!", 120m, 2, "Hobby Showcase & Fun Fact Extravaganza", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5860) },
                    { new Guid("9df25a2d-8bf4-4885-aecb-996b94ddae4e"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5870), "Get ready to field questions from your adoring audience!", 300m, 4, "Spotlight Q&A", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5870) },
                    { new Guid("df63134d-a2be-4dee-91fb-d7b16d108cc2"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5830), "Give us the scoop on the person behind the screen!", 60m, 1, "Meet & Greet", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5830) }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("06bf29bc-0337-4bb0-903c-290bc53dc74d"), "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", "Transfeminine", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("07b14b08-90e8-4555-8ef0-ddd5b5de3aae"), "A woman born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", "Intersex woman", new Guid("2d27b138-6276-48f7-ab83-7b3573b6cb3a") },
                    { new Guid("1848e980-6bf2-4291-89ee-83baa25bf50f"), "An umbrella term that refers to people born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", "Intersex", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("1a483e60-24a1-43c6-b4ab-cfe53a087338"), "A person who does not have a single fixed gender.", "Gender fluid", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("4dd890ed-977d-46a4-a9cc-81f03c35519a"), "A person who is transgender and their gender is different from the sex assigned to them at birth.", "Trans person", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("5d73785c-6ced-43e1-9940-e10516781dd2"), "A person who has two or more genders (can be simultaneously or fluid between them).", "Bigender", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("605d61aa-b948-4528-8210-57a1f3bebf34"), "A person who experiences multiple genders either simultaneously or over time.", "Pangender", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("7d3a0c1f-f281-42d9-8cc2-fc681a504c12"), "An umbrella term used across US Native American and Canadian First Nations communities to honour the sacred role that people who are not exclusively cisgender and/or heterosexual hold.", "Two-Spirit", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("8e6cf7f7-ecd8-46e4-a64f-acd155edaa32"), "A person who is questioning their current gender and/or exploring other genders and expressions.", "Gender questioning", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("9e595a7b-593d-4ccb-a4a2-9b2d25b67c0a"), "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", "Transmasculine", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("abcb981c-5baa-4a15-95d6-55ea401e7cb3"), "A person who does not identify or express their gender within the gender binary.", "Genderqueer", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("b24704d1-dfbb-424a-aaaf-cc4ae9dbf381"), "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", "Transfeminine", new Guid("2d27b138-6276-48f7-ab83-7b3573b6cb3a") },
                    { new Guid("be11a50a-28fa-43a2-9ce8-d414c4383095"), "A man whose gender aligns with the sex they were assigned at birth.", "Cis man", new Guid("a176153d-6d94-4107-89aa-1943268cdc6a") },
                    { new Guid("d033be12-0834-4b78-841c-564a3d806ef9"), "A man whose gender is different from his sex assigned at birth.", "Trans man", new Guid("a176153d-6d94-4107-89aa-1943268cdc6a") },
                    { new Guid("d9866d4e-9cd3-4ba2-856b-7284496d6b64"), "A woman whose gender is different from her sex assigned at birth.", "Trans woman", new Guid("2d27b138-6276-48f7-ab83-7b3573b6cb3a") },
                    { new Guid("dd15ddcf-912b-4e7b-b873-b57abd6372b5"), "A person whose gender is beyond the exclusive categories of man and woman.", "Non-binary", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("e0c28761-b8ff-444b-a718-dd8c756d545d"), "A person who does not have a gender.", "Agender", new Guid("97e691a2-7cc1-4e61-b30a-25ce0f016856") },
                    { new Guid("e5237e8b-30c0-47a3-a275-8ad22ca28a7c"), "A woman whose gender aligns with the sex they were assigned at birth.", "Cis woman", new Guid("2d27b138-6276-48f7-ab83-7b3573b6cb3a") },
                    { new Guid("eb859039-4b3b-4e12-ace6-1724a1021600"), "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", "Transmasculine", new Guid("a176153d-6d94-4107-89aa-1943268cdc6a") },
                    { new Guid("eef2ec30-e831-496e-86d9-e83f864ec0e5"), "A man born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", "Intersex man", new Guid("a176153d-6d94-4107-89aa-1943268cdc6a") }
                });

            migrationBuilder.InsertData(
                table: "SystemQuestions",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00937f04-452c-4e47-a715-5536b299556c"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5200), "You have to assassinate someone who really deserves it. How do you do it?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5200) },
                    { new Guid("0a3380c5-e30d-45ff-903c-80e91e0fdab5"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5250), "What’s your favorite way to be seduced by a man?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5250) },
                    { new Guid("0cd3fecc-f2d2-48cf-a01b-8f641d853e7c"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5270), "What’s the best romantic surprise you’ve ever had?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5270) },
                    { new Guid("0f1348f4-8597-4bbd-ae2e-635f52649b9d"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5660), "What do you wish more people knew about you?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5660) },
                    { new Guid("175c5e72-e5b5-455c-bba8-8a3a5f49a907"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5590), "What would you like to get for your birthday?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5590) },
                    { new Guid("1782161e-18fd-47c7-9476-f59a8b409e55"), new Guid("37f07a7d-170b-4dba-a217-10ad3c53cc4b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5670), "Flight or invisibility?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5670) },
                    { new Guid("1983ae6d-431c-430b-8230-068e21ca1f51"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5530), "What’s something you’ve always wanted to do, but haven’t?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5530) },
                    { new Guid("1c275b49-c57f-44c9-84c6-7e5c5ac7e92d"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5310), "What’s the hottest thing a guy can do for you?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5310) },
                    { new Guid("1c9796e5-ab49-44a1-b735-39576e846b58"), new Guid("37f07a7d-170b-4dba-a217-10ad3c53cc4b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5690), "Bath or shower?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5690) },
                    { new Guid("25019df3-66b0-46dd-b033-7ab1a0f17572"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5650), "What’s the most important thing your life is missing?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5650) },
                    { new Guid("28e8a961-f731-4b1a-bbb8-988c655257fb"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5620), "What do you wish you cared less about?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5620) },
                    { new Guid("29d5bd8d-33c3-4dec-bae1-7c32e4fcb77c"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5660), "How long ago did you tell someone you loved them?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5660) },
                    { new Guid("2b23a32f-e42f-439d-820a-be20e5647cda"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5180), "What was the last time you went skinny dipping?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5180) },
                    { new Guid("2c431f0d-2c67-4d2a-8be5-b0e46575de74"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5070), "Are you more dominant or submissive in bed?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5070) },
                    { new Guid("32ec6f5c-3ec7-46df-be89-122d445dcf36"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5380), "Would you rather speak every language fluently or play every instrument perfectly?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5380) },
                    { new Guid("36a46b6c-2a61-4528-9e68-debbf49a122d"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5170), "Do you think that men can be gynecologists? (Second question) What if he sniffs his finger?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5170) },
                    { new Guid("391018c8-52c1-4507-b3cf-1dca046508b5"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5450), "What’s the first thing you do when you get back home from work?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5450) },
                    { new Guid("3b4c8aa3-668c-4de5-b16e-8f0c702f09d6"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5290), "What are your biggest turn-offs?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5290) },
                    { new Guid("40dbb394-64be-4715-a4b1-60b7f7b6c479"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5440), "If you could travel the universe on the condition that you were never allowed to set foot on earth again, would you go?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5440) },
                    { new Guid("44694105-e473-4696-96dc-d0cfd1d4bff8"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5190), "Would you date someone who’s cute but mega dumb?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5190) },
                    { new Guid("4872e1e0-1c1c-4455-944c-a48006e82330"), new Guid("37f07a7d-170b-4dba-a217-10ad3c53cc4b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5700), "Love or money?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5700) },
                    { new Guid("48c86a1c-1168-4feb-a063-702251e7906e"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5430), "Would you rather travel to the past or the future?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5430) },
                    { new Guid("4bdb5458-7138-4716-bd3d-aff067458c08"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5400), "Would you rather be with the person you love forever, but also wear a shirt made out of their pubes, or be alone for the rest of your life but wear whatever you want?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5400) },
                    { new Guid("4e32dfd7-4dd9-4f17-992c-2d72cc8563df"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5580), "What dating advice would you give your younger self?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5580) },
                    { new Guid("50176884-b2b5-4ad5-a858-b74ed02dec6a"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5240), "Do you prefer the smell of freshly cut grass or freshly baked bread?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5240) },
                    { new Guid("545368eb-280e-458c-8a64-7ee344bf7455"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5100), "What’s the dirtiest thought you’ve ever had about a stranger?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5100) },
                    { new Guid("599d93c7-a43b-4197-ae67-fd25e071e8df"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5470), "Is there a way you could fall head over heels for a man? What would that look like?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5470) },
                    { new Guid("5abf4d5a-8ee0-43f2-b052-8a5ee34356dd"), new Guid("37f07a7d-170b-4dba-a217-10ad3c53cc4b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5710), "Burger or pizza?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5710) },
                    { new Guid("5af85cb3-b621-4e80-a052-06b12beff1ac"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5550), "What does your ideal night look like? Do you go out or are you at home with friends?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5550) },
                    { new Guid("5c2d23ff-bbfd-46a4-bc8f-1acad54a48c6"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5160), "Zombies are overrunning the world. How do you defend yourself?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5160) },
                    { new Guid("5c66c10b-7346-44a7-ad91-92a366e7e6e9"), new Guid("37f07a7d-170b-4dba-a217-10ad3c53cc4b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5680), "Peanut butter or Nutella?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5680) },
                    { new Guid("5d737a86-3531-474f-b8ca-a7148a6eae59"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5090), "Do you like to roleplay?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5090) },
                    { new Guid("6232a263-7a10-46b9-982a-b37dffb759e3"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5500), "What’s your favorite and least favorite household chore?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5500) },
                    { new Guid("6909daf0-d66c-48db-ae86-6275eeb24746"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5120), "If a cute couple asked you to do a threesome, would you say yes?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5120) },
                    { new Guid("6bc8dedc-6225-4f24-b0f2-b4dc108afbd9"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5560), "If you could change one thing about the way you were raised, what would that be?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5560) },
                    { new Guid("6e75a229-3b2b-4b0e-a871-c9f08fefbb18"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5380), "Would you rather Win $50,000 or let your best friend win $500,000?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5390) },
                    { new Guid("6f05066a-716d-4902-93d9-3004fecc9ca2"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5330), "What do you wear when you go to sleep?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5330) },
                    { new Guid("70c39a73-9956-4d28-8ed8-b003920902a2"), new Guid("37f07a7d-170b-4dba-a217-10ad3c53cc4b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5720), "Dine-in or delivery?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5720) },
                    { new Guid("7323a306-be79-4313-aa1c-bf02aab96d44"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5030), "Do you prefer firm or light touches?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5030) },
                    { new Guid("77c21ee0-a701-4ab3-9e38-69818706a612"), new Guid("37f07a7d-170b-4dba-a217-10ad3c53cc4b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5690), "Quit coffee or never have snacks during films and series?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5690) },
                    { new Guid("7927c3dd-4241-4c3b-adfc-b01fb3bc08be"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5150), "What meal or snack will you never refuse?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5150) },
                    { new Guid("7cb71b6a-a95c-427c-903b-6c8395b7b024"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5060), "Do you prefer to make out with the lights on or off?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5060) },
                    { new Guid("8892f35e-e3b7-4f7a-9ebd-108387b916fd"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5410), "Your dad and boyfriend switch bodies (Freaky Friday style). The only way to switch them back is to have sex with them, lights on and sober. Who do you pick?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5410) },
                    { new Guid("890ceb50-3904-41ad-8ca3-90b63a97150d"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5390), "Would you rather be stung by a thousand bees or stomp a kitten?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5390) },
                    { new Guid("8f2e16ad-3b56-499e-9de0-305dcbba39f3"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5360), "Would you rather have hiccups for the rest of your life or constantly feel like you have to sneeze?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5360) },
                    { new Guid("905a218c-909f-4e6d-ba40-15d64c09c553"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5350), "Would you rather have a boyfriend who’s stinking rich and ugly? Or a friend who’s dirt poor and handsome?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5350) },
                    { new Guid("95da8dea-9ea0-4f80-b581-8ab0ebc9132d"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5490), "If you were the mayor of your city, what rule would you instantly enforce?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5490) },
                    { new Guid("96ed2871-27c8-4548-ab0b-c533aa09a3f8"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5370), "Would you rather be surrounded by people who brag all the time or by people who constantly complain?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5370) },
                    { new Guid("97c00899-08ee-473e-bad6-83a5a87c569c"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5040), "Do you think it’s okay if a guy wants to be submissive in the bedroom?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5040) },
                    { new Guid("9afd993e-88ff-4a4c-b901-6a21a5c9f28f"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5020), "What physical act gives you the most pleasure?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5020) },
                    { new Guid("9b5c8e90-4afe-4b21-a582-c32dfd99b15d"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5160), "What’s the weirdest thing you carry in your purse?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5160) },
                    { new Guid("9e78edb8-1abc-4525-bea9-7be8c33fd3e3"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5130), "What’s the dirtiest thing someone said to you during sex?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5130) },
                    { new Guid("a09c96e8-50b6-4941-9710-8bb2d0ff0e79"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5640), "What’s something you swear by?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5640) },
                    { new Guid("a0bd81c1-2b55-4658-906c-d530d9d96c5e"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5080), "What do you fantasize about when you touch yourself?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5080) },
                    { new Guid("a2141632-dbd5-4250-808e-ab9fd0c537d1"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5480), "What’s the most romantic thing you’ve ever done for someone?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5480) },
                    { new Guid("a4e6295c-c0b0-4c9b-a921-c887046ad1b4"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5220), "You’re on a first date with a dude you like and you let out an audible fart. What do you do?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5220) },
                    { new Guid("a6b30dee-1886-4d79-991c-af1e15f15f05"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5520), "What’s one responsibility of yours that you’d prefer to delegate to a professional?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5520) },
                    { new Guid("a6fc9033-1c95-4175-b04e-08b69a2f6012"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5610), "Where do you feel the most at home?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5610) },
                    { new Guid("a7d64e8e-0f8d-4240-9dbd-4377f535e942"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5300), "What do you think is the most important thing a woman can give to a man?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5300) },
                    { new Guid("a95870c6-0be6-4e16-9fc5-24c68f8f9cdc"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5600), "If you could only put on one piece of makeup, what would it be?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5600) },
                    { new Guid("af915adc-6015-413e-a0b0-7d01b176372d"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5630), "Where do you go if you want to escape?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5630) },
                    { new Guid("b0a06c73-38d1-4684-8379-c104ee685ed3"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5250), "You’re at a party and really need to drop a deuce. But their toilet doesn’t flush. Do you use the toilet anyway, or do your business in the yard?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5250) },
                    { new Guid("b1cf9863-c4c2-4272-9b4d-3ff6fd73b94c"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5280), "What does good sex mean to you?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5280) },
                    { new Guid("b4a107b6-5469-4dcf-9a8b-95f89a465e8a"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5220), "You and all your friends have to enter a mixed martial arts tournament. Do you win?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5220) },
                    { new Guid("b57f8159-60c6-4eee-993b-6ad17baadee8"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5630), "What do your friends and family call you?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5630) },
                    { new Guid("b8a99be6-044d-4a5f-9166-6d513e1aaca0"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5260), "What do you miss most about being single? (She has to pick something.)", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5260) },
                    { new Guid("b9e27e17-a97d-4218-acb4-156aeae9cf69"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5470), "What’s something you’d like to be remembered for?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5470) },
                    { new Guid("ba18d6b5-c2af-4a03-b861-9e2cac94c634"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5540), "Would you continue working if you were rich and didn’t need to?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5540) },
                    { new Guid("bc1b17fa-7e58-43dd-9095-cfaa83fafe59"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5420), "What’s a recent book you read or movie you saw that taught you something?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5420) },
                    { new Guid("bd2b60fe-1c64-4a8f-9522-ee0724551e06"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5320), "Can you surrender to love or is it something that scares you?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5320) },
                    { new Guid("be55176f-24e9-4736-ad27-29242dd8ca24"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5190), "What’s the last time you did something scary?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5190) },
                    { new Guid("c1dbc7df-e3fe-4d32-8b9b-213b644d8c62"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5410), "Name three things that you can do to get out of a funk.", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5410) },
                    { new Guid("c4f3f181-b3bb-4f59-b19c-a1d7250bae04"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5570), "What’s something that gives your life meaning?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5570) },
                    { new Guid("c5cb421d-6c07-45ee-89b7-b6a3ceeb365d"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5340), "Would you rather have a cat with a human face or a dog with human hands?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5340) },
                    { new Guid("c7ea5de8-17fe-4117-969e-5b072a9d9566"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5070), "Would you rather end a good first date with a passionate kiss or sex?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5070) },
                    { new Guid("cf9c8515-2a92-4891-89b0-fb63a338c91c"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5300), "What makes you feel sexy?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5310) },
                    { new Guid("d9548576-bf8e-4a0e-812d-074508550992"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5610), "What’s the one compliment you get the most?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5610) },
                    { new Guid("dcd011ae-6860-4660-9610-2c234560c50f"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5440), "If you could make one decision to change the world, what would you do?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5450) },
                    { new Guid("e6aecff3-5d98-45b9-b70d-13e3a8e310ac"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5130), "What are your thoughts on toys?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5130) },
                    { new Guid("e6e10577-130c-45b2-ab7b-dacf077939a7"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5110), "What does your ideal one-night stand look like?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5110) },
                    { new Guid("ebb075f2-dd63-44ec-900d-8f0b98853705"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5280), "What do you find the most attractive in a man?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5280) },
                    { new Guid("ed73f8e4-8f26-4465-bece-7bc8169fd27d"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5030), "Do guy-on-guy videos turn you on more than guy-on-girl?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5030) },
                    { new Guid("ee9ea80f-025b-47c8-ab56-441d35524671"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5050), "Would you rather receive or give oral?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5050) },
                    { new Guid("f123ee09-7cac-4819-9d95-5dc2d968eb96"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5210), "If your friends and family hear that you were arrested, what would they think you did?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5210) },
                    { new Guid("f2206a23-777f-4ef5-bf55-1d09379abccd"), new Guid("6fb4b41f-96ea-4422-848b-287a711384af"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5330), "Do you prefer cuddling or kissing?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5330) },
                    { new Guid("f6412f9f-58c6-4c48-af25-5261f931456c"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5460), "If you could ask your pet 3 questions, what would they be?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5460) },
                    { new Guid("f7c823b8-5998-4ddb-9ac6-829f5847fc6b"), new Guid("10ec125a-39f6-41da-826c-840341e1f025"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5580), "What song would you want to play on your wedding day?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5580) },
                    { new Guid("f90ba460-255d-440b-973c-76bd9b849d9d"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5140), "Where do you like to be touched most?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5140) },
                    { new Guid("f96bdd32-af27-4aa8-bd35-136db7b6c3d1"), new Guid("8e8d3434-98df-433a-99e6-36e12a541132"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5230), "You find out your best friend is a lesbian and she’s in love with you. How do you react?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5230) },
                    { new Guid("fca353ff-a8cc-4683-9398-a8ab285a9344"), new Guid("b1f978bd-5d89-471e-a312-3e1c66a83d0b"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5100), "Have you ever had sex with someone you just met?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5100) },
                    { new Guid("ff12d975-2f50-48da-a539-9cff29ae355e"), new Guid("40c7656e-a051-41eb-a57d-d0361f55b9c1"), new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5360), "Would you rather fight young Mike Tyson once or talk like Mike Tyson for the rest of your life?", new DateTime(2024, 12, 29, 22, 15, 6, 713, DateTimeKind.Utc).AddTicks(5360) }
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
                name: "IX_BlockedUsers_BlockedUserId",
                table: "BlockedUsers",
                column: "BlockedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_BlockerUserId",
                table: "BlockedUsers",
                column: "BlockerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_ParentId",
                table: "Genders",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_HiddenRooms_RoomId",
                table: "HiddenRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HiddenRooms_UserId",
                table: "HiddenRooms",
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
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

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
                name: "IX_Rooms_CreatedAt",
                table: "Rooms",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FinishedAt",
                table: "Rooms",
                column: "FinishedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IsDeleted",
                table: "Rooms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_StartedAt",
                table: "Rooms",
                column: "StartedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemQuestions_CategoryId",
                table: "SystemQuestions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileGenders_GenderId",
                table: "UserProfileGenders",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AgeFilterMax",
                table: "UserProfiles",
                column: "AgeFilterMax");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AgeFilterMin",
                table: "UserProfiles",
                column: "AgeFilterMin");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_BirthDate",
                table: "UserProfiles",
                column: "BirthDate");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_DistanceFilter",
                table: "UserProfiles",
                column: "DistanceFilter");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_Hidden",
                table: "UserProfiles",
                column: "Hidden");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_pos",
                table: "UserProfiles",
                column: "pos");

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
                name: "AvailableDescriptors");

            migrationBuilder.DropTable(
                name: "BlockedUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "HiddenRooms");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "RoomContent");

            migrationBuilder.DropTable(
                name: "RoomParticipantEvents");

            migrationBuilder.DropTable(
                name: "SystemQuestions");

            migrationBuilder.DropTable(
                name: "UserProfileGenders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RoomParticipants");

            migrationBuilder.DropTable(
                name: "QuestionCategories");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
