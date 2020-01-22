using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eventor2.Models;

namespace Eventor2.Controllers
{
    public class TicketModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TicketModels
        public ActionResult Index()
        {
            return View(db.TicketModels.ToList());
        }

        // GET: TicketModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModels ticketModels = db.TicketModels.Find(id);
            if (ticketModels == null)
            {
                return HttpNotFound();
            }
            return View(ticketModels);
        }

        // GET: TicketModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,Type,Price")] TicketModels ticketModels)
        {
            if (ModelState.IsValid)
            {
                db.TicketModels.Add(ticketModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticketModels);
        }

        // GET: TicketModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModels ticketModels = db.TicketModels.Find(id);
            if (ticketModels == null)
            {
                return HttpNotFound();
            }
            return View(ticketModels);
        }

        // POST: TicketModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,Type,Price")] TicketModels ticketModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketModels);
        }

        // GET: TicketModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketModels ticketModels = db.TicketModels.Find(id);
            if (ticketModels == null)
            {
                return HttpNotFound();
            }
            return View(ticketModels);
        }

        // POST: TicketModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketModels ticketModels = db.TicketModels.Find(id);
            db.TicketModels.Remove(ticketModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
