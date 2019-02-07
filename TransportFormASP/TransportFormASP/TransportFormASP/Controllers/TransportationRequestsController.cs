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
    public class TransportationRequestsController : Controller
    {
        private BTLC db = new BTLC();

        // GET: TransportationRequests
        public ActionResult Index(int? page)
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
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(transportationRequest.OrderBy(x => x.idTransportationRequest).ToPagedList(pageNumber, pageSize));
        }
    }
}
