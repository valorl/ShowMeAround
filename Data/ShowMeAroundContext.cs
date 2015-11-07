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

        }
    }
}
