﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMidterm.Data;

#nullable disable

namespace WebMidterm.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebMidterm.Models.ActorMovie", b =>
                {
                    b.Property<int?>("ActorId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("ActorMovies");
                });

            modelBuilder.Entity("WebMidterm.Models.DirectorMovie", b =>
                {
                    b.Property<int?>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("DirectorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("DirectorMovies");
                });

            modelBuilder.Entity("WebMidterm.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgeLimited")
                        .HasColumnType("int");

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Duration")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Languege")
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("MovieType")
                        .HasColumnType("int");

                    b.Property<string>("Production")
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime?>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WebMidterm.Models.MovieArt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArtName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Artist")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ArtistUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(120)");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieArts");
                });

            modelBuilder.Entity("WebMidterm.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("WebMidterm.Models.ActorMovie", b =>
                {
                    b.HasOne("WebMidterm.Models.Person", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebMidterm.Models.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WebMidterm.Models.DirectorMovie", b =>
                {
                    b.HasOne("WebMidterm.Models.Person", "Director")
                        .WithMany("DirectorMovies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebMidterm.Models.Movie", "Movie")
                        .WithMany("DirectorMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WebMidterm.Models.MovieArt", b =>
                {
                    b.HasOne("WebMidterm.Models.Movie", "Movie")
                        .WithMany("MovieArts")
                        .HasForeignKey("MovieId");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WebMidterm.Models.Movie", b =>
                {
                    b.Navigation("ActorMovies");

                    b.Navigation("DirectorMovies");

                    b.Navigation("MovieArts");
                });

            modelBuilder.Entity("WebMidterm.Models.Person", b =>
                {
                    b.Navigation("ActorMovies");

                    b.Navigation("DirectorMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
