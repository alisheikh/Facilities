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
            if (Helpers.GetUserType() == "Helpdesk Operator" || Helpers.GetUserType() == "Administrator")
            {
                return RedirectToAction("Notification");
            }

            IEnumerable<MergedJob> jobs = null;
            //goes to database to get list of jobs for the current user
            using (var db = new JobsContext())
            {
                var username = Helpers.GetUserName();
                jobs = Helpers.GetMergedJobsQuery(db).Where(mj => mj.Job.UserName == username 
                    && !(mj.Job.CurrentStatus.ToLower() == "closed" || mj.Job.CurrentStatus.ToLower() == "resolved by engineer")).ToList();
            }

            return View(jobs);
        }

        [HttpGet]
        public ActionResult EditJob(int mbcJobNo)
        {
            if (Helpers.GetUserType() == "Helpdesk Operator")
            {
                return RedirectToAction("Notification");
            }
            JobView view = new JobView();
            using (var db = new JobsContext())
            {
                var username = Helpers.GetUserName();
                view.JobData = Helpers.GetMergedJobsQuery(db).Where(mj => mj.Job.MbcJobNo == mbcJobNo).FirstOrDefault();
                view.User = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            }

            return View(view);
        }

        [HttpPost]
        public ActionResult EditJob(int mbcJobNo, string arrivalTime, string departureTime, string materialsUsed, string costOfMaterials, string materialsRequired, string siteNotes, string tableName)
        //public ActionResult EditJob(int mbcJobNo, DateTime? arrivalTime, DateTime? departureTime, string materialsUsed, string costsOfMaterials, string materialsRequired, string durationToCompletion, string siteNotes)
        {
            using (var db = new JobsContext())
            {
                var job = db.Jobs.Where(j => j.MbcJobNo == mbcJobNo).FirstOrDefault();
                if (job != null)
                {

                    db.Database.ExecuteSqlCommand("update " + tableName +
                        " set siteNotes = '" + siteNotes + "'" +
                        " ,timeOnSite = '" + arrivalTime + "'" +
                        " ,timeOffSite = '" + departureTime + "'" + 

                        "where [MBC Job No] = " +  mbcJobNo);

                }
            

                if (Request.Form["resolve"] != null)
                {

                db.Database.ExecuteSqlCommand("update " + tableName +
                        " set currentStatus = 'Resolved by Engineer'" +
                        "where [MBC Job No] = " + mbcJobNo);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult ViewJob(int mbcJobNo)
        {
            var view = new JobView();
            using (var db = new JobsContext())
            {
                var username = Helpers.GetUserName();
                view.JobData = Helpers.GetMergedJobsQuery(db).Where(mj => mj.Job.MbcJobNo == mbcJobNo).FirstOrDefault();
                view.User = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            }

            return View(view);
        }

        public ActionResult Notification()
        {
            if (Helpers.GetUserType() == "Sub Contractor")
            {
                return RedirectToAction("Index");
            }
            var model = new NotificationView();
            using (var db = new JobsContext())
            {
                //we use 2 distinct queires to pull back the result we need for each collection
                //here we are using the base query defined in the helper (which bascially does an left outer join on the view and the extradata table)
                //the nice thing with linq is that is lazy loading so until to iterate through a collection (i.e. foreach) or run a set operation (.ToList())
                //it won't run a query. this means we can kepp adding filters, etc until we need to get the data :)

                //so the ToList on the end of this forces the entity framwork to go to the database and put the results in the jelpdeskJobs property of the model class
                model.HelpdeskJobs = Helpers.GetMergedJobsQuery(db).Where(mj => mj.Job.CurrentStatus.ToLower() == "resolved by engineer").ToList();

                model.OpenJobs = Helpers.GetMergedJobsQuery(db).Where(mj => !(mj.Job.CurrentStatus.ToLower() == "resolved by engineer" || mj.Job.CurrentStatus.ToLower() == "closed")).ToList();
            }
            return View(model);
        }


    }
}