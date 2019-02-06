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
    public class TransportationRequestsController : Controller
    {
        private BTLC db = new BTLC();

        // GET: TransportationRequests
        public ActionResult Index()
        {
            var transportationRequest = db.TransportationRequest.Include(t => t.DateMonth)
                .Include(t => t.RailwayDispatch)
                .Include(t => t.SpecialCondition)
                .Include(t => t.RefBookCars)
                .Include(t => t.RefBookClient)
                .Include(t => t.RefBookClient1)
                .Include(t => t.RefBookETSNG)
                .Include(t => t.RefBookGNG)
                .Include(t => t.RefBookLand)
                .Include(t => t.RefBookLand1)
                .Include(t => t.RefBookOwner)
                .Include(t => t.RefBookStations)
                .Include(t => t.RefBookStations1)
                .Include(t => t.TranshipmentMethod);
            return View(transportationRequest.ToList());
        }

        // GET: TransportationRequests/Details/5
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

        // GET: TransportationRequests/Create
        public ActionResult Create()
        {
            ViewBag.idDateMonth = new SelectList(db.DateMonth, "idDateMonth", "DateMonth1");
            ViewBag.idRailwayDispatch = new SelectList(db.RailwayDispatch, "idRailwayDispatch", "DispatchType");
            ViewBag.idSpecialCondition = new SelectList(db.SpecialCondition, "idSpecialCondition", "SpecialCondition1");
            ViewBag.idRefBookCars = new SelectList(db.RefBookCars, "idRefBookCars", "CarId");
            ViewBag.Shipper = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName");
            ViewBag.Consignee = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName");
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNG, "idRefBookETSNG", "Kod");
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNG, "idRefBookGNG", "Kod");
            ViewBag.idRefBookLandFrom = new SelectList(db.RefBookLand, "idRefBookLand", "LandId");
            ViewBag.idRefBookLandTo = new SelectList(db.RefBookLand, "idRefBookLand", "LandId");
            ViewBag.idRefBookOwner = new SelectList(db.RefBookOwner, "idRefBookOwner", "OwnerId");
            ViewBag.RefBookStationFrom = new SelectList(db.RefBookStations, "idRefBookStation", "Kod");
            ViewBag.RefBookStationTo = new SelectList(db.RefBookStations, "idRefBookStation", "Kod");
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1");
            return View();
        }

        // POST: TransportationRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTransportationRequest,idDateMonth,idRefBookLandFrom,idRefBookLandTo,idRefBookETSNG,idRefBookGNG,DeliveryType,RefBookStationFrom,RefBookStationTo,idDepartuePoint,idDestinationPoint,idDepartuePort,idDestinationPort,Shipper,Consignee,idRailwayDispatch,idRefBookCars,idRefBookOwner,Weight,CargoUnitAmmount,idCargoUnitNumber,idSpecialCondition,Note,idTranshipmentMethod")] TransportationRequest transportationRequest)
        {
            if (ModelState.IsValid)
            {
                transportationRequest.idTransportationRequest = Guid.NewGuid();
                db.TransportationRequest.Add(transportationRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDateMonth = new SelectList(db.DateMonth, "idDateMonth", "DateMonth1", transportationRequest.idDateMonth);
            ViewBag.idRailwayDispatch = new SelectList(db.RailwayDispatch, "idRailwayDispatch", "DispatchType", transportationRequest.idRailwayDispatch);
            ViewBag.idSpecialCondition = new SelectList(db.SpecialCondition, "idSpecialCondition", "SpecialCondition1", transportationRequest.idSpecialCondition);
            ViewBag.idRefBookCars = new SelectList(db.RefBookCars, "idRefBookCars", "CarId", transportationRequest.idRefBookCars);
            ViewBag.Shipper = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Shipper);
            ViewBag.Consignee = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Consignee);
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNG, "idRefBookETSNG", "Kod", transportationRequest.idRefBookETSNG);
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNG, "idRefBookGNG", "Kod", transportationRequest.idRefBookGNG);
            ViewBag.idRefBookLandFrom = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", transportationRequest.idRefBookLandFrom);
            ViewBag.idRefBookLandTo = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", transportationRequest.idRefBookLandTo);
            ViewBag.idRefBookOwner = new SelectList(db.RefBookOwner, "idRefBookOwner", "OwnerId", transportationRequest.idRefBookOwner);
            ViewBag.RefBookStationFrom = new SelectList(db.RefBookStations, "idRefBookStation", "Kod", transportationRequest.RefBookStationFrom);
            ViewBag.RefBookStationTo = new SelectList(db.RefBookStations, "idRefBookStation", "Kod", transportationRequest.RefBookStationTo);
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1", transportationRequest.idTranshipmentMethod);
            return View(transportationRequest);
        }

        // GET: TransportationRequests/Edit/5
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
            ViewBag.idDateMonth = new SelectList(db.DateMonth, "idDateMonth", "DateMonth1", transportationRequest.idDateMonth);
            ViewBag.idRailwayDispatch = new SelectList(db.RailwayDispatch, "idRailwayDispatch", "DispatchType", transportationRequest.idRailwayDispatch);
            ViewBag.idSpecialCondition = new SelectList(db.SpecialCondition, "idSpecialCondition", "SpecialCondition1", transportationRequest.idSpecialCondition);
            ViewBag.idRefBookCars = new SelectList(db.RefBookCars, "idRefBookCars", "CarId", transportationRequest.idRefBookCars);
            ViewBag.Shipper = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Shipper);
            ViewBag.Consignee = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Consignee);
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNG, "idRefBookETSNG", "Kod", transportationRequest.idRefBookETSNG);
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNG, "idRefBookGNG", "Kod", transportationRequest.idRefBookGNG);
            ViewBag.idRefBookLandFrom = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", transportationRequest.idRefBookLandFrom);
            ViewBag.idRefBookLandTo = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", transportationRequest.idRefBookLandTo);
            ViewBag.idRefBookOwner = new SelectList(db.RefBookOwner, "idRefBookOwner", "OwnerId", transportationRequest.idRefBookOwner);
            ViewBag.RefBookStationFrom = new SelectList(db.RefBookStations, "idRefBookStation", "Kod", transportationRequest.RefBookStationFrom);
            ViewBag.RefBookStationTo = new SelectList(db.RefBookStations, "idRefBookStation", "Kod", transportationRequest.RefBookStationTo);
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1", transportationRequest.idTranshipmentMethod);
           
            return View(transportationRequest);
        }

        // POST: TransportationRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransportationRequest,idDateMonth,idRefBookLandFrom,idRefBookLandTo,idRefBookETSNG,idRefBookGNG,DeliveryType,RefBookStationFrom,RefBookStationTo,idDepartuePoint,idDestinationPoint,idDepartuePort,idDestinationPort,Shipper,Consignee,idRailwayDispatch,idRefBookCars,idRefBookOwner,Weight,CargoUnitAmmount,idCargoUnitNumber,idSpecialCondition,Note,idTranshipmentMethod")] TransportationRequest transportationRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportationRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         
            ViewBag.idDateMonth = new SelectList(db.DateMonth, "idDateMonth", "DateMonth1", transportationRequest.idDateMonth);
            ViewBag.idRailwayDispatch = new SelectList(db.RailwayDispatch, "idRailwayDispatch", "DispatchType", transportationRequest.idRailwayDispatch);
            ViewBag.idSpecialCondition = new SelectList(db.SpecialCondition, "idSpecialCondition", "SpecialCondition1", transportationRequest.idSpecialCondition);
            ViewBag.idRefBookCars = new SelectList(db.RefBookCars, "idRefBookCars", "CarId", transportationRequest.idRefBookCars);
            ViewBag.Shipper = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Shipper);
            ViewBag.Consignee = new SelectList(db.RefBookClient, "idRefBookClient", "ShortName", transportationRequest.Consignee);
            ViewBag.idRefBookETSNG = new SelectList(db.RefBookETSNG, "idRefBookETSNG", "Kod", transportationRequest.idRefBookETSNG);
            ViewBag.idRefBookGNG = new SelectList(db.RefBookGNG, "idRefBookGNG", "Kod", transportationRequest.idRefBookGNG);
            ViewBag.idRefBookLandFrom = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", transportationRequest.idRefBookLandFrom);
            ViewBag.idRefBookLandTo = new SelectList(db.RefBookLand, "idRefBookLand", "LandId", transportationRequest.idRefBookLandTo);
            ViewBag.idRefBookOwner = new SelectList(db.RefBookOwner, "idRefBookOwner", "OwnerId", transportationRequest.idRefBookOwner);
            ViewBag.RefBookStationFrom = new SelectList(db.RefBookStations, "idRefBookStation", "Kod", transportationRequest.RefBookStationFrom);
            ViewBag.RefBookStationTo = new SelectList(db.RefBookStations, "idRefBookStation", "Kod", transportationRequest.RefBookStationTo);
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1", transportationRequest.idTranshipmentMethod);
            return View(transportationRequest);
        }

        // GET: TransportationRequests/Delete/5
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

        // POST: TransportationRequests/Delete/5
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
