﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TtExam.DataAccess;

#nullable disable

namespace TtExam.DataAccess.Migrations
{
    [DbContext(typeof(TtExamContext))]
    [Migration("20230419124922_SentenceLenght")]
    partial class SentenceLenght
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TtExam.Domain.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer", (string)null);
                });

            modelBuilder.Entity("TtExam.Domain.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Exam", (string)null);
                });

            modelBuilder.Entity("TtExam.Domain.ExamSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("LessonId");

                    b.ToTable("ExamSection", (string)null);
                });

            modelBuilder.Entity("TtExam.Domain.ExamSectionQuestion", b =>
                {
                    b.Property<int>("ExamSectionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("ExamSectionId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("ExamSectionQuestion", (string)null);
                });

            modelBuilder.Entity("TtExam.Domain.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Lesson", (string)null);
                });

            modelBuilder.Entity("TtExam.Domain.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("Sentence")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Question", (string)null);
                });

            modelBuilder.Entity("TtExam.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityNumber")
                        .IsUnique();

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("TtExam.Domain.StudentExam", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<decimal>("Point")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("StudentId", "ExamId");

                    b.HasIndex("ExamId");

                    b.ToTable("StudentExam", (string)null);
                });

            modelBuilder.Entity("TtExam.Domain.Answer", b =>
                {
                    b.HasOne("TtExam.Domain.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TtExam.Domain.ExamSection", b =>
                {
                    b.HasOne("TtExam.Domain.Exam", "Exam")
                        .WithMany("ExamSections")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TtExam.Domain.Lesson", "Lesson")
                        .WithMany("ExamSections")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("TtExam.Domain.ExamSectionQuestion", b =>
                {
                    b.HasOne("TtExam.Domain.ExamSection", "ExamSection")
                        .WithMany("ExamSectionQuestions")
                        .HasForeignKey("ExamSectionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TtExam.Domain.Question", "Question")
                        .WithMany("ExamSectionQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ExamSection");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TtExam.Domain.Question", b =>
                {
                    b.HasOne("TtExam.Domain.Lesson", "Lesson")
                        .WithMany("Questions")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("TtExam.Domain.StudentExam", b =>
                {
                    b.HasOne("TtExam.Domain.Exam", "Exam")
                        .WithMany("StudentExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TtExam.Domain.Student", "Student")
                        .WithMany("StudentExams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TtExam.Domain.Exam", b =>
                {
                    b.Navigation("ExamSections");

                    b.Navigation("StudentExams");
                });

            modelBuilder.Entity("TtExam.Domain.ExamSection", b =>
                {
                    b.Navigation("ExamSectionQuestions");
                });

            modelBuilder.Entity("TtExam.Domain.Lesson", b =>
                {
                    b.Navigation("ExamSections");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("TtExam.Domain.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("ExamSectionQuestions");
                });

            modelBuilder.Entity("TtExam.Domain.Student", b =>
                {
                    b.Navigation("StudentExams");
                });
#pragma warning restore 612, 618
        }
    }
}
