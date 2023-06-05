﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectDatabase1.DataAccess;

#nullable disable

namespace ProjectDatabase1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230427184932_updated")]
    partial class updated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectDatabase1.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("date");

                    b.Property<string>("ProjectAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProjectDate")
                        .HasColumnType("date");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectCategoryId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectDatabase1.Models.ProjectCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("ProjectCategories");
                });

            modelBuilder.Entity("ProjectDatabase1.Models.Project", b =>
                {
                    b.HasOne("ProjectDatabase1.Models.ProjectCategory", "ProjectCategory")
                        .WithMany()
                        .HasForeignKey("ProjectCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
