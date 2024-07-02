﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240701215353_liveStreamParticipants")]
    partial class liveStreamParticipants
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d7bd53b8-4d47-450e-bf57-fcae596c4cbd",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "f5160ba8-0454-4152-a0b4-1d44c6fb3461",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("api.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(1990),
                            Name = "Travel",
                            UpdatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(1990)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000),
                            Name = "Cooking",
                            UpdatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000),
                            Name = "Sports",
                            UpdatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000),
                            Name = "Music",
                            UpdatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000),
                            Name = "Movies",
                            UpdatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2000)
                        });
                });

            modelBuilder.Entity("api.Models.LifeStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("LifeStyles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020),
                            Name = "Smoking",
                            UpdatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020),
                            Name = "Workout",
                            UpdatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2020),
                            Name = "Drinking",
                            UpdatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2030)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2030),
                            Name = "Pets",
                            UpdatedAt = new DateTime(2024, 7, 1, 21, 53, 53, 224, DateTimeKind.Utc).AddTicks(2030)
                        });
                });

            modelBuilder.Entity("api.Models.LiveStream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FinishedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("HasStarted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ScheduledAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LiveStreams");
                });

            modelBuilder.Entity("api.Models.LiveStreamParticipant", b =>
                {
                    b.Property<int>("LiveStreamId")
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.Property<bool>("Attended")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("AttendedFromTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("AttendedToTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsInterested")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("LiveStreamId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("LiveStreamParticipants");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("api.Models.UserInterest", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("InterestId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "InterestId");

                    b.HasIndex("InterestId");

                    b.ToTable("UserInterests");
                });

            modelBuilder.Entity("api.Models.UserLifeStyle", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("LifeStyleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "LifeStyleId");

                    b.HasIndex("LifeStyleId");

                    b.ToTable("UserLifeStyles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.LiveStream", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany("LiveStreams")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.LiveStreamParticipant", b =>
                {
                    b.HasOne("api.Models.LiveStream", "LiveStream")
                        .WithMany("LiveStreamParticipants")
                        .HasForeignKey("LiveStreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("LiveStreamParticipants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiveStream");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.UserInterest", b =>
                {
                    b.HasOne("api.Models.Interest", "Interest")
                        .WithMany("userInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserInterests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.UserLifeStyle", b =>
                {
                    b.HasOne("api.Models.LifeStyle", "LifeStyle")
                        .WithMany("userLifeStyles")
                        .HasForeignKey("LifeStyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserLifeStyles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LifeStyle");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Interest", b =>
                {
                    b.Navigation("userInterests");
                });

            modelBuilder.Entity("api.Models.LifeStyle", b =>
                {
                    b.Navigation("userLifeStyles");
                });

            modelBuilder.Entity("api.Models.LiveStream", b =>
                {
                    b.Navigation("LiveStreamParticipants");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Navigation("LiveStreamParticipants");

                    b.Navigation("LiveStreams");

                    b.Navigation("UserInterests");

                    b.Navigation("UserLifeStyles");
                });
#pragma warning restore 612, 618
        }
    }
}
