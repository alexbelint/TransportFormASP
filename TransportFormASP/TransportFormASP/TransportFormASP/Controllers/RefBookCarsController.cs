using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportFormASP.Models;
using PagedList;

namespace TransportFormASP.Controllers
{
    public class RefBookCarsController : Controller
    {
        private BTLCEntities db = new BTLCEntities();

        // GET: RefBookCars
        public ActionResult Index(int? page)
        {
            int pageSize = 16;
            int pageNumber = (page ?? 1);

            return View(db.RefBookCars.OrderBy(x=>x.Name).ToPagedList(pageNumber, pageSize));
        }

        // GET: RefBookCars/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookCars refBookCars = db.RefBookCars.Find(id);
            if (refBookCars == null)
            {
                return HttpNotFound();
            }
            return View(refBookCars);
        }

        // GET: RefBookCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RefBookCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRefBookCars,DateDownload,CarId,Name,Model,GP,Volume,Axis,TareW,CarType,Gross,Length")] RefBookCars refBookCars)
        {
            if (ModelState.IsValid)
            {
                refBookCars.idRefBookCars = Guid.NewGuid();
                db.RefBookCars.Add(refBookCars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(refBookCars);
        }

        // GET: RefBookCars/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookCars refBookCars = db.RefBookCars.Find(id);
            if (refBookCars == null)
            {
                return HttpNotFound();
            }
            return View(refBookCars);
        }

        // POST: RefBookCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRefBookCars,DateDownload,CarId,Name,Model,GP,Volume,Axis,TareW,CarType,Gross,Length")] RefBookCars refBookCars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refBookCars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refBookCars);
        }

        // GET: RefBookCars/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookCars refBookCars = db.RefBookCars.Find(id);
            if (refBookCars == null)
            {
                return HttpNotFound();
            }
            return View(refBookCars);
        }

        // POST: RefBookCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RefBookCars refBookCars = db.RefBookCars.Find(id);
            db.RefBookCars.Remove(refBookCars);
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
