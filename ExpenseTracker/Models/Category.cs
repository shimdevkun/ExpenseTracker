using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}