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
        }

        public DbSet<User> User { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<Language> Language { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Many-to-many UserLanguages
            modelBuilder.Entity<Language>().
                HasMany(l => l.Users).
                WithMany(u => u.Languages).
                Map(
                 m =>
                 {
                     m.MapLeftKey("UserId");
                     m.MapRightKey("LanguageName");
                     m.ToTable("UserLanguages");
                 });

            // Many-to-many UserInterests
            modelBuilder.Entity<Interest>().
                HasMany(i => i.Users).
                WithMany(u => u.Interests).
                Map(
                 m =>
                 {
                     m.MapLeftKey("UserId");
                     m.MapRightKey("InterestName");
                     m.ToTable("UserInterests");
                 });
        }
    }
}
