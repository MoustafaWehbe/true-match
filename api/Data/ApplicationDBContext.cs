using api.Models;
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
        public DbSet<LiveStreamContent> LiveStreamContent { get; set; }
        public DbSet<LiveStreamParticipant> LiveStreamParticipants { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public List<Media> Media { get; set; } = new List<Media>();
        public DbSet<Match> Matches { get; set; }
        public DbSet<SystemQuestion> SystemQuestions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserProfileInterestConfiguration());
            builder.ApplyConfiguration(new UserProfileLifeStyleConfiguration());
            builder.ApplyConfiguration(new LiveStreamParticipantConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new MatchConfiguration());

            // builder.Entity<SystemQuestion>()
            //     .HasOne(sq => sq.Category)
            //     .WithMany(c => c.SystemQuestions)  // A category can have many questions
            //     .HasForeignKey(sq => sq.CategoryId)  // Foreign key property in SystemQuestion
            //     .IsRequired();  // CategoryId is required in SystemQuestion


            SeedData.Seed(builder);
        }
    }
}

