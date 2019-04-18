﻿// <auto-generated />
using HandLab11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HandLab11.Migrations
{
    [DbContext(typeof(ProfessorDbContext))]
    [Migration("20190418165611_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("HandLab11.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("ProfessorId");

                    b.HasKey("CourseID");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("HandLab11.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("HandLab11.Models.Course", b =>
                {
                    b.HasOne("HandLab11.Models.Professor", "Professor")
                        .WithMany("Courses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
