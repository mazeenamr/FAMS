using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OGtech.Models;


namespace OGtech.Controllers
{
    public class LocationController : Controller
    {
        private ApplicationDbContext _Context;

        public LocationController() 
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: Location
        public ActionResult Index()
        {
            var Location = _Context.Locations.ToList();

            return View(Location);
        }
        public ActionResult newLocation()
        {
            return View("newLocation");
        }
        public ActionResult Save(Location location)
        {
            if (location.id == 0)
                _Context.Locations.Add(location);
            else
            {
                var LocationInDb = _Context.Locations.SingleOrDefault(c => c.id == location.id);

                LocationInDb.name = location.name;
                LocationInDb.RFIDCode = location.RFIDCode;
            }

            _Context.SaveChanges();

            return RedirectToAction("Index", ("Location"));
        }
        public ActionResult Edit(int id)
        {
            var Location = _Context.Locations.SingleOrDefault(c => c.id == id);

            return View("EditLocation", Location);
        }
        public ActionResult Delete(int id)
        {
            var Location = _Context.Locations.SingleOrDefault(c => c.id == id);
            _Context.Locations.Remove(Location);
            _Context.SaveChanges();

            return RedirectToAction("Index", ("Location"));

        }
    }
}