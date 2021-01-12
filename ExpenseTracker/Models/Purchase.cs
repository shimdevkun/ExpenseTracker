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

        [Required]
        public int BudgetId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Range(0.05, 1000, ErrorMessage = "Cost must be between 0.05$ to 1000$ inclusively")]
        public decimal Cost { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "The date must have the following format : MM/dd/yyyy")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:MM\/dd\/yyyy}")]
        public DateTime Date { get; set; }

        public virtual Budget Budget { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}