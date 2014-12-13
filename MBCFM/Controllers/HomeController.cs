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
            if (Helpers.GetUserType() == "Helpdesk Operator")
            {
                return RedirectToAction("Notification");
            }

            IEnumerable<MergedJob> jobs = null;
            //goes to database to get list of jobs for the current user
            using (var db = new JobsContext())
            {
                var username = Helpers.GetUserName();
                jobs = Helpers.GetMergedJobsQuery(db).Where(mj => mj.Job.UserName == username &&
                    ((mj.ExtraData.HelpDeskNotified.HasValue && !mj.ExtraData.HelpDeskNotified.Value) || mj.ExtraData == null)
                    && mj.Job.CurrentStatus.ToLower() != "closed").ToList();
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
        public ActionResult EditJob(int mbcJobNo, DateTime? arrivalTime, DateTime? departureTime, string materialsUsed, string costsOfMaterials, string materialsRequired, string durationToCompletion)
        {
            using (var db = new JobsContext())
            {
                var job = db.Jobs.Where(j => j.MbcJobNo == mbcJobNo).FirstOrDefault();
                if (job != null)
                {
                    job.ArrivalTime = arrivalTime;
                    job.DepartureTime = departureTime;
                    decimal costs;
                    decimal.TryParse(costsOfMaterials, out costs);
                    if (costs > 0)
                        job.CostsOfMaterials = costs;
                    job.DurationToCompletion = durationToCompletion;

                    //only update the extra data if we need to
                    if (!string.IsNullOrWhiteSpace(materialsRequired) || !string.IsNullOrWhiteSpace(materialsUsed))
                    {
                        var extraData = db.ExtraJobs.Where(ed => ed.MBCJobNo == mbcJobNo).FirstOrDefault();
                        if (extraData == null)
                        {
                            //doesn't exists so create a new entry
                            extraData = new ExtraJobData
                            {
                                MaterialsRequired = materialsRequired,
                                MaterialsUsed = materialsUsed,
                                MBCJobNo = mbcJobNo,
                                HelpDeskNotified = false
                            };
                            db.ExtraJobs.Add(extraData);
                        }
                        else
                        {
                            //exists so update the fields
                            extraData.MaterialsRequired = materialsRequired;
                        }
                    }

                    //saves database changes in one transaction
                    db.SaveChanges();
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
            IEnumerable<MergedJob> jobs = null;
            using (var db = new JobsContext())
            {
                jobs = Helpers.GetMergedJobsQuery(db).Where(mj => mj.ExtraData != null
                    && mj.ExtraData.HelpDeskNotified.HasValue && mj.ExtraData.HelpDeskNotified.Value).ToList();
            }
            return View(jobs);
        }

        [HttpPost]
        public ActionResult SendToHelpdesk(int mbcJobNo)
        {
            using (var db = new JobsContext())
            {
                var extraData = db.ExtraJobs.Where(ed => ed.MBCJobNo == mbcJobNo).FirstOrDefault();
                if (extraData == null)
                {
                    //doesn't exists so create a new entry
                    extraData = new ExtraJobData
                    {
                        MBCJobNo = mbcJobNo,
                        HelpDeskNotified = true
                    };
                    db.ExtraJobs.Add(extraData);
                }
                else
                {
                    //exists so update the field
                    extraData.HelpDeskNotified = true;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}