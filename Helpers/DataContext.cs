using Microsoft.EntityFrameworkCore;
using TABv3.Entities;

namespace TABv3.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Folder> Folders { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>()
                  .HasMany(x => x.ChildrenFolders)
                  .WithOne(x => x.ParentFolder)
                  .HasForeignKey(x => x.ParentFolderId)
                  .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Folder>()
                .HasMany(x => x.Images)
                .WithOne(x => x.Folder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}
