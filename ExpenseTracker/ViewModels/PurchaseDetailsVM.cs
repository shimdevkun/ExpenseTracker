using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.ViewModels
{
    public class PurchaseDetailsVM
    {
        public Budget Budget { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}