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
        public ActionResult EditJob(int mbcJobNo, DateTime? arrivalTime, DateTime? departureTime, string materialsUsed, string costsOfMaterials, string materialsRequired, string durationToCompletion, string siteNotes)
        {
            using (var db = new JobsContext())
            {
                var job = db.Jobs.Where(j => j.MbcJobNo == mbcJobNo).FirstOrDefault();
                if (job != null)
                {
                    job.ArrivalTime = arrivalTime;
                    job.DepartureTime = departureTime;
                    job.siteNotes = siteNotes;
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
            var model = new NotificationView();
            using (var db = new JobsContext())
            {
                //we use 2 distinct queires to pull back the result we need for each collection
                //here we are using the base query defined in the helper (which bascially does an left outer join on the view and the extradata table)
                //the nice thing with linq is that is lazy loading so until to iterate through a collection (i.e. foreach) or run a set operation (.ToList())
                //it won't run a query. this means we can kepp adding filters, etc until we need to get the data :)

                //so the ToList on the end of this forces the entity framwork to go to the database and put the results in the jelpdeskJobs property of the model class
                model.HelpdeskJobs = Helpers.GetMergedJobsQuery(db).Where(mj => mj.ExtraData != null
                    && mj.ExtraData.HelpDeskNotified.HasValue && mj.ExtraData.HelpDeskNotified.Value && mj.Job.CurrentStatus !="Closed").ToList();

                //and the same here, we use the base query from the help with different filters and the tolist to set the property of the model
                model.OpenJobs=Helpers.GetMergedJobsQuery(db).Where(mj => (mj.ExtraData == null || (mj.ExtraData!=null && mj.ExtraData.HelpDeskNotified==false))
                    && mj.Job.CurrentStatus !="Closed").ToList();
            }
            return View(model);
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
                    Helpers.AddExtraJobData(db, extraData, mbcJobNo, true);

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