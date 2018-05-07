using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITest.Models;
using ITest.Data.Models;
using ITest.Data.Models.Abstraction;

namespace ITest.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<UserTest> UserTest { get; set; }
        DbSet<AnswersToUserTest> AnswersToUserTest { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Test>()
                .HasOne(t => t.Category)
                .WithMany(c=>c.Tests)
                .HasForeignKey(t=>t.CategoryId);

            builder.Entity<User>()
                .HasMany(u => u.CreatedTests)
                .WithOne(ut => ut.Author);

            builder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a=>a.QuestionId);

            builder.Entity<Question>()
                .HasOne(q => q.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(q=>q.TestId);

            builder.Entity<Test>()
                .HasMany(x => x.UserTest)
                .WithOne(x => x.Test)
                .HasForeignKey(x => x.TestId);

            builder.Entity<UserTest>()
                .HasKey(x => x.Id);

            builder.Entity<User>()
                .HasMany(x => x.UserTest)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.Entity<UserTest>()
                .HasMany(x => x.AnswersToUserTests)
                .WithOne(x => x.UserTest)
                .HasForeignKey(x => x.UserTestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Answer>()
                .HasMany(x => x.AnswersToUserTests)
                .WithOne(x => x.Answer)
                .HasForeignKey(x => x.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override int SaveChanges()
        {
            this.ApplyEditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyEditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }   
    }
}
