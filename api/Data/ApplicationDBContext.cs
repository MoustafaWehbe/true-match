using System;
using api.Models;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<UserProfileInterest> userProfileInterests { get; set; }
        public DbSet<UserProfileLifeStyle> userProfileLifeStyles { get; set; }
        public DbSet<LifeStyle> LifeStyles { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<LiveStream> LiveStreams { get; set; }
        public DbSet<LiveStreamParticipant> LiveStreamParticipants { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public List<Media> Media { get; set; } = new List<Media>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserProfileInterest>(x => x.HasKey(p => new { p.UserProfileId, p.InterestId }));
            builder.Entity<UserProfileLifeStyle>(x => x.HasKey(p => new { p.UserProfileId, p.LifeStyleId }));

            builder.Entity<User>()
            .HasMany(u => u.LiveStreams)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId);

            builder.Entity<User>()
            .HasOne(u => u.UserProfile)
            .WithOne(up => up.User)
            .HasForeignKey<UserProfile>(up => up.UserId);

            builder.Entity<UserProfileInterest>()
            .HasOne(u => u.UserProfile)
            .WithMany(u => u.UserProfileInterests)
            .HasForeignKey(ui => ui.UserProfileId);

            builder.Entity<UserProfileInterest>()
            .HasOne(u => u.Interest)
            .WithMany(u => u.UserProfileInterests)
            .HasForeignKey(ui => ui.InterestId);

            builder.Entity<UserProfileLifeStyle>()
            .HasOne(u => u.UserProfile)
            .WithMany(u => u.UserProfileLifeStyles)
            .HasForeignKey(ui => ui.UserProfileId);

            builder.Entity<UserProfileLifeStyle>()
            .HasOne(u => u.LifeStyle)
            .WithMany(u => u.userProfileLifeStyles)
            .HasForeignKey(ui => ui.LifeStyleId);

            builder.Entity<LiveStreamParticipant>()
            .HasKey(lsp => new { lsp.LiveStreamId, lsp.UserId });

            // Configure the relationships
            builder.Entity<LiveStreamParticipant>()
                .HasOne(lsp => lsp.LiveStream)
                .WithMany(ls => ls.LiveStreamParticipants)
                .HasForeignKey(lsp => lsp.LiveStreamId);

            builder.Entity<LiveStreamParticipant>()
                .HasOne(lsp => lsp.User)
                .WithMany(u => u.LiveStreamParticipants)
                .HasForeignKey(lsp => lsp.UserId);

            builder.Entity<User>()
            .HasMany(u => u.Media)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);

            List<Interest> interests = new List<Interest>
            {
                new Interest
                {
                    Id = 1,
                    Name = "Travel",
                },
                new Interest
                {
                    Id = 2,
                    Name = "Cooking",
                },
                 new Interest
                {
                    Id = 3,
                    Name = "Sports",
                },
                new Interest
                {
                    Id = 4,
                    Name = "Music",
                },
                 new Interest
                {
                    Id = 5,
                    Name = "Movies",
                }
            };
            builder.Entity<Interest>().HasData(interests);

            List<LifeStyle> lifeStyles = new List<LifeStyle>
            {
                new LifeStyle
                {
                    Id = 1,
                    Name = "Smoking",
                },
                new LifeStyle
                {
                    Id = 2,
                    Name = "Workout",
                },
                 new LifeStyle
                {
                    Id = 3,
                    Name = "Drinking",
                },
                new LifeStyle
                {
                    Id = 4,
                    Name = "Pets",
                },
            };
            builder.Entity<LifeStyle>().HasData(lifeStyles);
        }

    }
}

