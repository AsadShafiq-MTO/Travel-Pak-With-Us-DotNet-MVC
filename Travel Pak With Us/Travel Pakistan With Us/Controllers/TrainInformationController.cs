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
    
    public class TrainInformationController : Controller
    {
        private TPWUSEntities db = new TPWUSEntities();

        // GET: TrainInformation
        public ActionResult Index()
        {
            return View(db.TrainInformation.ToList());
        }

        // GET: TrainInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainInformation trainInformation = db.TrainInformation.Find(id);
            if (trainInformation == null)
            {
                return HttpNotFound();
            }
            return View(trainInformation);
        }

        // GET: TrainInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Route,TimeDuration,DepartingTime,TicketPrice")] TrainInformation trainInformation)
        {
            if (ModelState.IsValid)
            {
                db.TrainInformation.Add(trainInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainInformation);
        }

        // GET: TrainInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainInformation trainInformation = db.TrainInformation.Find(id);
            if (trainInformation == null)
            {
                return HttpNotFound();
            }
            return View(trainInformation);
        }

        // POST: TrainInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Route,TimeDuration,DepartingTime,TicketPrice")] TrainInformation trainInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainInformation);
        }

        // GET: TrainInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainInformation trainInformation = db.TrainInformation.Find(id);
            if (trainInformation == null)
            {
                return HttpNotFound();
            }
            return View(trainInformation);
        }

        // POST: TrainInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainInformation trainInformation = db.TrainInformation.Find(id);
            db.TrainInformation.Remove(trainInformation);
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
