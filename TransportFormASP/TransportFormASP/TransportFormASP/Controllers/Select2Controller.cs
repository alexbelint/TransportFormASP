using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportFormASP.Models;
using System.Linq.Dynamic;

namespace TransportFormASP.Controllers
{
    public class Select2Controller : Controller

    {
        private BTLCEntities db = new BTLCEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "idTransportationRequest,idDateMonth,idRefBookLandFrom,idRefBookLandTo,idTranshipmentMethod,idRefBookGNG,idRefBookETSNG")] TransportationRequest transportationRequest)
        {
            if (ModelState.IsValid)
            {
                transportationRequest.idTransportationRequest = Guid.NewGuid();
                db.TransportationRequest.Add(transportationRequest);
                db.SaveChanges();
                return RedirectToAction("show");
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
    }
}