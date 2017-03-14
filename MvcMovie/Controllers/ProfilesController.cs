using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MvcMovie.Models;
using Microsoft.AspNet.Identity;

namespace MvcMovie.Controllers
{
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profiles/Details/5
        public ActionResult Details()
        {
            String id = User.Identity.GetUserId();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.SingleOrDefault(x => x.UserId == id);
            if (profile == null)
            {
                return RedirectToAction("Edit", "Profiles");
            }


            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit()
        {
            String id = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.SingleOrDefault(x => x.UserId == id);
            if (profile == null)
            {
                return View(new Profile());
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,FirsName,LastName,DOB,Address,City,State,Postal,Gender,Department,Designation")] Profile profile)
        {
            String UserId = profile.UserId;

            if (ModelState.IsValid)
            {
                var chk = db.Profile.SingleOrDefault(x => x.UserId == UserId);
                if (chk == null)
                {
                    db.Profile.Add(profile);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(chk).State = EntityState.Detached;
                    db.Entry(profile).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Details");

            }
            return View(profile);
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
