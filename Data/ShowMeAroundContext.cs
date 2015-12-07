namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShowMeAroundContext : DbContext
    {
        public ShowMeAroundContext()
            : base("name=ShowMeAroundContext")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<MeetUp> MeetUp { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>()
                .HasMany(u => u.Languages)
                .WithMany(l => l.Users)
                .Map(
                 m =>
                 {
                     m.MapLeftKey("UserId");
                     m.MapRightKey("LanguageName");
                     m.ToTable("UserLanguages");
                 });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Interests)
                .WithMany(i => i.Users)
                .Map(
                 m =>
                 {
                     m.MapLeftKey("UserId");
                     m.MapRightKey("InterestName");
                     m.ToTable("UserInterests");
                 });

            modelBuilder.Entity<MeetUp>()
                .HasOptional(m => m.Traveler)
                .WithMany();

            modelBuilder.Entity<MeetUp>()
                .HasOptional(m => m.Guide)
                .WithMany();
        }
    }
}
