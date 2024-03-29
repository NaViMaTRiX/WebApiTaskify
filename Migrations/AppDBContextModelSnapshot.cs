﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApiTaskify.Data;

#nullable disable

namespace WebApiTaskify.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApiTaskify.Models.AuditLogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("EntityTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrgId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("WebApiTaskify.Models.Boards", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageFullUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageLinkHtml")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageThumbUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrgId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("WebApiTaskify.Models.Cards", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ListId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ListsId")
                        .HasColumnType("uuid");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isChecked")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ListsId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("WebApiTaskify.Models.Lists", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BoardsId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BoardsId");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("WebApiTaskify.Models.OrgLimits", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Limit")
                        .HasColumnType("integer");

                    b.Property<string>("OrgId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("OrgLimits");
                });

            modelBuilder.Entity("WebApiTaskify.Models.OrgSubscriptions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("OrgId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StripeCurrentPeriodEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StripeCustomerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StripePriseId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StripeSubscriptionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrgSubscriptions");
                });

            modelBuilder.Entity("WebApiTaskify.Models.Cards", b =>
                {
                    b.HasOne("WebApiTaskify.Models.Lists", null)
                        .WithMany("Cards")
                        .HasForeignKey("ListsId");
                });

            modelBuilder.Entity("WebApiTaskify.Models.Lists", b =>
                {
                    b.HasOne("WebApiTaskify.Models.Boards", null)
                        .WithMany("Lists")
                        .HasForeignKey("BoardsId");
                });

            modelBuilder.Entity("WebApiTaskify.Models.Boards", b =>
                {
                    b.Navigation("Lists");
                });

            modelBuilder.Entity("WebApiTaskify.Models.Lists", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
