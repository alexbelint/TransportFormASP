using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportFormASP.Models;
using System.Linq.Dynamic;
using System.Web.UI.WebControls;
using PagedList;

namespace TransportFormASP.Controllers
{
    public class AutoTransportationRequestsController : Controller
    {
        private BTLC db = new BTLC();

        // GET: AutoTransportationRequests
        public ActionResult Index(int? page)
        {
            var transportationRequest = db.TransportationRequest.Include(t => t.DateMonth)
                                                       .Include(t => t.TranshipmentMethod)
                                                       .Include(t => t.RefBookLand)
                                                       .Include(t => t.RefBookLand1)
                                                       .Include(t => t.RefBookETSNG)
                                                       .Include(t => t.RefBookGNG)
                                                       .Include(t => t.RefBookClient)
                                                       .Include(t => t.RefBookClient1)
                                                       .Include(t => t.SpecialCondition);

            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(transportationRequest.OrderBy(x => x.idTransportationRequest).ToPagedList(pageNumber, pageSize));
        }
        // GET: AutoTransportationRequests/Create
        public ActionResult Create()
        {
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1");
            ViewBag.idRefBookLandFrom = new SelectList(db.RefBookLand, "idRefBookLand", "LName");
            ViewBag.idRefBookLandTo = new SelectList(db.RefBookLand, "idRefBookLand", "LName");
            ViewBag.Shipper = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName");
            ViewBag.Consignee = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName");
            return View();
        }

        // POST: AutoTransportationRequests/Create
        [HttpPost]

        public ActionResult Create([Bind(Include = "idTransportationRequest,idDateMonth,idRefBookLandFrom,idRefBookLandTo,idRefBookETSNG,idRefBookGNG,DeliveryType,DepartuePoint,DestinationPoint,Shipper,Consignee,Weight,CargoUnitAmmount,idCargoUnitNumber,idSpecialCondition,Note,idTranshipmentMethod")] TransportationRequest transportationRequest)

        {
            if (ModelState.IsValid)
            {
                transportationRequest.idTransportationRequest = Guid.NewGuid();
                db.TransportationRequest.Add(transportationRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1", transportationRequest.idTranshipmentMethod);
            ViewBag.idRefBookLandFrom = new SelectList(db.RefBookLand, "idRefBookLand", "LName", transportationRequest.idRefBookLandFrom);
            ViewBag.idRefBookLandTo = new SelectList(db.RefBookLand, "idRefBookLand", "LName", transportationRequest.idRefBookLandTo);
            ViewBag.Shipper = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Shipper);
            ViewBag.Consignee = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Consignee);
            return View(transportationRequest);
        }

        // GET: AutoTransportationRequests/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportationRequest transportationRequest = db.TransportationRequest.Find(id);
            if (transportationRequest == null)
            {
                return HttpNotFound();
            }
            return View(transportationRequest);
        }
        // GET: AutoTransportationRequests/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportationRequest transportationRequest = db.TransportationRequest.Find(id);
            if (transportationRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1", transportationRequest.idTranshipmentMethod);
            ViewBag.idDateMonth = new SelectList(db.DateMonth, "idDateMonth", "DateMonth1", transportationRequest.idDateMonth);
            ViewBag.idRefBookLandFrom = new SelectList(db.RefBookLand, "idRefBookLand", "LName", transportationRequest.idRefBookLandFrom);
            ViewBag.idRefBookLandTo = new SelectList(db.RefBookLand, "idRefBookLand", "LName", transportationRequest.idRefBookLandTo);
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNG, "idRefBookETSNG", "Name", transportationRequest.idRefBookETSNG);
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNG, "idRefBookGNG", "Name", transportationRequest.idRefBookGNG);
            ViewBag.Shipper = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Shipper);
            ViewBag.Consignee = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Consignee);
            ViewBag.idSpecialCondition = new SelectList(db.SpecialCondition, "idSpecialCondition", "SpecialCondition1", transportationRequest.idSpecialCondition);

            return View(transportationRequest);
        }

        // POST: AutoTransportationRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransportationRequest, idDateMonth, idRefBookLandFrom, idRefBookLandTo, idRefBookETSNG, idRefBookGNG, DeliveryType, DepartuePoint, DestinationPoint, Shipper, Consignee, Weight, CargoUnitAmmount, idCargoUnitNumber, idSpecialCondition, Note, idTranshipmentMethod")] TransportationRequest transportationRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportationRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1", transportationRequest.idTranshipmentMethod);
            ViewBag.idDateMonth = new SelectList(db.DateMonth, "idDateMonth", "DateMonth1", transportationRequest.idDateMonth);
            ViewBag.idRefBookLandFrom = new SelectList(db.RefBookLand, "idRefBookLand", "LName", transportationRequest.idRefBookLandFrom);
            ViewBag.idRefBookLandTo = new SelectList(db.RefBookLand, "idRefBookLand", "LName", transportationRequest.idRefBookLandTo);
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNG, "idRefBookETSNG", "Name", transportationRequest.idRefBookETSNG);
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNG, "idRefBookGNG", "Name", transportationRequest.idRefBookGNG);
            ViewBag.Shipper = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Shipper);
            ViewBag.Consignee = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Consignee);
            ViewBag.idSpecialCondition = new SelectList(db.SpecialCondition, "idSpecialCondition", "SpecialCondition1", transportationRequest.idSpecialCondition);
            return View(transportationRequest);
        }

        // GET: AutoTransportationRequests/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportationRequest transportationRequest = db.TransportationRequest.Find(id);
            if (transportationRequest == null)
            {
                return HttpNotFound();
            }
            return View(transportationRequest);
        }

        // POST: AutoTransportationRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TransportationRequest transportationRequest = db.TransportationRequest.Find(id);
            db.TransportationRequest.Remove(transportationRequest);
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
