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
    public class TrainBookingController : Controller
    {
        private TPWUSEntities db = new TPWUSEntities();

        // GET: TrainBooking
        public ActionResult Index()
        {
            var trainBooking = db.TrainBooking.Include(t => t.AspNetUsers);
            return View(trainBooking.ToList());
        }

        // GET: TrainBooking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainBooking trainBooking = db.TrainBooking.Find(id);
            if (trainBooking == null)
            {
                return HttpNotFound();
            }
            return View(trainBooking);
        }

        // GET: TrainBooking/Create
        public ActionResult Create()
        {
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: TrainBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ArivalFrom,ArivalTo,CNIC,PhoneNumber,TimeSlot,Departing,Returing,SelectTrain,SelectTicket,User_id")] TrainBooking trainBooking)
        {
            if (ModelState.IsValid)
            {
                db.TrainBooking.Add(trainBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName", trainBooking.User_id);
            return View(trainBooking);
        }

        // GET: TrainBooking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainBooking trainBooking = db.TrainBooking.Find(id);
            if (trainBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName", trainBooking.User_id);
            return View(trainBooking);
        }

        // POST: TrainBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ArivalFrom,ArivalTo,CNIC,PhoneNumber,TimeSlot,Departing,Returing,SelectTrain,SelectTicket,User_id")] TrainBooking trainBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "UserName", trainBooking.User_id);
            return View(trainBooking);
        }

        // GET: TrainBooking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainBooking trainBooking = db.TrainBooking.Find(id);
            if (trainBooking == null)
            {
                return HttpNotFound();
            }
            return View(trainBooking);
        }

        // POST: TrainBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainBooking trainBooking = db.TrainBooking.Find(id);
            db.TrainBooking.Remove(trainBooking);
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
