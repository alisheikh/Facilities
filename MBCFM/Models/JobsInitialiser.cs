using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MBCFM.Models
{
    public class JobsInitialiser : DropCreateDatabaseIfModelChanges<JobsContext>
    {
        protected override void Seed(JobsContext context)
        {
            context.Users.Add(new User
                                {
                                    UserName = "Admin",
                                    Password = "password",
                                    FullName = "Site Administrator"
                                });
            base.Seed(context);
        }
    }
}