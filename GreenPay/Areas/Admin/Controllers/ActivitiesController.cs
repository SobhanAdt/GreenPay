using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace GreenPay.Areas.Admin.Controllers
{
    [Authorize]
    public class ActivitiesController : Controller
    {
        private GreenPayContext db = new GreenPayContext();

        // GET: Admin/Activities
        public ActionResult Index()
        {
            return View(db.Activities.ToList());
        }

        // GET: Admin/Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Admin/Activities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActiveID,ActiveImage,ActiveTitle")] Activity activity,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp!=null)
                {
                    activity.ActiveImage=Guid.NewGuid().ToString()+Path.GetExtension("/Images/Activity/"+imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/Activity/"+activity.ActiveImage));
                }
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        // GET: Admin/Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Admin/Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActiveID,ActiveImage,ActiveTitle")] Activity activity,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (activity.ActiveImage!=null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/Activity/" + activity.ActiveImage));
                    }
                    activity.ActiveImage = Guid.NewGuid().ToString() + Path.GetExtension("/Images/Activity/" + imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/Activity/" + activity.ActiveImage));
                }
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: Admin/Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Admin/Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity.ActiveImage != null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/Activity/" + activity.ActiveImage));
            }
            db.Activities.Remove(activity);
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
