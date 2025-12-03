using System.Linq;
using System.Net;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class EducationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.Education.Include("StudentProfile").ToList();
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Education edu = db.Education.Find(id);
            if (edu == null) return HttpNotFound();

            return View(edu);
        }

        public ActionResult Create()
        {
            ViewBag.StundentProfileId = new SelectList(db.StudentProfile, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Education edu)
        {
            if (ModelState.IsValid)
            {
                db.Education.Add(edu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StundentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", edu.StudentProfileId);
            return View(edu);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Education edu = db.Education.Find(id);
            if (edu == null) return HttpNotFound();

            ViewBag.StundentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", edu.StudentProfileId);
            return View(edu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Education edu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edu).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StundentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", edu.StudentProfileId);
            return View(edu);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Education edu = db.Education.Find(id);
            if (edu == null) return HttpNotFound();

            return View(edu);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Education edu = db.Education.Find(id);
            db.Education.Remove(edu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}