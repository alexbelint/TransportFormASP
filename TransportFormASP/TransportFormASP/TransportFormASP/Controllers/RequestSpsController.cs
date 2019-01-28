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
    public class RequestSpsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: RequestSps
        public ActionResult Index()
        {
            var requestSps = db.RequestSps.Include(r => r.RefBookCars).Include(r => r.RefBookETSNG).Include(r => r.RefBookGNG).Include(r => r.RefBookLandOwn).Include(r => r.RefBookOtpr).Include(r => r.RefBookOwner).Include(r => r.RefBookOwnFirm).Include(r => r.RefBookStatus).Include(r => r.Request);
            return View(requestSps.ToList());
        }

        // GET: RequestSps/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestSp requestSp = db.RequestSps.Find(id);
            if (requestSp == null)
            {
                return HttpNotFound();
            }
            return View(requestSp);
        }

        // GET: RequestSps/Create
        public ActionResult Create()
        {
            ViewBag.idRefBookCars = new SelectList(db.RefBookCars, "idRefBookCars", "CarId");
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNGs, "idRefBookETSNG", "Kod");
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNGs, "idRefBookGNG", "Kod");
            ViewBag.idRefBookLandOwn = new SelectList(db.RefBookLandOwns, "idRefBookLandOwn", "LandId");
            ViewBag.idRefBookOtpr = new SelectList(db.RefBookOtprs, "idRefBookOtpr", "OtprId");
            ViewBag.idRefBookOwner = new SelectList(db.RefBookOwners, "idRefBookOwner", "OwnerId");
            ViewBag.idRefBookOwnFirm = new SelectList(db.RefBookOwnFirms, "idRefBookOwnFirm", "Id");
            ViewBag.idRefBookStatus = new SelectList(db.RefBookStatus, "idRefBookStatus", "NameStatus");
            ViewBag.idRequest = new SelectList(db.Requests, "idRequest", "RequestNote");
            return View();
        }

        // POST: RequestSps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRequestSp,idRequest,idRefBookStatus,idRefBookStationFrom,idRefBookStationTo,TypeTransportation,idRefBookOtpr,idRefBookETSNG,idRefBookGNG,Weight,IsDangers,idRefBookCars,idRefBookOwner,idRefBookOwnFirm,idRefBookLandOwn,CountCars,CountWagon,RequestSpNote,DateRequestSpInput,idSender,idRecipient,idBorderCrossFrom,idBorderCrossIn")] RequestSp requestSp)
        {
            if (ModelState.IsValid)
            {
                requestSp.idRequestSp = Guid.NewGuid();
                db.RequestSps.Add(requestSp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRefBookCars = new SelectList(db.RefBookCars, "idRefBookCars", "CarId", requestSp.idRefBookCars);
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNGs, "idRefBookETSNG", "Kod", requestSp.idRefBookETSNG);
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNGs, "idRefBookGNG", "Kod", requestSp.idRefBookGNG);
            ViewBag.idRefBookLandOwn = new SelectList(db.RefBookLandOwns, "idRefBookLandOwn", "LandId", requestSp.idRefBookLandOwn);
            ViewBag.idRefBookOtpr = new SelectList(db.RefBookOtprs, "idRefBookOtpr", "OtprId", requestSp.idRefBookOtpr);
            ViewBag.idRefBookOwner = new SelectList(db.RefBookOwners, "idRefBookOwner", "OwnerId", requestSp.idRefBookOwner);
            ViewBag.idRefBookOwnFirm = new SelectList(db.RefBookOwnFirms, "idRefBookOwnFirm", "Id", requestSp.idRefBookOwnFirm);
            ViewBag.idRefBookStatus = new SelectList(db.RefBookStatus, "idRefBookStatus", "NameStatus", requestSp.idRefBookStatus);
            ViewBag.idRequest = new SelectList(db.Requests, "idRequest", "RequestNote", requestSp.idRequest);
            return View(requestSp);
        }

        // GET: RequestSps/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestSp requestSp = db.RequestSps.Find(id);
            if (requestSp == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRefBookCars = new SelectList(db.RefBookCars, "idRefBookCars", "CarId", requestSp.idRefBookCars);
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNGs, "idRefBookETSNG", "Kod", requestSp.idRefBookETSNG);
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNGs, "idRefBookGNG", "Kod", requestSp.idRefBookGNG);
            ViewBag.idRefBookLandOwn = new SelectList(db.RefBookLandOwns, "idRefBookLandOwn", "LandId", requestSp.idRefBookLandOwn);
            ViewBag.idRefBookOtpr = new SelectList(db.RefBookOtprs, "idRefBookOtpr", "OtprId", requestSp.idRefBookOtpr);
            ViewBag.idRefBookOwner = new SelectList(db.RefBookOwners, "idRefBookOwner", "OwnerId", requestSp.idRefBookOwner);
            ViewBag.idRefBookOwnFirm = new SelectList(db.RefBookOwnFirms, "idRefBookOwnFirm", "Id", requestSp.idRefBookOwnFirm);
            ViewBag.idRefBookStatus = new SelectList(db.RefBookStatus, "idRefBookStatus", "NameStatus", requestSp.idRefBookStatus);
            ViewBag.idRequest = new SelectList(db.Requests, "idRequest", "RequestNote", requestSp.idRequest);
            return View(requestSp);
        }

        // POST: RequestSps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRequestSp,idRequest,idRefBookStatus,idRefBookStationFrom,idRefBookStationTo,TypeTransportation,idRefBookOtpr,idRefBookETSNG,idRefBookGNG,Weight,IsDangers,idRefBookCars,idRefBookOwner,idRefBookOwnFirm,idRefBookLandOwn,CountCars,CountWagon,RequestSpNote,DateRequestSpInput,idSender,idRecipient,idBorderCrossFrom,idBorderCrossIn")] RequestSp requestSp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestSp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRefBookCars = new SelectList(db.RefBookCars, "idRefBookCars", "CarId", requestSp.idRefBookCars);
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNGs, "idRefBookETSNG", "Kod", requestSp.idRefBookETSNG);
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNGs, "idRefBookGNG", "Kod", requestSp.idRefBookGNG);
            ViewBag.idRefBookLandOwn = new SelectList(db.RefBookLandOwns, "idRefBookLandOwn", "LandId", requestSp.idRefBookLandOwn);
            ViewBag.idRefBookOtpr = new SelectList(db.RefBookOtprs, "idRefBookOtpr", "OtprId", requestSp.idRefBookOtpr);
            ViewBag.idRefBookOwner = new SelectList(db.RefBookOwners, "idRefBookOwner", "OwnerId", requestSp.idRefBookOwner);
            ViewBag.idRefBookOwnFirm = new SelectList(db.RefBookOwnFirms, "idRefBookOwnFirm", "Id", requestSp.idRefBookOwnFirm);
            ViewBag.idRefBookStatus = new SelectList(db.RefBookStatus, "idRefBookStatus", "NameStatus", requestSp.idRefBookStatus);
            ViewBag.idRequest = new SelectList(db.Requests, "idRequest", "RequestNote", requestSp.idRequest);
            return View(requestSp);
        }

        // GET: RequestSps/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestSp requestSp = db.RequestSps.Find(id);
            if (requestSp == null)
            {
                return HttpNotFound();
            }
            return View(requestSp);
        }

        // POST: RequestSps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RequestSp requestSp = db.RequestSps.Find(id);
            db.RequestSps.Remove(requestSp);
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
