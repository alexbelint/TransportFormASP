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
    public class RefBookClientsController : Controller
    {
        private BTLCEntities db = new BTLCEntities();

        // GET: RefBookClients
        public ActionResult Index(int? page)
        {
            var refBookClient = db.RefBookClient.Include(r => r.RefBookLand).Include(r => r.RefBookLand1);
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(refBookClient.OrderBy(x => x.idRefBookClient).ToPagedList(pageNumber, pageSize));
        }

      

        // GET: RefBookClients/Create
        public ActionResult Create()
        {
            ViewBag.idRefBookLand = new SelectList(db.RefBookLand, "idRefBookLand", "LandId");
            ViewBag.idRefBookLand = new SelectList(db.RefBookLand, "idRefBookLand", "LandId");
            return View();
        }

        // POST: RefBookClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRefBookClient,ShortName,FullName,UNN,idRefBookLand,AddressLegal,DirectorPositionIP,DirectorSurnameIP,BookerPositionIP,BookerSurnameIP,DirectorSurnameRP,DirectorPositionRP,BankAccount,BankCode,BankName,BankCity")] RefBookClient refBookClient)
        {
            if (ModelState.IsValid)
            {
                refBookClient.idRefBookClient = Guid.NewGuid();
                db.RefBookClient.Add(refBookClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRefBookLand = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", refBookClient.idRefBookLand);
            ViewBag.idRefBookLand = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", refBookClient.idRefBookLand);
            return View(refBookClient);
        }

        // GET: RefBookClients/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookClient refBookClient = db.RefBookClient.Find(id);
            if (refBookClient == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRefBookLand = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", refBookClient.idRefBookLand);
            ViewBag.idRefBookLand = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", refBookClient.idRefBookLand);
            return View(refBookClient);
        }

        // POST: RefBookClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRefBookClient,ShortName,FullName,UNN,idRefBookLand,AddressLegal,DirectorPositionIP,DirectorSurnameIP,BookerPositionIP,BookerSurnameIP,DirectorSurnameRP,DirectorPositionRP,BankAccount,BankCode,BankName,BankCity")] RefBookClient refBookClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refBookClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRefBookLand = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", refBookClient.idRefBookLand);
            ViewBag.idRefBookLand = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", refBookClient.idRefBookLand);
            return View(refBookClient);
        }
        // GET: RefBookClients/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookClient refBookClient = db.RefBookClient.Find(id);
            if (refBookClient == null)
            {
                return HttpNotFound();
            }
            return View(refBookClient);
        }
        // GET: RefBookClients/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefBookClient refBookClient = db.RefBookClient.Find(id);
            if (refBookClient == null)
            {
                return HttpNotFound();
            }
            return View(refBookClient);
        }

        // POST: RefBookClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RefBookClient refBookClient = db.RefBookClient.Find(id);
            db.RefBookClient.Remove(refBookClient);
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
