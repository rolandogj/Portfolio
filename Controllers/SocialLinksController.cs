using System.Linq;
using System.Net;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class SocialLinksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.SocialLink.ToList();
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            SocialLink link = db.SocialLink.Find(id);
            if (link == null) return HttpNotFound();

            return View(link);
        }

        public ActionResult Create()
        {
            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SocialLink link)
        {
            if (ModelState.IsValid)
            {
                db.SocialLink.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", link.StudentProfileId);
            return View(link);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            SocialLink link = db.SocialLink.Find(id);
            if (link == null) return HttpNotFound();

            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", link.StudentProfileId);
            return View(link);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SocialLink link)
        {
            if (ModelState.IsValid)
            {
                db.Entry(link).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentProfileId = new SelectList(db.StudentProfile, "Id", "FullName", link.StudentProfileId);
            return View(link);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            SocialLink link = db.SocialLink.Find(id);
            if (link == null) return HttpNotFound();
            
            return View(link);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialLink link = db.SocialLink.Find(id);
            db.SocialLink.Remove(link);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}