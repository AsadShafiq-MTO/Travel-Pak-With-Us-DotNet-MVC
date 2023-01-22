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
    public class AirlineBookingController : Controller
    {
        private TPWUSEntities db = new TPWUSEntities();

        // GET: AirlineBooking
        public ActionResult Index()
        {
            var airlineBooking = db.AirlineBooking.Include(a => a.AspNetUsers);
            return View(airlineBooking.ToList());
        }

        // GET: AirlineBooking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirlineBooking airlineBooking = db.AirlineBooking.Find(id);
            if (airlineBooking == null)
            {
                return HttpNotFound();
            }
            return View(airlineBooking);
        }

        // GET: AirlineBooking/Create
        public ActionResult Create()
        {
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: AirlineBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FlyingFrom,FlyingTo,CNIC,PhoneNumber,TimeSlot,Departing,Returing,SelectAirline,SelectTicket,User_id")] AirlineBooking airlineBooking)
        {
            if (ModelState.IsValid)
            {
                db.AirlineBooking.Add(airlineBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName", airlineBooking.User_id);
            return View(airlineBooking);
        }

        // GET: AirlineBooking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirlineBooking airlineBooking = db.AirlineBooking.Find(id);
            if (airlineBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName", airlineBooking.User_id);
            return View(airlineBooking);
        }

        // POST: AirlineBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FlyingFrom,FlyingTo,CNIC,PhoneNumber,TimeSlot,Departing,Returing,SelectAirline,SelectTicket,User_id")] AirlineBooking airlineBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airlineBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName", airlineBooking.User_id);
            return View(airlineBooking);
        }

        // GET: AirlineBooking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirlineBooking airlineBooking = db.AirlineBooking.Find(id);
            if (airlineBooking == null)
            {
                return HttpNotFound();
            }
            return View(airlineBooking);
        }

        // POST: AirlineBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirlineBooking airlineBooking = db.AirlineBooking.Find(id);
            db.AirlineBooking.Remove(airlineBooking);
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
