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
    public class SeaTransportationRequestsController : Controller
    {
        private BTLC db = new BTLC();

        // GET: SeaTransportationRequests
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

        // GET: SeaTransportationRequests/Create
        public ActionResult Create()
        {
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1");
            return View();
        }

        // POST: SeaTransportationRequests/Create

        [HttpPost]
        public ActionResult Create([Bind(Include = "idTransportationRequest,idDateMonth,idRefBookLandFrom,idRefBookLandTo,idRefBookETSNG,idRefBookGNG,DeliveryType,RefBookStationFrom,RefBookStationTo,idDepartuePoint,idDestinationPoint,idDepartuePort,idDestinationPort,Shipper,Consignee,idRailwayDispatch,idRefBookCars,idRefBookOwner,Weight,CargoUnitAmmount,CargoUnitNumber1,idSpecialCondition,Note,idTranshipmentMethod")] TransportationRequest transportationRequest)
        {
            if (ModelState.IsValid)
            {
                transportationRequest.idTransportationRequest = Guid.NewGuid();
                db.TransportationRequest.Add(transportationRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1", transportationRequest.idTranshipmentMethod);

            return View(transportationRequest);
        }

        // GET: SeaTransportationRequests/Edit/5
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
          
            return View(transportationRequest);
        }

        // POST: SeaTransportationRequests/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "idTransportationRequest,idDateMonth,idRefBookLandFrom,idRefBookLandTo,idRefBookETSNG,idRefBookGNG,DeliveryType,RefBookStationFrom,RefBookStationTo,idDepartuePoint,idDestinationPoint,idDepartuePort,idDestinationPort,Shipper,Consignee,idRailwayDispatch,idRefBookCars,idRefBookOwner,Weight,CargoUnitAmmount,CargoUnitNumber1,idSpecialCondition,Note,idTranshipmentMethod")] TransportationRequest transportationRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportationRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1", transportationRequest.idTranshipmentMethod);
          
            return View(transportationRequest);
        }

        // GET: SeaTransportationRequests/Details/5
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

        // GET: SeaTransportationRequests/Delete/5
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

        // POST: SeaTransportationRequests/Delete/5
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
