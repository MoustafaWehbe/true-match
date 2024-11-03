﻿using api.Models;
using ChatApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomContent> RoomContent { get; set; }
        public DbSet<RoomParticipantEvent> RoomParticipantEvents { get; set; }
        public DbSet<RoomParticipant> RoomParticipants { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<SystemQuestion> SystemQuestions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }
        public DbSet<HiddenRoom> HiddenRooms { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserProfileGender> UserProfileGenders { get; set; }

        public DbSet<AvailableDescriptor> AvailableDescriptors { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasPostgresExtension("postgis");

            builder.ApplyConfiguration(new UserProfileGenderConfiguration());
            builder.ApplyConfiguration(new RoomParticipantConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new MatchConfiguration());
            builder.ApplyConfiguration(new GenderConfiguration());
            builder.ApplyConfiguration(new AvailableDescriptorConfiguration());

            SeedRelevantData.Seed(builder);
        }
    }
}

