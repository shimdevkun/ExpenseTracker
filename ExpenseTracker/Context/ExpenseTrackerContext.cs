using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Context
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext() : base("ExpenseTrackerConnection")
        {

        }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Purchase>()
                .HasMany(p => p.Items)
                .WithMany(i => i.Purchases)
                .Map(pi =>
                {
                    pi.MapLeftKey("PurchaseId");
                    pi.MapRightKey("ItemId");
                    pi.ToTable("PurchaseItem");
                });
        }
    }
}