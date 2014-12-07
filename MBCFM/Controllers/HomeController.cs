using MBCFM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBCFM.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Job> jobs = null;
            //goes to database to get list of jobs for the current user
            using (var db = new JobsContext())
            {
                jobs = db.Jobs.Where(j => j.UserName == User.Identity.Name).ToList();
            }

            return View(jobs);
        }

        [HttpGet]
        public ActionResult ViewJob(int mbcJobNo)
        {
            JobView view = new JobView();
            using (var db = new JobsContext())
            {
                view.Job = db.Jobs.Where(j => j.MbcJobNo == mbcJobNo).FirstOrDefault();
                view.User = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            }

            return View(view);
        }

        [HttpPost]
        public ActionResult ViewJob(int mbcJobNo, DateTime? arrivalTime, DateTime? departureTime, string materialsUsed, string costsOfMaterials, string materialsRequired, string durationToCompletion)
        {
            using (var db = new JobsContext())
            {
                var job = db.Jobs.Where(j => j.MbcJobNo == mbcJobNo).FirstOrDefault();
                if (job != null)
                {
                    job.ArrivalTime = arrivalTime;
                    job.DepartureTime = departureTime;
                    job.MaterialsUsed = materialsUsed;
                    job.CostsOfMaterials = costsOfMaterials;
                    job.MaterialsRequired = materialsRequired;
                    job.DurationToCompletion = durationToCompletion;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}