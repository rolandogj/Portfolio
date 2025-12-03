using System.Linq;
using System.Net;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.Projects.Include("StudentProfile").ToList();
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Projects project = db.Projects.Find(id);
            if (project == null) return HttpNotFound();

            return View(project);
        }

        public ActionResult Create()
        {
            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Projects project)
        { 
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", project.StudentProfileId);
            return View(project);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Projects project = db.Projects.Find(id);
            if (project == null) return HttpNotFound();
            
            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", project.StudentProfileId);
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Projects project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", project.StudentProfileId);
            return View(project);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Projects project = db.Projects.Find(id);
            if (project == null) return HttpNotFound();
            
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projects project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}