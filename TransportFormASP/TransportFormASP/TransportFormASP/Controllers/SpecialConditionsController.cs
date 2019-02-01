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
    public class SpecialConditionsController : Controller
    {
        private BTLCEntities db = new BTLCEntities();

        // GET: SpecialConditions
        public ActionResult Index(int? page)
        {

            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(db.SpecialCondition.OrderBy(x => x.SpecialCondition1).ToPagedList(pageNumber, pageSize));
        }
        //return View(db.SpecialCondition.ToList());



        // GET: SpecialConditions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialConditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSpecialCondition,SpecialCondition1")] SpecialCondition specialCondition)
        {
            if (ModelState.IsValid)
            {
                specialCondition.idSpecialCondition = Guid.NewGuid();
                db.SpecialCondition.Add(specialCondition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialCondition);
        }

        // GET: SpecialConditions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialCondition specialCondition = db.SpecialCondition.Find(id);
            if (specialCondition == null)
            {
                return HttpNotFound();
            }
            return View(specialCondition);
        }

        // POST: SpecialConditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSpecialCondition,SpecialCondition1")] SpecialCondition specialCondition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialCondition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialCondition);
        }

        // GET: SpecialConditions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialCondition specialCondition = db.SpecialCondition.Find(id);
            if (specialCondition == null)
            {
                return HttpNotFound();
            }
            return View(specialCondition);
        }

        // POST: SpecialConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SpecialCondition specialCondition = db.SpecialCondition.Find(id);
            db.SpecialCondition.Remove(specialCondition);
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
