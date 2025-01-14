﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using src;

namespace src.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210404091311_define_basic_models")]
    partial class define_basic_models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("src.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("src.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("personId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("personId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("src.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("commentText")
                        .HasColumnType("TEXT");

                    b.Property<int?>("creatorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("Date");

                    b.Property<DateTime>("dateModified")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("creatorId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("src.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("personId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("personId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("src.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternateName")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternativeHeadline")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("doorTime")
                        .HasColumnType("Date");

                    b.Property<double>("duration")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("Date");

                    b.Property<string>("eventAttendanceMode")
                        .HasColumnType("TEXT");

                    b.Property<string>("eventStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("headline")
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .HasColumnType("TEXT");

                    b.Property<string>("inLanguage")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isAccessibleForFree")
                        .HasColumnType("INTEGER");

                    b.Property<string>("location")
                        .HasColumnType("TEXT");

                    b.Property<int>("maximumAttendeeCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("organizer")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("Date");

                    b.Property<string>("url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("src.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("about")
                        .HasColumnType("TEXT");

                    b.Property<string>("abstractText")
                        .HasColumnType("TEXT");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternativeHeadline")
                        .HasColumnType("TEXT");

                    b.Property<string>("contentRating")
                        .HasColumnType("TEXT");

                    b.Property<string>("copyrightHolder")
                        .HasColumnType("TEXT");

                    b.Property<string>("copyrightYear")
                        .HasColumnType("TEXT");

                    b.Property<string>("creator")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("Date");

                    b.Property<DateTime>("dateModified")
                        .HasColumnType("Date");

                    b.Property<DateTime>("datePublished")
                        .HasColumnType("Date");

                    b.Property<double>("duration")
                        .HasColumnType("REAL");

                    b.Property<string>("headline")
                        .HasColumnType("TEXT");

                    b.Property<string>("inLanguage")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isFamilyFriendly")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("isPartOfId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("locationCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("musicBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("producer")
                        .HasColumnType("TEXT");

                    b.Property<string>("trailerUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("isPartOfId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("src.MovieList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternateName")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("headline")
                        .HasColumnType("TEXT");

                    b.Property<string>("itemListOrder")
                        .HasColumnType("TEXT");

                    b.Property<int>("numberOfItems")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ownerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ownerId");

                    b.ToTable("MovieLists");
                });

            modelBuilder.Entity("src.MovieListItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("itemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("order")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("parentListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("itemId");

                    b.HasIndex("parentListId");

                    b.ToTable("MovieListItem");
                });

            modelBuilder.Entity("src.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalName")
                        .HasColumnType("TEXT");

                    b.Property<string>("address")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternateName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("Date");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("familyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("givenName")
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("src.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("headline")
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .HasColumnType("TEXT");

                    b.Property<string>("url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("src.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("additionalType")
                        .HasColumnType("TEXT");

                    b.Property<string>("alternateName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("Date");

                    b.Property<DateTime>("dateModified")
                        .HasColumnType("Date");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("optionSet")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("src.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("authorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ratingValue")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("authorId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("src.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDisabled")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("personId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("personId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("src.VoteAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("agentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("answer")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("Date");

                    b.Property<DateTime>("dateModified")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("agentId");

                    b.ToTable("VoteActions");
                });

            modelBuilder.Entity("src.Account", b =>
                {
                    b.HasOne("src.User", null)
                        .WithMany("accounts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("src.Actor", b =>
                {
                    b.HasOne("src.Person", "person")
                        .WithMany()
                        .HasForeignKey("personId");

                    b.Navigation("person");
                });

            modelBuilder.Entity("src.Comment", b =>
                {
                    b.HasOne("src.Movie", null)
                        .WithMany("comments")
                        .HasForeignKey("MovieId");

                    b.HasOne("src.User", "creator")
                        .WithMany()
                        .HasForeignKey("creatorId");

                    b.Navigation("creator");
                });

            modelBuilder.Entity("src.Director", b =>
                {
                    b.HasOne("src.Person", "person")
                        .WithMany()
                        .HasForeignKey("personId");

                    b.Navigation("person");
                });

            modelBuilder.Entity("src.Event", b =>
                {
                    b.HasOne("src.Movie", null)
                        .WithMany("events")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("src.Movie", b =>
                {
                    b.HasOne("src.Movie", "isPartOf")
                        .WithMany()
                        .HasForeignKey("isPartOfId");

                    b.Navigation("isPartOf");
                });

            modelBuilder.Entity("src.MovieList", b =>
                {
                    b.HasOne("src.User", "owner")
                        .WithMany()
                        .HasForeignKey("ownerId");

                    b.Navigation("owner");
                });

            modelBuilder.Entity("src.MovieListItem", b =>
                {
                    b.HasOne("src.Movie", "item")
                        .WithMany()
                        .HasForeignKey("itemId");

                    b.HasOne("src.MovieList", "parentList")
                        .WithMany("items")
                        .HasForeignKey("parentListId");

                    b.Navigation("item");

                    b.Navigation("parentList");
                });

            modelBuilder.Entity("src.Product", b =>
                {
                    b.HasOne("src.Movie", null)
                        .WithMany("products")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("src.Rating", b =>
                {
                    b.HasOne("src.Movie", null)
                        .WithMany("ratings")
                        .HasForeignKey("MovieId");

                    b.HasOne("src.User", "author")
                        .WithMany()
                        .HasForeignKey("authorId");

                    b.Navigation("author");
                });

            modelBuilder.Entity("src.User", b =>
                {
                    b.HasOne("src.Person", "person")
                        .WithMany()
                        .HasForeignKey("personId");

                    b.Navigation("person");
                });

            modelBuilder.Entity("src.VoteAction", b =>
                {
                    b.HasOne("src.Question", null)
                        .WithMany("answers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("src.User", "agent")
                        .WithMany()
                        .HasForeignKey("agentId");

                    b.Navigation("agent");
                });

            modelBuilder.Entity("src.Movie", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("events");

                    b.Navigation("products");

                    b.Navigation("ratings");
                });

            modelBuilder.Entity("src.MovieList", b =>
                {
                    b.Navigation("items");
                });

            modelBuilder.Entity("src.Question", b =>
                {
                    b.Navigation("answers");
                });

            modelBuilder.Entity("src.User", b =>
                {
                    b.Navigation("accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
