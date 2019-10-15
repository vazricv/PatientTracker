﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatentTracker.Model;

namespace PatentTracker.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20190529032040_update05-28")]
    partial class update0528
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PatentTracker.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BOD");

                    b.Property<int>("CurrentStageID");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("PatentTracker.Model.PatientLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Completed");

                    b.Property<DateTime>("EnteredIn");

                    b.Property<int>("PatientID");

                    b.Property<int>("StageID");

                    b.HasKey("Id");

                    b.HasIndex("PatientID");

                    b.HasIndex("StageID");

                    b.ToTable("PatientLogs");
                });

            modelBuilder.Entity("PatentTracker.Model.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OrderNumber");

                    b.HasKey("Id");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("PatentTracker.Model.PatientLog", b =>
                {
                    b.HasOne("PatentTracker.Model.Patient", "ThePatient")
                        .WithMany("PatientLogs")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PatentTracker.Model.Stage", "TheStage")
                        .WithMany("PatientLogs")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
