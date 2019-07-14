using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OGtech.Models;

namespace OGtech.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext _Context;

        public ItemController() 
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: Item
        public ActionResult Index()
        {
            var items = _Context.Items.ToList();

            return View(items);
        }
        public ActionResult newItem()
        {
            return View("newItem");
        }
        public ActionResult Save(Item item)
        {
            if (item.id == 0)
                _Context.Items.Add(item);
            else
            {
                var ItemInDb = _Context.Items.SingleOrDefault(c => c.id == item.id);

                ItemInDb.name = item.name;
                ItemInDb.RFIDCode = item.RFIDCode;
                ItemInDb.descreption = item.descreption;
            }

            _Context.SaveChanges();

            return RedirectToAction("Index", ("Item"));
        }
        public ActionResult Edit(int id)
        {
            var item = _Context.Items.SingleOrDefault(c => c.id == id);
            
            
            return View("EditItem", item);
        }
        public ActionResult Delete(int id)
        {
            var Items = _Context.Items.SingleOrDefault(c => c.id == id);
            _Context.Items.Remove(Items);
            _Context.SaveChanges();

            return RedirectToAction("Index", ("Item"));

        }
    }
}