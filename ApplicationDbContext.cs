using Microsoft.EntityFrameworkCore;
using ActivityMonitor.Entities;

namespace ActivityMonitor
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ChangeLog> ChangeLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbPath = Path.Combine(appDataPath, "ActivityMonitor", "ActivityMonitor.db");
            //if (!File.Exists(dbPath)) 
            //{
            //    File.Copy("ActivityMonitor.db", dbPath, true);
            //}
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChangeLog>()
                .Property(c => c.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Activity>()
                .HasMany(c => c.ChangeLogs)
                .WithOne(a => a.Activity)
                .HasForeignKey(a => a.ActivityId);
        }

    }
}
