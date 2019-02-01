using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportFormASP.Models;
using System.Linq.Dynamic;

namespace TransportFormASP.Controllers
{
    public class Filter
    {
        public string Column { get; set; }
        public string Value { get; set; }
        public bool Editing { get; set; }
        public Table? Table { get; set; }
    }
    public enum Table
    {
        GNG = 0,
        ETSNG = 1,
        Countries = 2,
        City = 3,
        Period = 4
    }
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