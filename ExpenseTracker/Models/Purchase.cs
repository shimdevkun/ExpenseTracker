using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int BudgetId { get; set; }
        public int CategoryId { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }

        public virtual Budget Budget { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}