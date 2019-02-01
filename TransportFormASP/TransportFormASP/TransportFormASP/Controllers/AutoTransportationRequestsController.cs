﻿using System;
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
//using Table = TransportFormASP.Models.Table;

namespace TransportFormASP.Controllers
{
    public class AutoTransportationRequestsController : Controller
    {
        private BTLCEntities db = new BTLCEntities();

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
                                                       .Include(t => t.CargoUnitNumber)
                                                       .Include(t => t.SpecialCondition);


            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(transportationRequest.OrderBy(x=>x.idTransportationRequest).ToPagedList(pageNumber, pageSize));
            //return View(transportationRequest.ToList());
        }
        [HttpPost]
        public ActionResult GetFilteredResult(IEnumerable<Filter> filters)
        {
            var results = GetFilteredQueryable(filters);
            var response = results.Select($"new ({filters.Single(x => x.Editing).Column} as value)").Distinct();
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        private IQueryable GetFilteredQueryable(IEnumerable<Filter> filters)
        {
            Table table = filters.Single(x => x.Editing).Table.Value;
            IQueryable results;
            switch (table)
            {
                case Table.ETSNG:
                    results = db.RefBookETSNG.AsQueryable();
                    break;
                case Table.GNG:
                    results = db.RefBookGNG.AsQueryable();
                    break;
                case Table.Countries:
                    results = db.RefBookLand.AsQueryable();
                    break;
                case Table.City:
                    results = db.RefBookStations.AsQueryable();
                    break;
                case Table.Period:
                    results = db.DateMonth.AsQueryable();
                    break;
                case Table.Client:
                    results = db.RefBookClient.AsQueryable();
                    break;
                case Table.SpecialCondition:
                    results = db.SpecialCondition.AsQueryable();
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
        // GET: AutoTransportationRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutoTransportationRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTransportationRequest,idDateMonth,idRefBookLandFrom,idRefBookLandTo,idRefBookETSNG,idRefBookGNG,DeliveryType,idDepartuePoint,idDestinationPoint,Shipper,Consignee,Weight,CargoUnitAmmount,idCargoUnitNumber,idSpecialCondition,Note,idTranshipmentMethod")] TransportationRequest transportationRequest)
      
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
            ViewBag.idDepartuePoint = new SelectList(db.DepartuePoint, "idDepartuePoint", "Adress", transportationRequest.idDepartuePoint);
            ViewBag.idDestinationPoint = new SelectList(db.DestinationPoint, "idDestinationPoint", "Adress", transportationRequest.idDestinationPoint);
            ViewBag.idCargoUnitNumber = new SelectList(db.CargoUnitNumber, "idCargoUnitNumber", "CargoUnitNumber1", transportationRequest.idCargoUnitNumber);
            ViewBag.idSpecialCondition = new SelectList(db.SpecialCondition, "idSpecialCondition", "SpecialCondition1", transportationRequest.idSpecialCondition);

            return View(transportationRequest);
        }

        // POST: AutoTransportationRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransportationRequest,idDateMonth,idRefBookLandFrom,idRefBookLandTo,idRefBookETSNG,idRefBookGNG,DeliveryType,idDepartuePoint,idDestinationPoint,Shipper,Consignee,Weight,CargoUnitAmmount,idCargoUnitNumber,idSpecialCondition,Note,idTranshipmentMethod")] TransportationRequest transportationRequest)
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
            ViewBag.idDepartuePoint = new SelectList(db.DepartuePoint, "idDepartuePoint", "Adress", transportationRequest.idDepartuePoint);
            ViewBag.idDestinationPoint = new SelectList(db.DestinationPoint, "idDestinationPoint", "Adress", transportationRequest.idDestinationPoint);
            ViewBag.idCargoUnitNumber = new SelectList(db.CargoUnitNumber, "idCargoUnitNumber", "CargoUnitNumber1", transportationRequest.idCargoUnitNumber);
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
