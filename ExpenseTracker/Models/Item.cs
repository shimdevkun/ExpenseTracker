using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}