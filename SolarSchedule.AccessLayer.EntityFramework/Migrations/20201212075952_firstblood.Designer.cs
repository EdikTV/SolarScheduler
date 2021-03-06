﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolarSchedule.AccessLayer.EntityFramework.DbContext;

namespace SolarSchedule.AccessLayer.EntityFramework.Migrations
{
    [DbContext(typeof(SchedulerDbContext))]
    [Migration("20201212075952_firstblood")]
    partial class firstblood
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SolarSchedule.AccessLayer.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskKey")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskKey");

                    b.ToTable("Taskses");
                });

            modelBuilder.Entity("SolarSchedule.AccessLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Userses");
                });

            modelBuilder.Entity("SolarSchedule.AccessLayer.Entities.Task", b =>
                {
                    b.HasOne("SolarSchedule.AccessLayer.Entities.User", "User")
                        .WithMany("Task")
                        .HasForeignKey("TaskKey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SolarSchedule.AccessLayer.Entities.User", b =>
                {
                    b.Navigation("Task");
                });
#pragma warning restore 612, 618
        }
    }
}
