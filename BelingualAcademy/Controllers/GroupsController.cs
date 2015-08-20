using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BelingualAcademy.Models;
using PagedList;

namespace BelingualAcademy.Controllers
{
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Groups
        public ActionResult Index(GroupSearchModel model)
        {
            //if (model != null && model.CourseId !=null )
            //{
                var groups = db.Groups.Include(g => g.Course).Include(g => g.Teacher);
                var courses = db.Courses.ToList();
                courses.Add(new Course { ID=0, Name="- All -" });
                ViewBag.CourseID = new SelectList(courses, "ID", "Name", 0);
            //    return View(groups.ToList());
            //}
            //else
            //{
            //    var groups = db.Groups.Include(g => g.Course).Include(g => g.Teacher);
            //    return PartialView(groups.Where(g => g.CourseID == course.ID).ToList());
            //}

            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                var results = groups
                    .Where(g => g.CourseID == model.CourseID || model.CourseID == 0);

                var pageIndex = model.Page ?? 1;
                model.SearchResults = results.OrderBy(g => g.Course.Name).ToPagedList(pageIndex, 10);
            }
            return View(model);
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name");
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,CourseID,TeacherID,Period,StartDate,EndDate")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", group.CourseID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name", group.TeacherID);
            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", group.CourseID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name", group.TeacherID);
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,CourseID,TeacherID,Period,StartDate,EndDate")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", group.CourseID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name", group.TeacherID);
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
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
