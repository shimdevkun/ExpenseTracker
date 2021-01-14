using ExpenseTracker.Context;
using ExpenseTracker.Models;
using ExpenseTracker.ViewModels;
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
        public ActionResult Index()
        {
            var purchases = db.Purchases.OrderByDescending(p => p.Date).ToList();
            return View(purchases);
        }
       
        public ActionResult Create()
        {
            DateTime date = DateTime.Now;
            var budget = db.Budgets.FirstOrDefault(b => date >= b.StartDate && date <= b.EndDate);

            if (budget == null)
                throw new ArgumentNullException();

            var purchase = new Purchase();
            purchase.BudgetId = budget.BudgetId;
            purchase.Date = date;

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.ItemId = new MultiSelectList(db.Items, "ItemId", "ItemName");

            return View(purchase);
        }

        [HttpPost]
        public ActionResult Create(Purchase purchase, List<int> itemId)
        {
            if (itemId == null || itemId.Count == 0)
                ModelState.AddModelError("Items", "The purchase must have a minimum of one item");

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.ItemId = new MultiSelectList(db.Items, "ItemId", "ItemName");
                return View(purchase);
            }


            purchase.Items = db.Items.Where(i => itemId.Contains(i.ItemId)).ToList();
            db.Purchases.Add(purchase);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var purchase = db.Purchases.Find(id);
            if (purchase == null)
                throw new ArgumentNullException();

            var vm = new PurchaseDetailsVM();
            vm.Budget = purchase.Budget;
            vm.Items = purchase.Items;

            return PartialView("_Details", vm);
        }
    }
}