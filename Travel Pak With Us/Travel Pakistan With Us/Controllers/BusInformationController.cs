using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel_Pakistan_With_Us.Models;

namespace Travel_Pakistan_With_Us.Controllers
{
    public class BusInformationController : Controller
    {
        private TPWUSEntities db = new TPWUSEntities();

        // GET: BusInformation
        public ActionResult Index()
        {
            return View(db.BusInformation.ToList());
        }

        // GET: BusInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInformation busInformation = db.BusInformation.Find(id);
            if (busInformation == null)
            {
                return HttpNotFound();
            }
            return View(busInformation);
        }

        // GET: BusInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Route,TimeDuration,DepartingTime,TicketPrice")] BusInformation busInformation)
        {
            if (ModelState.IsValid)
            {
                db.BusInformation.Add(busInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busInformation);
        }

        // GET: BusInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInformation busInformation = db.BusInformation.Find(id);
            if (busInformation == null)
            {
                return HttpNotFound();
            }
            return View(busInformation);
        }

        // POST: BusInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Route,TimeDuration,DepartingTime,TicketPrice")] BusInformation busInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busInformation);
        }

        // GET: BusInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInformation busInformation = db.BusInformation.Find(id);
            if (busInformation == null)
            {
                return HttpNotFound();
            }
            return View(busInformation);
        }

        // POST: BusInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusInformation busInformation = db.BusInformation.Find(id);
            db.BusInformation.Remove(busInformation);
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
