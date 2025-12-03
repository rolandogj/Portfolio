using System.Linq;
using System.Net;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.Experience.Include("StudentProfile").ToList();
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Experience exp = db.Experience.Find(id);
            if (exp == null) return HttpNotFound();

            return View(exp);
        }

        public ActionResult Create()
        {
            ViewBag.StundentProfileId = new SelectList(db.StudentProfile, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Experience exp)
        {
            if (ModelState.IsValid)
            {
                db.Experience.Add(exp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StundentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", exp.StudentProfileId);
            return View(exp);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Experience exp = db.Experience.Find(id);
            if (exp == null) return HttpNotFound();

            ViewBag.StundentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", exp.StudentProfileId);
            return View(exp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Experience exp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StundentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", exp.StudentProfileId);
            return View(exp);
        }

        public ActionResult Delete(int? id)
        { 
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Experience exp = db.Experience.Find(id);
            if (exp == null) return HttpNotFound();

            return View(exp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteCpnfirmed (int id)
        {
            Experience exp = db.Experience.Find(id);
            db.Experience.Remove(exp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}