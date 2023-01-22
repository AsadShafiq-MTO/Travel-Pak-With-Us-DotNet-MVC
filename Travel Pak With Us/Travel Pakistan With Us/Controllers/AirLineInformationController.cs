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
    public class AirLineInformationController : Controller
    {
        private TPWUSEntities db = new TPWUSEntities();

        // GET: AirLineInformation
        public ActionResult Index()
        {
            return View(db.AirLineInformation.ToList());
        }

        // GET: AirLineInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirLineInformation airLineInformation = db.AirLineInformation.Find(id);
            if (airLineInformation == null)
            {
                return HttpNotFound();
            }
            return View(airLineInformation);
        }

        // GET: AirLineInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirLineInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Route,TimeDuration,DepartingTime,TicketPrice")] AirLineInformation airLineInformation)
        {
            if (ModelState.IsValid)
            {
                db.AirLineInformation.Add(airLineInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airLineInformation);
        }

        // GET: AirLineInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirLineInformation airLineInformation = db.AirLineInformation.Find(id);
            if (airLineInformation == null)
            {
                return HttpNotFound();
            }
            return View(airLineInformation);
        }

        // POST: AirLineInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Route,TimeDuration,DepartingTime,TicketPrice")] AirLineInformation airLineInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airLineInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airLineInformation);
        }

        // GET: AirLineInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirLineInformation airLineInformation = db.AirLineInformation.Find(id);
            if (airLineInformation == null)
            {
                return HttpNotFound();
            }
            return View(airLineInformation);
        }

        // POST: AirLineInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirLineInformation airLineInformation = db.AirLineInformation.Find(id);
            db.AirLineInformation.Remove(airLineInformation);
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
