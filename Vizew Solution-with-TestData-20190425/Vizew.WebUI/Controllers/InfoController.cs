using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vizew.WebUI.Models;
using Vizew.WebUI.Models.Entity;

namespace Vizew.WebUI.Controllers
{
    public class InfoController : Controller
    {
        public ActionResult Index()
        {
            VizewDbContext db = new VizewDbContext();

            var info = db.Info.Where(n => n.IsRead == false)
                  .ToList();

            return View(info);
        }




        [HttpPost]
        public ActionResult Create(Info info)
        {
            VizewDbContext db = new VizewDbContext();

            if (ModelState.IsValid)
            {
                db.Info.Add(info);
                db.SaveChanges();
              
                return RedirectToAction("Index","Home");
            }

            return View(info);
            
        }
    }
}