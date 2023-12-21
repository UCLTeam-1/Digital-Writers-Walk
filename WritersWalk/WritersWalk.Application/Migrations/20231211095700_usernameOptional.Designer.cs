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
    [Migration("20231211095700_usernameOptional")]
    partial class usernameOptional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("WritersWalk.Application.Models.AppUser", b =>
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
                });

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
                            Description = "Skriv en tekst på 500 ord, hvor du udfordrer dig selv",
                            Title = "En udfordring"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Skriv en tekst på 500 ord, hvor du starter med at skrive: 'Det var en mørk og stormfuld nat...'",
                            Title = "En ny begyndelse"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Skriv en tekst på 500 ord, hvor du skriver om en vej eller en vildvej",
                            Title = "Veje og Vildveje"
                        });
                });

            modelBuilder.Entity("WritersWalk.Application.Models.AssignmentAppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("AssignmentAppUsers");
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
                            Title = "Hjem"
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

            modelBuilder.Entity("WritersWalk.Application.Models.WritersWalkTimer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId1");

                    b.ToTable("WritersWalkTimers");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.AssignmentAppUser", b =>
                {
                    b.HasOne("WritersWalk.Application.Models.AppUser", "AppUser")
                        .WithMany("AssignmentAppUsers")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WritersWalk.Application.Models.Assignment", "Assignment")
                        .WithMany("AssignmentAppUsers")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Assignment");
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

            modelBuilder.Entity("WritersWalk.Application.Models.WritersWalkTimer", b =>
                {
                    b.HasOne("WritersWalk.Application.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.AppUser", b =>
                {
                    b.Navigation("AssignmentAppUsers");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.Assignment", b =>
                {
                    b.Navigation("AssignmentAppUsers");

                    b.Navigation("AssignmentSurroundings");

                    b.Navigation("AssignmentTopics");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.Surrounding", b =>
                {
                    b.Navigation("AssignmentSurroundings");
                });

            modelBuilder.Entity("WritersWalk.Application.Models.Topic", b =>
                {
                    b.Navigation("AssignmentTopics");
                });
#pragma warning restore 612, 618
        }
    }
}