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
    public class HamkaransController : Controller
    {
        private GreenPayContext db = new GreenPayContext();

        private IHamkaranRepository hamkaranRepository;

        public HamkaransController()
        {
            hamkaranRepository=new HamkaranRepository(db);
        }

        // GET: Admin/Hamkarans
        public ActionResult Index()
        {
            return View(hamkaranRepository.GetAllHamkarans());
        }

        // GET: Admin/Hamkarans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hamkaran hamkaran = hamkaranRepository.GetHamkaranById(id.Value);
            if (hamkaran == null)
            {
                return HttpNotFound();
            }
            return View(hamkaran);
        }

        // GET: Admin/Hamkarans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hamkarans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,WebSite,ImageHamkaran")] Hamkaran hamkaran,HttpPostedFileBase imgHamkar)
        {
            if (ModelState.IsValid)
            {
                if (imgHamkar != null)
                {
                    hamkaran.ImageHamkaran = Guid.NewGuid() + Path.GetExtension(imgHamkar.FileName);
                    imgHamkar.SaveAs(Server.MapPath("/Images/ImageHamkar/" + hamkaran.ImageHamkaran));
                }
                hamkaranRepository.InsertHamkaran(hamkaran);
                hamkaranRepository.Save();
                return RedirectToAction("Index");
            }

            return View(hamkaran);
        }

        // GET: Admin/Hamkarans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hamkaran hamkaran = hamkaranRepository.GetHamkaranById(id.Value);
            if (hamkaran == null)
            {
                return HttpNotFound();
            }
            return View(hamkaran);
        }

        // POST: Admin/Hamkarans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,WebSite,ImageHamkaran")] Hamkaran hamkaran,HttpPostedFileBase imgHamkar)
        {
            if (ModelState.IsValid)
            {
                if(hamkaran.ImageHamkaran!=null)
                {
                    System.IO.File.Delete(Server.MapPath("/Images/ImageHamkar/" + hamkaran.ImageHamkaran));
                    if (imgHamkar.FileName!=null)
                    {
                        hamkaran.ImageHamkaran = Guid.NewGuid() + Path.GetExtension(imgHamkar.FileName);
                        imgHamkar.SaveAs(Server.MapPath("/Images/ImageHamkar/" + hamkaran.ImageHamkaran));
                    }
                }
                hamkaranRepository.UpdateHamkaran(hamkaran);
                hamkaranRepository.Save();
                return RedirectToAction("Index");
            }
            return View(hamkaran);
        }

        // GET: Admin/Hamkarans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hamkaran hamkaran = hamkaranRepository.GetHamkaranById(id.Value);
            if (hamkaran == null)
            {
                return HttpNotFound();
            }
            return View(hamkaran);
        }

        // POST: Admin/Hamkarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var hamkar = hamkaranRepository.GetHamkaranById(id);
            if (hamkar.ImageHamkaran!=null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/ImageHamkar/" + hamkar.ImageHamkaran));
            }
            hamkaranRepository.DeleteHamkaran(id);
            hamkaranRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                hamkaranRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
