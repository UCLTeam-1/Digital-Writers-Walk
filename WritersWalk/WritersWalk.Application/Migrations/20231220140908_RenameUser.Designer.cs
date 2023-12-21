﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WritersWalk.Application.Database;

#nullable disable

namespace WritersWalk.Application.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20231220140908_RenameUser")]
    partial class RenameUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("WritersWalk.Application.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Hvis du var et træ, hvordan så du så ud? Beskriv dig selv og dine omgivelser. Hvor står du? Hvilken slags træ er du? Hvad er dine kendetegn? Se på træerne omkring dig for at finde inspiration. Brug dine sanser.",
                            Title = "Et træ"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Tænk på en skillevej, du har mødt, hvor du valgte at gå én vej frem for en anden. Er det længe siden? Hvad skete der? Fulgte du den vej, andre allerede havde betrådt mange gange eller den mere ’vilde’ vej? Skriv hvad du kommer til at tænke på.",
                            Title = "Veje og vildveje"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Hvornår har du stået overfor en udfordring, som du er kommet igennem? Skriv om den: hvad skete der? Hvad gjorde du?",
                            Title = "En udfordring"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Hver ny dag bringer noget nyt – eller gør den? Hvornår er du sidst begyndt forfra? Er det nemt eller svært at starte på noget nyt? Hvad får udtrykket ”en ny begyndelse” dig til at tænke på?",
                            Title = "En ny begyndelse"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Skriv som var stilheden en person, der har gået sammen med os på vores vandring. Nu har den forladt os – hvad efterlod den hos dig og hvor gik den hen?",
                            Title = "Skriv et brev til stilheden – start med ’Kære Stilhed’"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Skriv om en ildsjæl du kender. En, der brænder for noget og sætter alt ind for at arbejde med det, vedkommende tror på eller elsker at lave. Kan du genkende noget hos dig selv i vedkommende?",
                            Title = "Ildsjæl"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Beskriv det sted du er lige nu og den tur, du har gået herhen. Fortæl om noget ved denne tid på året, der gør dig glad.",
                            Title = "Efterår i skoven"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Skriv om det, der er på den anden side af havet. Det, du ikke kan se, men forestiller dig – eller drømmer om. ",
                            Title = "Hvad ser du i horisonten"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Skriv i din dagbog, hvad du har oplevet på en dag alene i naturen.  Hvordan ville du klare dig, hvis du skulle være her alene i tre dage? Ville det være en glæde eller en udfordring?",
                            Title = "Naturen – Et dagbogsnotat"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Tænk på en sommerdag, da du var barn. Hvad er det første du kommer til at tænke på? Skriv om det. Hvem er med i dit minde? Beskriv vedkommende, hvis der er nogen, og hvis det kun er dig, så beskriv også, hvordan du selv ser ud.",
                            Title = "Sommerminder"
                        });
                });

            modelBuilder.Entity("WritersWalk.Application.Models.AssignmentSurrounding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SurroundingsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("SurroundingsId");

                    b.ToTable("AssignmentSurroundings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignmentId = 1,
                            SurroundingsId = 1
                        },
                        new
                        {
                            Id = 2,
                            AssignmentId = 2,
                            SurroundingsId = 1
                        },
                        new
                        {
                            Id = 3,
                            AssignmentId = 3,
                            SurroundingsId = 1
                        },
                        new
                        {
                            Id = 4,
                            AssignmentId = 4,
                            SurroundingsId = 1
                        },
                        new
                        {
                            Id = 5,
                            AssignmentId = 5,
                            SurroundingsId = 2
                        },
                        new
                        {
                            Id = 6,
                            AssignmentId = 6,
                            SurroundingsId = 2
                        },
                        new
                        {
                            Id = 7,
                            AssignmentId = 7,
                            SurroundingsId = 2
                        },
                        new
                        {
                            Id = 8,
                            AssignmentId = 8,
                            SurroundingsId = 2
                        },
                        new
                        {
                            Id = 9,
                            AssignmentId = 9,
                            SurroundingsId = 3
                        },
                        new
                        {
                            Id = 10,
                            AssignmentId = 10,
                            SurroundingsId = 3
                        },
                        new
                        {
                            Id = 11,
                            AssignmentId = 1,
                            SurroundingsId = 4
                        },
                        new
                        {
                            Id = 12,
                            AssignmentId = 2,
                            SurroundingsId = 4
                        },
                        new
                        {
                            Id = 13,
                            AssignmentId = 3,
                            SurroundingsId = 4
                        },
                        new
                        {
                            Id = 14,
                            AssignmentId = 4,
                            SurroundingsId = 4
                        },
                        new
                        {
                            Id = 15,
                            AssignmentId = 5,
                            SurroundingsId = 5
                        },
                        new
                        {
                            Id = 16,
                            AssignmentId = 6,
                            SurroundingsId = 5
                        },
                        new
                        {
                            Id = 17,
                            AssignmentId = 7,
                            SurroundingsId = 5
                        },
                        new
                        {
                            Id = 18,
                            AssignmentId = 8,
                            SurroundingsId = 5
                        },
                        new
                        {
                            Id = 19,
                            AssignmentId = 9,
                            SurroundingsId = 6
                        },
                        new
                        {
                            Id = 20,
                            AssignmentId = 10,
                            SurroundingsId = 6
                        },
                        new
                        {
                            Id = 21,
                            AssignmentId = 1,
                            SurroundingsId = 7
                        },
                        new
                        {
                            Id = 22,
                            AssignmentId = 2,
                            SurroundingsId = 7
                        },
                        new
                        {
                            Id = 23,
                            AssignmentId = 3,
                            SurroundingsId = 7
                        },
                        new
                        {
                            Id = 24,
                            AssignmentId = 4,
                            SurroundingsId = 7
                        });
                });

            modelBuilder.Entity("WritersWalk.Application.Models.AssignmentTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TopicId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("TopicId");

                    b.ToTable("AssignmentTopics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignmentId = 1,
                            TopicId = 1
                        },
                        new
                        {
                            Id = 2,
                            AssignmentId = 2,
                            TopicId = 1
                        },
                        new
                        {
                            Id = 3,
                            AssignmentId = 3,
                            TopicId = 1
                        },
                        new
                        {
                            Id = 4,
                            AssignmentId = 4,
                            TopicId = 2
                        },
                        new
                        {
                            Id = 5,
                            AssignmentId = 5,
                            TopicId = 2
                        },
                        new
                        {
                            Id = 6,
                            AssignmentId = 6,
                            TopicId = 2
                        },
                        new
                        {
                            Id = 7,
                            AssignmentId = 7,
                            TopicId = 3
                        },
                        new
                        {
                            Id = 8,
                            AssignmentId = 8,
                            TopicId = 3
                        },
                        new
                        {
                            Id = 9,
                            AssignmentId = 9,
                            TopicId = 3
                        },
                        new
                        {
                            Id = 10,
                            AssignmentId = 10,
                            TopicId = 3
                        });
                });

            modelBuilder.Entity("WritersWalk.Application.Models.AssignmentUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("UserId");

                    b.ToTable("AssignmentUsers");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.Surrounding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Surroundings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Bakke"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Mark"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Skov"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Strand"
                        },
                        new
                        {
                            Id = 5,
                            Title = "By"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Vand"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Åbent land"
                        });
                });

            modelBuilder.Entity("WritersWalk.Application.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Skriv dig til klarhed"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Styrk din skrivning"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Skriv din livshistorie"
                        });
                });

            modelBuilder.Entity("WritersWalk.Application.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Email = "admin",
                            FirstName = "",
                            LastName = "",
                            Password = "admin"
                        },
                        new
                        {
                            Id = "2",
                            Email = "user",
                            FirstName = "",
                            LastName = "",
                            Password = "user"
                        });
                });

            modelBuilder.Entity("WritersWalk.Application.Models.AssignmentSurrounding", b =>
                {
                    b.HasOne("WritersWalk.Application.Models.Assignment", "Assignment")
                        .WithMany("AssignmentSurroundings")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WritersWalk.Application.Models.Surrounding", "Surroundings")
                        .WithMany("AssignmentSurroundings")
                        .HasForeignKey("SurroundingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Surroundings");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.AssignmentTopic", b =>
                {
                    b.HasOne("WritersWalk.Application.Models.Assignment", "Assignment")
                        .WithMany("AssignmentTopics")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WritersWalk.Application.Models.Topic", "Topic")
                        .WithMany("AssignmentTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.AssignmentUser", b =>
                {
                    b.HasOne("WritersWalk.Application.Models.Assignment", "Assignment")
                        .WithMany("AssignmentUsers")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WritersWalk.Application.Models.User", "User")
                        .WithMany("AssignmentUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.Assignment", b =>
                {
                    b.Navigation("AssignmentSurroundings");

                    b.Navigation("AssignmentTopics");

                    b.Navigation("AssignmentUsers");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.Surrounding", b =>
                {
                    b.Navigation("AssignmentSurroundings");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.Topic", b =>
                {
                    b.Navigation("AssignmentTopics");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.User", b =>
                {
                    b.Navigation("AssignmentUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
