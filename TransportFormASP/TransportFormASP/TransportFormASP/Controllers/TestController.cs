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
    public class TestController : Controller
    {
        private BTLC db = new BTLC();
        [HttpPost]
        public ActionResult GetFilteredResult(IEnumerable<SelectorFilter> filters)
        {
            var results = GetFilteredQueryable(filters);
            var response = results.Select($"new ({filters.Single(x => x.Editing).Column} as value, {filters.Single(x => x.Editing).Name} as key)").Distinct();
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
        // GET: Test
        public ActionResult IndexTest()
        {
            return View();
        }


        // GET: Test/Create
        public ActionResult CreateTest()
        {
            ViewBag.idTranshipmentMethod = new SelectList(db.TranshipmentMethod, "idTranshipmentMethod", "TranshipmentMethod1");
            return View();
        }


        // POST: Test/Create
        [HttpPost]
        public ActionResult CreateTest([Bind(Include = "idTransportationRequest,idDateMonth,idRefBookLand,idRefBookLandFrom,idRefBookLandTo,idRefBookETSNG,idRefBookGNG,DeliveryType,idDepartuePoint,idDestinationPoint,Shipper,Consignee,Weight,CargoUnitAmmount,idCargoUnitNumber,idSpecialCondition,Note,idTranshipmentMethod")] TransportationRequest transportationRequest)
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

    }
}
