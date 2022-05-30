﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tab_backend.Infrastructure.Data;

namespace tab_backend.Infrastructure.Migrations
{
    [DbContext(typeof(TabContext))]
    [Migration("20220530191042_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("tab_backend.Domain.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.Folder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentFolderID")
                        .HasColumnType("int");

                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentFolderID");

                    b.HasIndex("UserID");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.ImageCategory", b =>
                {
                    b.Property<int>("ImageID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("ImageID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("ImageCategories");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.ImageFolder", b =>
                {
                    b.Property<int>("ImageID")
                        .HasColumnType("int");

                    b.Property<int>("FolderID")
                        .HasColumnType("int");

                    b.HasKey("ImageID", "FolderID");

                    b.HasIndex("FolderID");

                    b.ToTable("ImageFolders");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.Folder", b =>
                {
                    b.HasOne("tab_backend.Domain.Entities.Folder", "ParentFolder")
                        .WithMany("Folders")
                        .HasForeignKey("ParentFolderID");

                    b.HasOne("tab_backend.Domain.Entities.User", "User")
                        .WithMany("Folders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentFolder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.Image", b =>
                {
                    b.HasOne("tab_backend.Domain.Entities.User", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.ImageCategory", b =>
                {
                    b.HasOne("tab_backend.Domain.Entities.Category", "Category")
                        .WithMany("ImageCategory")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tab_backend.Domain.Entities.Image", "Image")
                        .WithMany("ImageCategory")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.ImageFolder", b =>
                {
                    b.HasOne("tab_backend.Domain.Entities.Folder", "Folder")
                        .WithMany("ImageFolder")
                        .HasForeignKey("FolderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tab_backend.Domain.Entities.Image", "Image")
                        .WithMany("ImageFolder")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Folder");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.Category", b =>
                {
                    b.Navigation("ImageCategory");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.Folder", b =>
                {
                    b.Navigation("Folders");

                    b.Navigation("ImageFolder");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.Image", b =>
                {
                    b.Navigation("ImageCategory");

                    b.Navigation("ImageFolder");
                });

            modelBuilder.Entity("tab_backend.Domain.Entities.User", b =>
                {
                    b.Navigation("Folders");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
