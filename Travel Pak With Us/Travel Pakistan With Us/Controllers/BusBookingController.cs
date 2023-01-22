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
    
    public class BusBookingController : Controller
    {
        private TPWUSEntities db = new TPWUSEntities();

        // GET: BusBooking
        public ActionResult Index()
        {
            var busBooking = db.BusBooking.Include(b => b.AspNetUsers);
            return View(busBooking.ToList());
        }

        // GET: BusBooking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusBooking busBooking = db.BusBooking.Find(id);
            if (busBooking == null)
            {
                return HttpNotFound();
            }
            return View(busBooking);
        }

        // GET: BusBooking/Create
        public ActionResult Create()
        {
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: BusBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ArivalFrom,ArivalTo,CNIC,PhoneNumber,TimeSlot,Departing,Returing,SelectBus,SelectTicket,User_id")] BusBooking busBooking)
        {
           
            if (ModelState.IsValid)
            {
                DateTime dateTime = DateTime.Now;
                db.BusBooking.Add(busBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName", busBooking.User_id);
            return View(busBooking);
        }

        // GET: BusBooking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusBooking busBooking = db.BusBooking.Find(id);
            if (busBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName", busBooking.User_id);
            return View(busBooking);
        }

        // POST: BusBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ArivalFrom,ArivalTo,CNIC,PhoneNumber,TimeSlot,Departing,Returing,SelectBus,SelectTicket,User_id")] BusBooking busBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName", busBooking.User_id);
            return View(busBooking);
        }

        // GET: BusBooking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusBooking busBooking = db.BusBooking.Find(id);
            if (busBooking == null)
            {
                return HttpNotFound();
            }
            return View(busBooking);
        }

        // POST: BusBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusBooking busBooking = db.BusBooking.Find(id);
            db.BusBooking.Remove(busBooking);
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
