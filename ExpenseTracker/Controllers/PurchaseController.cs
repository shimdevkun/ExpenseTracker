using ExpenseTracker.Context;
using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker.Controllers
{
    public class PurchaseController : Controller
    {
        private ExpenseTrackerContext db = new ExpenseTrackerContext();

        // GET: Purchase
        public ActionResult Create()
        {
            DateTime date = DateTime.Now;
            var budget = db.Budgets.FirstOrDefault(b => date >= b.StartDate && date <= b.EndDate);

            if (budget == null)
                throw new ArgumentNullException();

            var purchase = new Purchase();
            purchase.BudgetId = budget.BudgetId;
            purchase.Date = date;

            ViewBag.CategoryId = new SelectList(db.Categories.Select(c => c.CategoryName));
            return View(purchase);
        }
    }
}