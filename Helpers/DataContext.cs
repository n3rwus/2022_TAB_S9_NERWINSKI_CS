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
            //Image - Folder
            modelBuilder.Entity<ImageFolder>().HasKey(x => new {x.ImageId, x.FolderId });

            modelBuilder.Entity<ImageFolder>()
                .HasOne<Folder>(f => f.Folder)
                .WithMany(x => x.ImageFolder)
                .HasForeignKey(e => e.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ImageFolder>()
               .HasOne<Image>(i => i.Image)
               .WithMany(x => x.ImageFolders)
               .HasForeignKey(e => e.ImageId)
               .OnDelete(DeleteBehavior.NoAction);

            //Image - Category
            modelBuilder.Entity<ImageCategory>().HasKey(x => new { x.ImageId, x.CategoryId });

            modelBuilder.Entity<ImageCategory>()
                .HasOne<Category>(c => c.Category)
                .WithMany(x => x.ImageCategories)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ImageCategory>()
               .HasOne<Image>(i => i.Image)
               .WithMany(x => x.ImageCategories)
               .HasForeignKey(e => e.ImageId)
               .OnDelete(DeleteBehavior.Cascade);

            //MainFolder - Account
            modelBuilder.Entity<MainFolder>()
                .HasOne<Account>(u => u.Account)
                .WithOne(f => f.Folder)
                .HasForeignKey<MainFolder>(u => u.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            //MainFolder - Folder
            modelBuilder.Entity<Folder>()
                .HasOne<MainFolder>(u => u.MainFolder)
                .WithMany(i => i.Folders)
                .HasForeignKey(u => u.MainFolderId)
                .OnDelete(DeleteBehavior.Cascade);

            //Folder - Folder
            modelBuilder.Entity<Folder>()
                .HasOne<Folder>(f => f.ParentFolder)
                .WithMany(i => i.Folders)
                .HasForeignKey(u => u.ParentFolderId)
                .OnDelete(DeleteBehavior.NoAction);

            //Image - Account
            modelBuilder.Entity<Image>()
                .HasOne<Account>(u => u.Account)
                .WithMany(i => i.Images)
                .HasForeignKey(u => u.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            //Account - Category
            modelBuilder.Entity<Category>()
                .HasOne<Account>(u => u.Account)
                .WithMany(i => i.Categories)
                .HasForeignKey(u => u.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}
