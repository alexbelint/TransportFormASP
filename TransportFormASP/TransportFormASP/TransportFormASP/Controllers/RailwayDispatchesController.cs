using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportFormASP.Models;

namespace TransportFormASP.Controllers
{
    public class RailwayDispatchesController : Controller
    {
        private BTLCEntities db = new BTLCEntities();

        // GET: RailwayDispatches
        public ActionResult Index()
        {
            return View(db.RailwayDispatch.ToList());
        }

        // GET: RailwayDispatches/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RailwayDispatch railwayDispatch = db.RailwayDispatch.Find(id);
            if (railwayDispatch == null)
            {
                return HttpNotFound();
            }
            return View(railwayDispatch);
        }

        // GET: RailwayDispatches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RailwayDispatches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRailwayDispatch,DispatchType")] RailwayDispatch railwayDispatch)
        {
            if (ModelState.IsValid)
            {
                railwayDispatch.idRailwayDispatch = Guid.NewGuid();
                db.RailwayDispatch.Add(railwayDispatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(railwayDispatch);
        }

        // GET: RailwayDispatches/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RailwayDispatch railwayDispatch = db.RailwayDispatch.Find(id);
            if (railwayDispatch == null)
            {
                return HttpNotFound();
            }
            return View(railwayDispatch);
        }

        // POST: RailwayDispatches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRailwayDispatch,DispatchType")] RailwayDispatch railwayDispatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(railwayDispatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(railwayDispatch);
        }

        // GET: RailwayDispatches/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RailwayDispatch railwayDispatch = db.RailwayDispatch.Find(id);
            if (railwayDispatch == null)
            {
                return HttpNotFound();
            }
            return View(railwayDispatch);
        }

        // POST: RailwayDispatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RailwayDispatch railwayDispatch = db.RailwayDispatch.Find(id);
            db.RailwayDispatch.Remove(railwayDispatch);
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
