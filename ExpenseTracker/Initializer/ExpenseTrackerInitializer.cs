using ExpenseTracker.Context;
using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Initializer
{
    public class ExpenseTrackerInitializer : DropCreateDatabaseAlways<ExpenseTrackerContext>
    {
        protected override void Seed(ExpenseTrackerContext context)
        {
            base.Seed(context);
            context.Categories.AddRange(new List<Category>()
            {
                new Category { CategoryId = 1, CategoryName = "Groceries" },
                new Category { CategoryId = 2, CategoryName = "Pharmacy" },
                new Category { CategoryId = 3, CategoryName = "College" },
                new Category { CategoryId = 4, CategoryName = "Other" },
            });

            context.Budgets.Add(
                new Budget {
                    BudgetId = 1,
                    Amount = 200,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14)
                });

            context.Items.AddRange(new List<Item>()
            {
                new Item { ItemId = 1, ItemName = "Zoloft", CategoryId = 2 },
                new Item { ItemId = 2, ItemName = "Gatorade", CategoryId = 1 },
                new Item { ItemId = 3, ItemName = "College fees", CategoryId = 3 },
                new Item { ItemId = 4, ItemName = "Almond milk", CategoryId = 1 },
                new Item { ItemId = 5, ItemName = "Other(s)", CategoryId = 4 },
            });
            context.SaveChanges();
        }
    }
}