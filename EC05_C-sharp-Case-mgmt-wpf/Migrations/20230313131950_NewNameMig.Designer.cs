﻿// <auto-generated />
using System;
using EC05_C_sharp_Case_mgmt_wpf.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EC05_C_sharp_Case_mgmt_wpf.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230313131950_NewNameMig")]
    partial class NewNameMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities.CaseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentEntityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.ToTable("CasesSql");
                });

            modelBuilder.Entity("EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities.CommentEntity", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("CaseEntityId")
                        .HasColumnType("int");

                    b.Property<string>("CommentAuthor")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime>("CommentCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("CaseEntityId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities.CommentEntity", b =>
                {
                    b.HasOne("EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities.CaseEntity", "CaseEntity")
                        .WithMany("CommentEntity")
                        .HasForeignKey("CaseEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseEntity");
                });

            modelBuilder.Entity("EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities.CaseEntity", b =>
                {
                    b.Navigation("CommentEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
