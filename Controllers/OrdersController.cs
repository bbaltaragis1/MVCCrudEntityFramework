using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrudEntityFramework.Models;

namespace MVCCrudEntityFramework.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Orders.ToList());
            }
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Orders.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Orders.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Orders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Orders.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {
            try
               {
                using (DBModels db = new DBModels())
                {
                    order = db.Orders.Where(x => x.Id == id).FirstOrDefault();
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
