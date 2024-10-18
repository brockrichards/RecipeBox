using System;
using System.Linq;
using System.Threading.Tasks;
using Cortside.AspNetCore.Auditable;
using Cortside.AspNetCore.Auditable.Entities;
using Cortside.AspNetCore.EntityFramework;
using Cortside.Common.Security;
using Cortside.DomainEvent.EntityFramework;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Domain.Entities;
using RecipeBox.Enumerations;

namespace RecipeBox.Data {
    public class DatabaseContext : UnitOfWorkContext<Subject>, IDatabaseContext {
        public DatabaseContext(DbContextOptions options, ISubjectPrincipal subjectPrincipal, ISubjectFactory<Subject> subjectFactory) : base(options, subjectPrincipal, subjectFactory) {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.AddDomainEventOutbox();
            modelBuilder
                .Entity<Tag>()
                .Property(e => e.Category)
                .HasConversion(
                    v => v.ToString(),
                    v => (CategoryType)Enum.Parse(typeof(CategoryType), v));

            SetDateTime(modelBuilder);
            SetCascadeDelete(modelBuilder);
        }

        /// <summary>
        /// Hook to add additional logic before entities are actually saved.  Shown here for example, only override if there is actual need.
        /// </summary>
        /// <param name="updatingSubject"></param>
        /// <returns></returns>
        protected override Task OnBeforeSaveChangesAsync(Subject updatingSubject) {
            return Console.Out.WriteLineAsync($"Change tracker has {ChangeTracker.Entries().Count()} entries");
        }
    }
}

