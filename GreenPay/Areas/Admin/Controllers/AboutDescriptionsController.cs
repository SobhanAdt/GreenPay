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
    public class AboutDescriptionsController : Controller
    {
        private GreenPayContext db = new GreenPayContext();
        private ITeamAboutRepository teamAboutRepository;

        public AboutDescriptionsController()
        {
            teamAboutRepository=new TeamAboutRepository(db);
        }

        // GET: Admin/AboutDescriptions
        public ActionResult Index()
        {
            return View(teamAboutRepository.GetAllAboutDescriptions());
        }

        // GET: Admin/AboutDescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutDescription aboutDescription = db.AboutDescriptions.Find(id);
            if (aboutDescription == null)
            {
                return HttpNotFound();
            }
            return View(aboutDescription);
        }

        // GET: Admin/AboutDescriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AboutID,Image,Title,Description")] AboutDescription aboutDescription,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp!=null)
                {
                    aboutDescription.Image = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/AboutImages/"+aboutDescription.Image));
                }
                teamAboutRepository.InsertAbout(aboutDescription);
                teamAboutRepository.Save();
                return RedirectToAction("Index");
            }

            return View(aboutDescription);
        }

        // GET: Admin/AboutDescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutDescription aboutDescription = db.AboutDescriptions.Find(id);
            if (aboutDescription == null)
            {
                return HttpNotFound();
            }
            return View(aboutDescription);
        }

        // POST: Admin/AboutDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AboutID,Image,Title,Description")] AboutDescription aboutDescription,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                    {
                        if (aboutDescription.Image!=null)
                        {
                            System.IO.File.Delete(Server.MapPath("/Images/AboutImages/"+aboutDescription.Image));
                        }
                        aboutDescription.Image = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                        imgUp.SaveAs(Server.MapPath("/Images/AboutImages/" + aboutDescription.Image));
                    }

                teamAboutRepository.UpdateAbout(aboutDescription);
                teamAboutRepository.Save();
                return RedirectToAction("Index");
            }
            return View(aboutDescription);
        }

        // GET: Admin/AboutDescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutDescription aboutDescription = db.AboutDescriptions.Find(id);
            if (aboutDescription == null)
            {
                return HttpNotFound();
            }
            return View(aboutDescription);
        }

        // POST: Admin/AboutDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutDescription aboutDescription = db.AboutDescriptions.Find(id);
            db.AboutDescriptions.Remove(aboutDescription);
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
