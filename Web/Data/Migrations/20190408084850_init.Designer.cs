﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Data;

namespace Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190408084850_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.BallotIssue", b =>
                {
                    b.Property<int>("BallotIssueId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BallotIssueTitle");

                    b.Property<string>("Description");

                    b.Property<int>("ElectionId");

                    b.HasKey("BallotIssueId");

                    b.HasIndex("ElectionId");

                    b.ToTable("BallotIssues");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Candidate", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography");

                    b.Property<int>("ElectionId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("OrganizationId");

                    b.Property<string>("Picture");

                    b.HasKey("CandidateId");

                    b.HasIndex("ElectionId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.CandidateRace", b =>
                {
                    b.Property<int>("CandidateRaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CandidateId");

                    b.Property<string>("PlatformInfo");

                    b.Property<string>("PositionName");

                    b.Property<int?>("RaceId");

                    b.Property<string>("TopIssues");

                    b.HasKey("CandidateRaceId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("RaceId");

                    b.ToTable("CandidateRaces");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CandidateId");

                    b.Property<string>("ContactMethod");

                    b.Property<string>("ContactValue");

                    b.HasKey("ContactId");

                    b.HasIndex("CandidateId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Election", b =>
                {
                    b.Property<int>("ElectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DateEnd");

                    b.Property<string>("DateStart");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ElectionId");

                    b.ToTable("Elections");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.IssueOption", b =>
                {
                    b.Property<int>("IssueOptionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BallotIssueId");

                    b.Property<string>("IssueOptionInfo");

                    b.Property<string>("IssueOptionTitle");

                    b.HasKey("IssueOptionId");

                    b.HasIndex("BallotIssueId");

                    b.ToTable("IssueOptions");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.PollingStation", b =>
                {
                    b.Property<int>("PollingStationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfo");

                    b.Property<string>("Address");

                    b.Property<int>("ElectionId");

                    b.Property<string>("GeneralAccessInfo");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitute");

                    b.Property<string>("Name");

                    b.Property<string>("ParkingInfo");

                    b.Property<string>("WashroomInfo");

                    b.Property<string>("WheelchairInfo");

                    b.HasKey("PollingStationId");

                    b.HasIndex("ElectionId");

                    b.ToTable("PollingStations");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ElectionId");

                    b.Property<int>("NumberNeeded");

                    b.Property<string>("PositionName");

                    b.HasKey("RaceId");

                    b.HasIndex("ElectionId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ElectionId");

                    b.Property<int>("currentElection");

                    b.HasKey("StateId");

                    b.HasIndex("ElectionId");

                    b.ToTable("StateSingleton");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Theme.Image", b =>
                {
                    b.Property<string>("ThemeName");

                    b.Property<string>("ID");

                    b.Property<string>("Description");

                    b.Property<string>("Format");

                    b.Property<string>("Type");

                    b.Property<string>("Value");

                    b.HasKey("ThemeName", "ID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Theme.Theme", b =>
                {
                    b.Property<string>("ThemeName")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Selected");

                    b.HasKey("ThemeName");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VotingModelLibrary.Models.BallotIssue", b =>
                {
                    b.HasOne("VotingModelLibrary.Models.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Candidate", b =>
                {
                    b.HasOne("VotingModelLibrary.Models.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VotingModelLibrary.Models.Organization", "Organization")
                        .WithMany("Candidates")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VotingModelLibrary.Models.CandidateRace", b =>
                {
                    b.HasOne("VotingModelLibrary.Models.Candidate", "Candidate")
                        .WithMany("CandidateRaces")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VotingModelLibrary.Models.Race", "Race")
                        .WithMany("CandidateRaces")
                        .HasForeignKey("RaceId");
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Contact", b =>
                {
                    b.HasOne("VotingModelLibrary.Models.Candidate", "Candidate")
                        .WithMany("Contacts")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VotingModelLibrary.Models.IssueOption", b =>
                {
                    b.HasOne("VotingModelLibrary.Models.BallotIssue")
                        .WithMany("BallotIssueOptions")
                        .HasForeignKey("BallotIssueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VotingModelLibrary.Models.PollingStation", b =>
                {
                    b.HasOne("VotingModelLibrary.Models.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VotingModelLibrary.Models.Race", b =>
                {
                    b.HasOne("VotingModelLibrary.Models.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VotingModelLibrary.Models.State", b =>
                {
                    b.HasOne("VotingModelLibrary.Models.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId");
                });
#pragma warning restore 612, 618
        }
    }
}
