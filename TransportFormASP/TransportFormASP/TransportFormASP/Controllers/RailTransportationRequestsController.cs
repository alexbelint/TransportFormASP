using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using PagedList;
using TransportFormASP.Models;

namespace TransportFormASP.Controllers
{
    public class RailTransportationRequestsController : Controller
    {
        private BTLC db = new BTLC();

        // GET: RailTransportationRequests
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
                                                       .Include(t => t.CargoUnitNumber)
                                                       .Include(t => t.SpecialCondition);


            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(transportationRequest.OrderBy(x => x.idTransportationRequest).ToPagedList(pageNumber, pageSize));
        }


        // GET: RailTransportationRequests/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: RailTransportationRequests/Create
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

            return View(transportationRequest);
        }
        [HttpPost]
        public ActionResult GetFilteredResult(IEnumerable<SelectorFilter> filters)
        {
            var results = GetFilteredQueryable(filters);
            var response = results.Select($"new ({filters.Single(x => x.Editing).Column} as value)").Distinct();
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        private IQueryable GetFilteredQueryable(IEnumerable<SelectorFilter> filters)
        {
            SelectorTable table = filters.Single(x => x.Editing).Table.Value;
            IQueryable results;
            switch (table)
            {
                case SelectorTable.ETSNG:
                    results = db.RefBookETSNG.AsQueryable();
                    break;
                case SelectorTable.GNG:
                    results = db.RefBookGNG.AsQueryable();
                    break;
                case SelectorTable.Countries:
                    results = db.RefBookLand.AsQueryable();
                    break;
                case SelectorTable.City:
                    results = db.RefBookStations.AsQueryable();
                    break;
                case SelectorTable.Period:
                    results = db.DateMonth.AsQueryable();
                    break;
                case SelectorTable.Client:
                    results = db.RefBookClient.AsQueryable();
                    break;
                case SelectorTable.SpecialCondition:
                    results = db.SpecialCondition.AsQueryable();
                    break;
                case SelectorTable.RailwayDispatch:
                    results = db.RailwayDispatch.AsQueryable();
                    break;
                case SelectorTable.RefBookCars:
                    results = db.RefBookCars.AsQueryable();
                    break;
                case SelectorTable.RefBookOwner:
                    results = db.RefBookOwner.AsQueryable();
                    break;
                case SelectorTable.CargoUnitNumbers:
                    results = db.CargoUnitNumber.AsQueryable();
                    break;
                default:
                    results = null;
                    break;
            }
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    results = results.Where($"{filter.Column}.Contains(@0)", filter.Value ?? "");
                }
            }
            return results;
        }


        // GET: RailTransportationRequests/Edit/5
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
            ViewBag.idCargoUnitNumber = new SelectList(db.CargoUnitNumber, "idCargoUnitNumber", "CargoUnitNumber1", transportationRequest.idCargoUnitNumber);
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

        // POST: RailTransportationRequests/Edit/5
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
            ViewBag.idCargoUnitNumber = new SelectList(db.CargoUnitNumber, "idCargoUnitNumber", "CargoUnitNumber1", transportationRequest.idCargoUnitNumber);
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
        // GET: RailTransportationRequests/Details/5
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

        // GET: RailTransportationRequests/Delete/5
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

        // POST: RailTransportationRequests/Delete/5
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
