using System.Linq;
using System.Net;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class StudentProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentProfiles
        public ActionResult Index()
        {
            return View(db.StudentProfile.ToList());
        }

        // GET: StudentProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            StudentProfile profile = db.StudentProfile.Find(id);
            if (profile == null) return HttpNotFound();
            
            return View(profile);
        }

        // GET: StudentProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentProfiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentProfile profile)
        {
            if (ModelState.IsValid)
            {
                db.StudentProfile.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: StudentProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            StudentProfile profile = db.StudentProfile.Find(id);
            if (profile == null) return HttpNotFound();
            
            return View(profile);
        }

        // POST: StudentProfile/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentProfile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: StudentProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            StudentProfile profile = db.StudentProfile.Find(id);
            if (profile == null) return HttpNotFound();
            
            return View(profile);
        }

        // POST: StudentProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentProfile profile = db.StudentProfile.Find(id);
            db.StudentProfile.Remove(profile);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}