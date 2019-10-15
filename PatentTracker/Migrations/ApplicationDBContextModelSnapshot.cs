﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatentTracker.Model;

namespace PatentTracker.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<TimeSpan>("DueTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OrderNumber");

                    b.HasKey("Id");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("PatentTracker.Model.PatientLog", b =>
                {
                    b.HasOne("PatentTracker.Model.Patient", "Patient")
                        .WithMany("PatientLogs")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PatentTracker.Model.Stage", "Stage")
                        .WithMany("PatientLogs")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
