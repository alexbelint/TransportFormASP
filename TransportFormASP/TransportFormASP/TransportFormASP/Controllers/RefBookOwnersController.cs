using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TransportFormASP.Models;

namespace TransportFormASP.Controllers
{
    public class RefBookOwnersController : Controller
    {
        private BTLCEntities db = new BTLCEntities();

        // GET: RefBookOwners
        public ActionResult Index(int? page)
        {
            int pageSize = 16;
            int pageNumber = (page ?? 1);

            return View(db.RefBookOwner.OrderBy(x=>x.idRefBookOwner).ToPagedList(pageNumber, pageSize));
        }

        // GET: RefBookOwners/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookOwner refBookOwner = db.RefBookOwner.Find(id);
            if (refBookOwner == null)
            {
                return HttpNotFound();
            }
            return View(refBookOwner);
        }

        // GET: RefBookOwners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RefBookOwners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRefBookOwner,DateDownload,OwnerId,OwnerDsc")] RefBookOwner refBookOwner)
        {
            if (ModelState.IsValid)
            {
                refBookOwner.idRefBookOwner = Guid.NewGuid();
                db.RefBookOwner.Add(refBookOwner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(refBookOwner);
        }

        // GET: RefBookOwners/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookOwner refBookOwner = db.RefBookOwner.Find(id);
            if (refBookOwner == null)
            {
                return HttpNotFound();
            }
            return View(refBookOwner);
        }

        // POST: RefBookOwners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRefBookOwner,DateDownload,OwnerId,OwnerDsc")] RefBookOwner refBookOwner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refBookOwner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refBookOwner);
        }

        // GET: RefBookOwners/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookOwner refBookOwner = db.RefBookOwner.Find(id);
            if (refBookOwner == null)
            {
                return HttpNotFound();
            }
            return View(refBookOwner);
        }

        // POST: RefBookOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RefBookOwner refBookOwner = db.RefBookOwner.Find(id);
            db.RefBookOwner.Remove(refBookOwner);
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
