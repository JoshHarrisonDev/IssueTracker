﻿// <auto-generated />
using System;
using IssueTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IssueTracker.Data.Migrations
{
    [DbContext(typeof(IssueTrackerContext))]
    [Migration("20220520115438_Added Enum For status and priority in Issue Domain Model added num values")]
    partial class AddedEnumForstatusandpriorityinIssueDomainModeladdednumvalues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IssueTracker.Data.Domain.Issue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("ActualResolutionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AssignedToID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedByID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdentifiedByID")
                        .HasColumnType("int");

                    b.Property<DateTime>("IdentifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedByID")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Progress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<string>("ResolutionSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TargetResolutionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AssignedToID");

                    b.HasIndex("CreatedByID");

                    b.HasIndex("IdentifiedByID");

                    b.HasIndex("ModifiedByID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("IssueTracker.Data.Domain.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("IssueTracker.Data.Domain.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("ActualEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiedByPerson")
                        .HasColumnType("int");

                    b.Property<int>("ProjectLead")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TargetEndDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("IssueTracker.Data.Domain.Issue", b =>
                {
                    b.HasOne("IssueTracker.Data.Domain.Person", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToID");

                    b.HasOne("IssueTracker.Data.Domain.Person", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByID");

                    b.HasOne("IssueTracker.Data.Domain.Person", "IdentifiedBy")
                        .WithMany()
                        .HasForeignKey("IdentifiedByID");

                    b.HasOne("IssueTracker.Data.Domain.Person", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedByID");

                    b.HasOne("IssueTracker.Data.Domain.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedTo");

                    b.Navigation("CreatedBy");

                    b.Navigation("IdentifiedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("IssueTracker.Data.Domain.Person", b =>
                {
                    b.HasOne("IssueTracker.Data.Domain.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });
#pragma warning restore 612, 618
        }
    }
}