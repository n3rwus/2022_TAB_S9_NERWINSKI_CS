using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Domain.Entities;

namespace tab_backend.Infrastructure.Data
{
    public class TabContext : DbContext
    {
        public TabContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Folder> Folders {get; set;}
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ImageCategory> ImageCategories { get; set; }
        public DbSet<ImageFolder> ImageFolders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adds ManytoMany Relation
            //image - folder
            modelBuilder.Entity<ImageFolder>().HasKey(x => new { x.ImageID, x.FolderID });
            
            modelBuilder.Entity<ImageFolder>()
                .HasOne<Folder>(f => f.Folder)
                .WithMany(x => x.ImageFolder)
                .HasForeignKey(e => e.FolderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ImageFolder>()
               .HasOne<Image>(i => i.Image)
               .WithMany(x => x.ImageFolder)
               .HasForeignKey(e => e.ImageID)
               .OnDelete(DeleteBehavior.NoAction);

            //Image-category
            modelBuilder.Entity<ImageCategory>().HasKey(x => new { x.ImageID, x.CategoryID });

            modelBuilder.Entity<ImageCategory>()
                .HasOne<Category>(c => c.Category)
                .WithMany(x => x.ImageCategory)
                .HasForeignKey(e => e.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ImageCategory>()
               .HasOne<Image>(i => i.Image)
               .WithMany(x => x.ImageCategory)
               .HasForeignKey(e => e.ImageID)
               .OnDelete(DeleteBehavior.Cascade);


            //Mainfolder-user
            modelBuilder.Entity<MainFolder>()
                .HasOne<User>(u => u.User)
                .WithOne(f => f.Folder)
                .HasForeignKey<MainFolder>(u => u.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            //MainFolder-Folder

            modelBuilder.Entity<Folder>()
                .HasOne<MainFolder>(u => u.MainFolder)
                .WithMany(i => i.Folders)
                .HasForeignKey(u => u.MainFolderID)
                .OnDelete(DeleteBehavior.Cascade);

            //folder-folder
            modelBuilder.Entity<Folder>()
                .HasOne<Folder>(f => f.ParentFolder)
                .WithMany(i => i.Folders)
                .HasForeignKey(u => u.ParentFolderID)
                .OnDelete(DeleteBehavior.NoAction);

            //image-user
            modelBuilder.Entity<Image>()
                .HasOne<User>(u => u.User)
                .WithMany(i => i.Images)
                .HasForeignKey(u => u.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            //user-category
            modelBuilder.Entity<Category>()
                .HasOne<User>(u => u.User)
                .WithMany(i => i.Categories)
                .HasForeignKey(u => u.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
