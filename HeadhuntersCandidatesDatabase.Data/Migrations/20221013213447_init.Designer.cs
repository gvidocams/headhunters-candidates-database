﻿// <auto-generated />
using System;
using HeadhuntersCandidatesDatabase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HeadhuntersCandidatesDatabase.Data.Migrations
{
    [DbContext(typeof(HeadhuntersCandidatesDbContext))]
    [Migration("20221013213447_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("CandidatePosition", b =>
                {
                    b.Property<int>("CandidatesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionsAppliedToId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CandidatesId", "PositionsAppliedToId");

                    b.HasIndex("PositionsAppliedToId");

                    b.ToTable("CandidatePosition");
                });

            modelBuilder.Entity("HeadhuntersCandidatesDatabase.Core.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("HeadhuntersCandidatesDatabase.Core.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HeadhuntersCandidatesDatabase.Core.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OpenedPositions")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("CandidatePosition", b =>
                {
                    b.HasOne("HeadhuntersCandidatesDatabase.Core.Models.Candidate", null)
                        .WithMany()
                        .HasForeignKey("CandidatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeadhuntersCandidatesDatabase.Core.Models.Position", null)
                        .WithMany()
                        .HasForeignKey("PositionsAppliedToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HeadhuntersCandidatesDatabase.Core.Models.Position", b =>
                {
                    b.HasOne("HeadhuntersCandidatesDatabase.Core.Models.Company", null)
                        .WithMany("Positions")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("HeadhuntersCandidatesDatabase.Core.Models.Company", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}