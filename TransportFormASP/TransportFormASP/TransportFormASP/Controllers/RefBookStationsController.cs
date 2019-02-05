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
    public class RefBookStationsController : Controller
    {
        private BTLC db = new BTLC();

        // GET: RefBookStations
        public ActionResult Index( int ? page)
        {

            var refBookStations = db.RefBookStations.Include(c => c.NewCode)
                                                    .Include(c => c.NewName)
                                                    .Include(c => c.Road)
                                                    .Include(c => c.RoadAbbr)
                                                    .Include(c => c.Land);

            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(db.RefBookStations.OrderBy(x=>x.Name).ToPagedList(pageNumber, pageSize));
        }

        // GET: RefBookStations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookStations refBookStations = db.RefBookStations.Find(id);
            if (refBookStations == null)
            {
                return HttpNotFound();
            }
            return View(refBookStations);
        }

        // GET: RefBookStations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RefBookStations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRefBookStation,DateDownload,Kod,NewCode,Name,NewName,NewParaT,VrParAdd,VrParDel,Road,Land,LinkCode,FromDate,ToDate,RoadID,LandID,RoadAbbr,LandAbbr,PID,DP,PPLand,RegName,OblSity,ParagTxt")] RefBookStations refBookStations)
        {
            if (ModelState.IsValid)
            {
                refBookStations.idRefBookStation = Guid.NewGuid();
                db.RefBookStations.Add(refBookStations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(refBookStations);
        }

        // GET: RefBookStations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookStations refBookStations = db.RefBookStations.Find(id);
            if (refBookStations == null)
            {
                return HttpNotFound();
            }
            return View(refBookStations);
        }

        // POST: RefBookStations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRefBookStation,DateDownload,Kod,NewCode,Name,NewName,NewParaT,VrParAdd,VrParDel,Road,Land,LinkCode,FromDate,ToDate,RoadID,LandID,RoadAbbr,LandAbbr,PID,DP,PPLand,RegName,OblSity,ParagTxt")] RefBookStations refBookStations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refBookStations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refBookStations);
        }

        // GET: RefBookStations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookStations refBookStations = db.RefBookStations.Find(id);
            if (refBookStations == null)
            {
                return HttpNotFound();
            }
            return View(refBookStations);
        }

        // POST: RefBookStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RefBookStations refBookStations = db.RefBookStations.Find(id);
            db.RefBookStations.Remove(refBookStations);
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
