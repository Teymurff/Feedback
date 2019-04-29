using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vizew.WebUI.Models;
using Vizew.WebUI.Models.Entity;

namespace Vizew.WebUI.Areas.Admin.Controllers
{
    public class InfosController : Controller
    {
        VizewDbContext db = new VizewDbContext();
        // GET: Admin/Infos
        public ActionResult Index()
        {

            var info = db.Info.Where(n => n.IsRead == false||true && n.DeletedDate==null)
                  .ToList();

            return View(info);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info info = db.Info.Find(id);
             info.IsRead = true;
            db.Entry(info).State = EntityState.Modified;
            db.SaveChanges();
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

        public ActionResult Delete(int id)
        {
            Info info = db.Info.Find(id);
            info.DeletedDate = DateTime.Now;
            info.IsRead = true || false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       

    }
}