﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAlbum.Helpers;

#nullable disable

namespace WebAlbum.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220712120752_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAlbum.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("bit");

                    b.Property<string>("Created")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PasswordReset")
                        .HasColumnType("text");

                    b.Property<string>("ResetToken")
                        .HasColumnType("text");

                    b.Property<string>("ResetTokenExpires")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Updated")
                        .HasColumnType("text");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("text");

                    b.Property<string>("Verified")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("WebAlbum.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("WebAlbum.Entities.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("FolderDescription")
                        .HasColumnType("text");

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentFolderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folder", (string)null);
                });

            modelBuilder.Entity("WebAlbum.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("FolderId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("ImageDateOfCreate")
                        .HasColumnType("datetime");

                    b.Property<string>("ImageDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImageFormat")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ImageSize")
                        .HasColumnType("int");

                    b.Property<string>("ImageTitle")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("FolderId");

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("WebAlbum.Entities.ImageCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("ImageCategory", (string)null);
                });

            modelBuilder.Entity("WebAlbum.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Created")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text");

                    b.Property<string>("Expires")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("text");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("text");

                    b.Property<string>("Revoked")
                        .HasColumnType("text");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("WebAlbum.Models.Categores.Response.CategoryResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoryResponse");
                });

            modelBuilder.Entity("WebAlbum.Entities.Category", b =>
                {
                    b.HasOne("WebAlbum.Entities.Account", "Account")
                        .WithMany("Categories")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Category_Account");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebAlbum.Entities.Folder", b =>
                {
                    b.HasOne("WebAlbum.Entities.Account", "Account")
                        .WithMany("Folders")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Folder_Account");

                    b.HasOne("WebAlbum.Entities.Folder", "ParentFolder")
                        .WithMany("InverseParentFolder")
                        .HasForeignKey("ParentFolderId")
                        .HasConstraintName("FK_Folder_ParentFolder");

                    b.Navigation("Account");

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("WebAlbum.Entities.Image", b =>
                {
                    b.HasOne("WebAlbum.Entities.Account", "Account")
                        .WithMany("Images")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Image_Account");

                    b.HasOne("WebAlbum.Entities.Folder", "Folder")
                        .WithMany("Images")
                        .HasForeignKey("FolderId")
                        .HasConstraintName("FK_Image_Folder");

                    b.Navigation("Account");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("WebAlbum.Entities.ImageCategory", b =>
                {
                    b.HasOne("WebAlbum.Entities.Category", "Category")
                        .WithMany("ImageCategories")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_ImageCategory_Category");

                    b.HasOne("WebAlbum.Entities.Image", "Image")
                        .WithMany("ImageCategories")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK_ImageCategory_Image");

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("WebAlbum.Entities.RefreshToken", b =>
                {
                    b.HasOne("WebAlbum.Entities.Account", "Account")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__RefreshTo__Accou__2645B050");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebAlbum.Entities.Account", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Folders");

                    b.Navigation("Images");

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("WebAlbum.Entities.Category", b =>
                {
                    b.Navigation("ImageCategories");
                });

            modelBuilder.Entity("WebAlbum.Entities.Folder", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("InverseParentFolder");
                });

            modelBuilder.Entity("WebAlbum.Entities.Image", b =>
                {
                    b.Navigation("ImageCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
