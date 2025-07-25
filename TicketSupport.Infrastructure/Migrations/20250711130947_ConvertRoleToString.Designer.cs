﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicketSupport.Infrastructure.Data;

#nullable disable

namespace TicketSupport.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250711130947_ConvertRoleToString")]
    partial class ConvertRoleToString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TicketSupport.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketSupport.Domain.Entities.TicketReply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RepliedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ReplierId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ReplierId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketReplies");
                });

            modelBuilder.Entity("TicketSupport.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TicketSupport.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("TicketSupport.Domain.Entities.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketSupport.Domain.Entities.TicketReply", b =>
                {
                    b.HasOne("TicketSupport.Domain.Entities.User", "Replier")
                        .WithMany("Replies")
                        .HasForeignKey("ReplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketSupport.Domain.Entities.Ticket", "Ticket")
                        .WithMany("Replies")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Replier");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("TicketSupport.Domain.Entities.Ticket", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("TicketSupport.Domain.Entities.User", b =>
                {
                    b.Navigation("Replies");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
