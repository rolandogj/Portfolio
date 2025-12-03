using System.Linq;
using System.Net;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class SkillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.Skills.Include("StudentProfile").ToList();
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Skills Skills = db.Skills.Find(id);
            if (Skills == null) return HttpNotFound();
            
            return View(Skills);
        }

        public ActionResult Create()
        {
            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Skills skill)
        {
            if (ModelState.IsValid)
            {
                db.Skills.Add(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", skill.StudentProfileId);
            return View(skill);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Skills skill = db.Skills.Find(id);
            if (skill == null) return HttpNotFound();
            
            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", skill.StudentProfileId);
            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Skills skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", skill.StudentProfileId);
            return View(skill);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Skills skill = db.Skills.Find(id);
            if (skill == null) return HttpNotFound();
            
            return View(skill);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skills skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}