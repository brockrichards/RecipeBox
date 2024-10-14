﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeBox.Data;

#nullable disable

namespace RecipeBox.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241014185608_FixAuditableEntities")]
    partial class FixAuditableEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cortside.AspNetCore.Auditable.Entities.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Subject primary key");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was created");

                    b.Property<string>("FamilyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Subject Surname ()");

                    b.Property<string>("GivenName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Subject primary key");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Subject primary key");

                    b.Property<string>("UserPrincipalName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Username (upn claim)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subject", "dbo", t =>
                        {
                            t.HasTrigger("trSubject");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("Cortside.DomainEvent.EntityFramework.Outbox", b =>
                {
                    b.Property<int>("OutboxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OutboxId"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrelationId")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LockId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("MessageId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("PublishCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoutingKey")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ScheduledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OutboxId");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.HasIndex("ScheduledDate", "Status")
                        .HasDatabaseName("IX_ScheduleDate_Status");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("ScheduledDate", "Status"), new[] { "EventType" });

                    b.HasIndex("Status", "LockId", "ScheduledDate")
                        .HasDatabaseName("IX_Status_LockId_ScheduleDate");

                    b.ToTable("Outbox", "dbo", t =>
                        {
                            t.HasTrigger("trOutbox");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was created");

                    b.Property<Guid>("CreatedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Description of the ingredient");

                    b.Property<Guid>("IngredientResourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Public unique identifier");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was last modified");

                    b.Property<Guid>("LastModifiedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Name of the ingredient");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int")
                        .HasComment("FK to Recipe that the Ingredient belongs to");

                    b.HasKey("IngredientId");

                    b.HasIndex("CreatedSubjectId");

                    b.HasIndex("LastModifiedSubjectId");

                    b.ToTable("Ingredient", "dbo", t =>
                        {
                            t.HasComment("Ingredients that belong to an Recipe");

                            t.HasTrigger("trIngredient");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was created");

                    b.Property<Guid>("CreatedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was last modified");

                    b.Property<Guid>("LastModifiedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeResourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Public unique identifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipeId");

                    b.HasIndex("CreatedSubjectId");

                    b.HasIndex("LastModifiedSubjectId");

                    b.HasIndex("RecipeResourceId")
                        .IsUnique();

                    b.ToTable("Recipe", "dbo", t =>
                        {
                            t.HasComment("Recipes");

                            t.HasTrigger("trRecipe");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.RecipeIngredient", b =>
                {
                    b.Property<int>("RecipeIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeIngredientId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was created");

                    b.Property<Guid>("CreatedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was last modified");

                    b.Property<Guid>("LastModifiedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<Guid>("RecipeIngredientResourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Public unique identifier");

                    b.HasKey("RecipeIngredientId");

                    b.HasIndex("CreatedSubjectId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("LastModifiedSubjectId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredient", "dbo", t =>
                        {
                            t.HasTrigger("trRecipeIngredient");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.RecipeTag", b =>
                {
                    b.Property<int>("RecipeTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeTagId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was created");

                    b.Property<Guid>("CreatedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was last modified");

                    b.Property<Guid>("LastModifiedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<Guid>("RecipeTagResourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Public unique identifier");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.HasKey("RecipeTagId");

                    b.HasIndex("CreatedSubjectId");

                    b.HasIndex("LastModifiedSubjectId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("TagId");

                    b.ToTable("RecipeTag", "dbo", t =>
                        {
                            t.HasTrigger("trRecipeTag");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was created");

                    b.Property<Guid>("CreatedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time entity was last modified");

                    b.Property<Guid>("LastModifiedSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Tag name");

                    b.Property<Guid>("TagResourceId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Public unique identifier");

                    b.HasKey("TagId");

                    b.HasIndex("CreatedSubjectId");

                    b.HasIndex("LastModifiedSubjectId");

                    b.ToTable("Tags", "dbo", t =>
                        {
                            t.HasTrigger("trTags");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedSubjectSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifiedSubjectSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedSubjectSubjectId");

                    b.HasIndex("LastModifiedSubjectSubjectId");

                    b.ToTable("User", "dbo", t =>
                        {
                            t.HasTrigger("trUser");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.Ingredient", b =>
                {
                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "CreatedSubject")
                        .WithMany()
                        .HasForeignKey("CreatedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "LastModifiedSubject")
                        .WithMany()
                        .HasForeignKey("LastModifiedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedSubject");

                    b.Navigation("LastModifiedSubject");
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "CreatedSubject")
                        .WithMany()
                        .HasForeignKey("CreatedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "LastModifiedSubject")
                        .WithMany()
                        .HasForeignKey("LastModifiedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedSubject");

                    b.Navigation("LastModifiedSubject");
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "CreatedSubject")
                        .WithMany()
                        .HasForeignKey("CreatedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecipeBox.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "LastModifiedSubject")
                        .WithMany()
                        .HasForeignKey("LastModifiedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecipeBox.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedSubject");

                    b.Navigation("Ingredient");

                    b.Navigation("LastModifiedSubject");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.RecipeTag", b =>
                {
                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "CreatedSubject")
                        .WithMany()
                        .HasForeignKey("CreatedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "LastModifiedSubject")
                        .WithMany()
                        .HasForeignKey("LastModifiedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecipeBox.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeTags")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RecipeBox.Domain.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedSubject");

                    b.Navigation("LastModifiedSubject");

                    b.Navigation("Recipe");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.Tag", b =>
                {
                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "CreatedSubject")
                        .WithMany()
                        .HasForeignKey("CreatedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "LastModifiedSubject")
                        .WithMany()
                        .HasForeignKey("LastModifiedSubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedSubject");

                    b.Navigation("LastModifiedSubject");
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.User", b =>
                {
                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "CreatedSubject")
                        .WithMany()
                        .HasForeignKey("CreatedSubjectSubjectId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Cortside.AspNetCore.Auditable.Entities.Subject", "LastModifiedSubject")
                        .WithMany()
                        .HasForeignKey("LastModifiedSubjectSubjectId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreatedSubject");

                    b.Navigation("LastModifiedSubject");
                });

            modelBuilder.Entity("RecipeBox.Domain.Entities.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");

                    b.Navigation("RecipeTags");
                });
#pragma warning restore 612, 618
        }
    }
}
