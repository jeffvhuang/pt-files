﻿// <auto-generated />
using System;
using PTFiles.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PTFiles.Persistence.Migrations
{
    [DbContext(typeof(PTFilesDbContext))]
    [Migration("20200404004641_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PTFiles.Domain.Entities.ActiveTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ObjectiveAssessmentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveAssessmentId");

                    b.ToTable("ActiveTests");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.Casefile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Casefiles");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CasefileId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("ObjectiveId")
                        .HasColumnType("int");

                    b.Property<int>("PractitionerId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectiveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CasefileId");

                    b.HasIndex("PractitionerId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.ForwardPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ConsultationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("ForwardPlans");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.FunctionalTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ObjectiveAssessmentId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveAssessmentId");

                    b.ToTable("FunctionalTests");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.NeurologicalTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ObjectiveAssessmentId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveAssessmentId");

                    b.ToTable("NeurologicalTests");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.ObjectiveAssessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Additional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsultationId")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Palpation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId")
                        .IsUnique();

                    b.ToTable("ObjectiveAssessments");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.PassiveTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ObjectiveAssessmentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveAssessmentId");

                    b.ToTable("PassiveTests");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Honorific")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.Practitioner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Honorific")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("JobLevel")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("RegistrationID")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Practitioners");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.ResistedIsometricTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ObjectiveAssessmentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveAssessmentId");

                    b.ToTable("ResistedIsometricTests");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.SpecialTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ObjectiveAssessmentId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveAssessmentId");

                    b.ToTable("SpecialTests");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.SubjectiveAssessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AggravatingFactors")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BodyChart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsultationId")
                        .HasColumnType("int");

                    b.Property<string>("CurrentHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EasingFactors")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GeneralHealth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imaging")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MOI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PastHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VAS")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId")
                        .IsUnique();

                    b.ToTable("SubjectiveAssessments");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ConsultationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.ActiveTest", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.ObjectiveAssessment", "ObjectiveAssessment")
                        .WithMany("Active")
                        .HasForeignKey("ObjectiveAssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.Casefile", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.Patient", "Patient")
                        .WithMany("Casefiles")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.Consultation", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.Casefile", "Casefile")
                        .WithMany("Consultations")
                        .HasForeignKey("CasefileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PTFiles.Domain.Entities.Practitioner", "Practitioner")
                        .WithMany("Consultations")
                        .HasForeignKey("PractitionerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.ForwardPlan", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.Consultation", "Consultation")
                        .WithMany("Plans")
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.FunctionalTest", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.ObjectiveAssessment", "ObjectiveAssessment")
                        .WithMany("FunctionalTests")
                        .HasForeignKey("ObjectiveAssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.NeurologicalTest", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.ObjectiveAssessment", "ObjectiveAssessment")
                        .WithMany("NeurologicalTests")
                        .HasForeignKey("ObjectiveAssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.ObjectiveAssessment", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.Consultation", "Consultation")
                        .WithOne("ObjectiveAssessment")
                        .HasForeignKey("PTFiles.Domain.Entities.ObjectiveAssessment", "ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.PassiveTest", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.ObjectiveAssessment", "ObjectiveAssessment")
                        .WithMany("Passive")
                        .HasForeignKey("ObjectiveAssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.ResistedIsometricTest", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.ObjectiveAssessment", "ObjectiveAssessment")
                        .WithMany("ResistedIsometric")
                        .HasForeignKey("ObjectiveAssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.SpecialTest", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.ObjectiveAssessment", "ObjectiveAssessment")
                        .WithMany("SpecialTests")
                        .HasForeignKey("ObjectiveAssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.SubjectiveAssessment", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.Consultation", "Consultation")
                        .WithOne("SubjectiveAssessment")
                        .HasForeignKey("PTFiles.Domain.Entities.SubjectiveAssessment", "ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PTFiles.Domain.Entities.Treatment", b =>
                {
                    b.HasOne("PTFiles.Domain.Entities.Consultation", "Consultation")
                        .WithMany("Treatments")
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
