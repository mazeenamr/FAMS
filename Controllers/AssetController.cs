using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OGtech.Models;
using OGtech.ViewModel;
using System.Data.Entity;

namespace OGtech.Controllers
{
    public class AssetController : Controller
    {
        private ApplicationDbContext _Context;

        public AssetController() 
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: Asset
        public ActionResult Index()
        {
            var Assets = _Context.Assets.Include(c => c.Type).ToList();

            return View(Assets);
        }
        public ActionResult newAsset()
        {
            var type = _Context.Assettypes;
            var ViewModel = new NewAssetViewModel            {
                Assettypes = type
            };
            return View("newAsset", ViewModel);
        }
        public ActionResult Save(Asset asset)
        {
            if(asset.id == 0)
            _Context.Assets.Add(asset);
            else
            {
                var AssetInDb = _Context.Assets.SingleOrDefault(c => c.id == asset.id);


                AssetInDb.name = asset.name;
                AssetInDb.descreption = asset.descreption;
                AssetInDb.typeId= asset.typeId;
            }
            _Context.SaveChanges();

            return RedirectToAction("Index", ("Asset"));
        }
        public ActionResult Edit(int id)
        {
            var Asset = _Context.Assets.SingleOrDefault(c => c.id == id);
            var ViewModel = new NewAssetViewModel()
            {
                Asset = Asset,
                Assettypes = _Context.Assettypes.ToList()
            };
            return View("EditAsset", ViewModel);
        }
        public ActionResult Delete(int id)
        {
            var Asset = _Context.Assets.SingleOrDefault(c => c.id == id);
            _Context.Assets.Remove(Asset);
            _Context.SaveChanges();

            return RedirectToAction("Index", ("Asset"));

        }
    }
}