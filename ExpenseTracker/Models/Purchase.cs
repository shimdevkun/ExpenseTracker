using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime Date { get; set; }

        public virtual Budget Budget { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}