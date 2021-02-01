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
using System.Security;

namespace GreenPay.Areas.Admin.Controllers
{
    [Authorize]
    public class TeamMembersController : Controller
    {
        
        private GreenPayContext db = new GreenPayContext();

        private ITeamRepositoru TeamRepository;

        public TeamMembersController()
        {
            TeamRepository=new TeamMemberRepository(db); 
        }

        
        // GET: Admin/TeamMembers
        public ActionResult Index()
        {
            return View(TeamRepository.GetAllTeamMembers());
        }

        // GET: Admin/TeamMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // GET: Admin/TeamMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TeamMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamID,ImageName,FullName,Title")] TeamMember teamMember,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp!=null)
                {
                    teamMember.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/TeamMember/"+teamMember.ImageName));
                }
                TeamRepository.InsertMember(teamMember);
                TeamRepository.Save();
                return RedirectToAction("Index");
            }

            return View(teamMember);
        }

        // GET: Admin/TeamMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // POST: Admin/TeamMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamID,ImageName,FullName,Title")] TeamMember teamMember,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp !=null)
                {
                    if (teamMember.ImageName!=null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/TeamMember/" + teamMember.ImageName));
                    }
                    teamMember.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/TeamMember/" + teamMember.ImageName));
                }
                TeamRepository.UpdateMember(teamMember);
                TeamRepository.Save();
                return RedirectToAction("Index");
            }
            return View(teamMember);
        }

        // GET: Admin/TeamMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // POST: Admin/TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamMember teamMember = db.TeamMembers.Find(id);
            System.IO.File.Delete(Server.MapPath("/Images/TeamMember/" + teamMember.ImageName));
            db.TeamMembers.Remove(teamMember);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                TeamRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
