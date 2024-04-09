﻿// <auto-generated />
using System;
using DGA.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DGA.Infrastructure.Database.Migrations
{
    [DbContext(typeof(DgaDbContext))]
    partial class DgaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DGA.Domain.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Movies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2b5c9bfb-332a-4841-9a35-1c52f669473b"),
                            Description = "Description of Movie 1",
                            Director = "Director 1",
                            ReleaseYear = 2021,
                            Title = "Movie 1"
                        },
                        new
                        {
                            Id = new Guid("792dbafe-b439-41e8-9379-176d89f5d04d"),
                            Description = "Description of Movie 2",
                            Director = "Director 2",
                            ReleaseYear = 2022,
                            Title = "Movie 2"
                        },
                        new
                        {
                            Id = new Guid("0345fa26-b2a8-4dad-8109-48084181eb90"),
                            Description = "Description of Movie 3",
                            Director = "Director 3",
                            ReleaseYear = 2023,
                            Title = "Movie 3"
                        });
                });

            modelBuilder.Entity("DGA.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("484d3bbb-5d7e-4f79-abcf-49a134467259"),
                            Email = "beka@example.com",
                            Firstname = "Beka",
                            Lastname = "Pukhashvili"
                        },
                        new
                        {
                            Id = new Guid("e328e89b-b810-442f-a886-6343d21d4367"),
                            Email = "lasha@example.com",
                            Firstname = "Lasha",
                            Lastname = "Pukhashvili"
                        });
                });

            modelBuilder.Entity("DGA.Domain.UserMovie", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSeen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("UserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("UserMovies", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("484d3bbb-5d7e-4f79-abcf-49a134467259"),
                            MovieId = new Guid("2b5c9bfb-332a-4841-9a35-1c52f669473b"),
                            IsSeen = true
                        },
                        new
                        {
                            UserId = new Guid("484d3bbb-5d7e-4f79-abcf-49a134467259"),
                            MovieId = new Guid("792dbafe-b439-41e8-9379-176d89f5d04d"),
                            IsSeen = false
                        },
                        new
                        {
                            UserId = new Guid("484d3bbb-5d7e-4f79-abcf-49a134467259"),
                            MovieId = new Guid("0345fa26-b2a8-4dad-8109-48084181eb90"),
                            IsSeen = true
                        },
                        new
                        {
                            UserId = new Guid("e328e89b-b810-442f-a886-6343d21d4367"),
                            MovieId = new Guid("2b5c9bfb-332a-4841-9a35-1c52f669473b"),
                            IsSeen = true
                        },
                        new
                        {
                            UserId = new Guid("e328e89b-b810-442f-a886-6343d21d4367"),
                            MovieId = new Guid("792dbafe-b439-41e8-9379-176d89f5d04d"),
                            IsSeen = false
                        });
                });

            modelBuilder.Entity("DGA.Domain.UserMovie", b =>
                {
                    b.HasOne("DGA.Domain.Movie", "Movie")
                        .WithMany("UserMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DGA.Domain.User", "User")
                        .WithMany("UserMovies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DGA.Domain.Movie", b =>
                {
                    b.Navigation("UserMovies");
                });

            modelBuilder.Entity("DGA.Domain.User", b =>
                {
                    b.Navigation("UserMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
