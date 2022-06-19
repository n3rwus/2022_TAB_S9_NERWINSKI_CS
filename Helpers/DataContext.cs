using Microsoft.EntityFrameworkCore;
using TABv3.Entities;

namespace TABv3.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ImageCategory> ImageCategories { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<MainFolder> MainFolders { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageCategory>()
                .HasKey(ic => new { ic.ImageId, ic.CategoryId });

            modelBuilder.Entity<ImageCategory>()
                .HasOne(ic => ic.Image)
                .WithMany(i => i.ImageCategories)
                .HasForeignKey(ic => ic.ImageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ImageCategory>()
                .HasOne(ic => ic.Category)
                .WithMany(c => c.ImageCategories)
                .HasForeignKey(ic => ic.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}
