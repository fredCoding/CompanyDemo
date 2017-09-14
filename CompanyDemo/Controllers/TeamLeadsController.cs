using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompanyDemo.Data;
using CompanyDemo.Models;

namespace CompanyDemo.Controllers
{
    public class TeamLeadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeamLeads
        public ActionResult Index()
        {
            var teamLeads = db.TeamLeads.Include(t => t.Team);
            return View(teamLeads.ToList());
        }

        // GET: TeamLeads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamLead teamLead = db.TeamLeads.Find(id);
            if (teamLead == null)
            {
                return HttpNotFound();
            }
            return View(teamLead);
        }

        // GET: TeamLeads/Create
        public ActionResult Create()
        {
            ViewBag.TeamLeadId = new SelectList(db.Teams, "TeamId", "Description");
            return View();
        }

        // POST: TeamLeads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamLeadId,Name,Salary,Workplace,Email,Phone")] TeamLead teamLead)
        {
            if (ModelState.IsValid)
            {
                db.TeamLeads.Add(teamLead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamLeadId = new SelectList(db.Teams, "TeamId", "Description", teamLead.TeamLeadId);
            return View(teamLead);
        }

        // GET: TeamLeads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamLead teamLead = db.TeamLeads.Find(id);
            if (teamLead == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamLeadId = new SelectList(db.Teams, "TeamId", "Description", teamLead.TeamLeadId);
            return View(teamLead);
        }

        // POST: TeamLeads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamLeadId,Name,Salary,Workplace,Email,Phone")] TeamLead teamLead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamLead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamLeadId = new SelectList(db.Teams, "TeamId", "Description", teamLead.TeamLeadId);
            return View(teamLead);
        }

        // GET: TeamLeads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamLead teamLead = db.TeamLeads.Find(id);
            if (teamLead == null)
            {
                return HttpNotFound();
            }
            return View(teamLead);
        }

        // POST: TeamLeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamLead teamLead = db.TeamLeads.Find(id);
            db.TeamLeads.Remove(teamLead);
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
