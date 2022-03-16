using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBtc1.Feature.DetailPage.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace AltudoBtc1.Feature.DetailPage.Controllers
{
    public class FeatureCommentsController : Controller
    {
        // GET: FeatureComments
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            var listOfComment = contextItem.GetChildren()
                .Where(x => x.TemplateName == "ReviewComment")
                .Select(x => new ReviewComment
                {
                    Name = x.Fields["Name"].Value,
                    EmailId = x.Fields["EmailId"].Value,
                    Rating = Convert.ToInt32(x.Fields["Rating"].Value),
                    Comment = x.Fields["Comment"].Value,
                    PostedDate = GetDateTimeFromPostedDate(x, "PostedDate")
                })
                .ToList()
                .Where(x => ApplyCommentsBusinessLogic(x.PostedDate))
                .OrderByDescending(x => x.PostedDate);


            return View("/Views/Altudo/DetailPage/ReviewComment.cshtml", listOfComment);
        }

        private DateTime GetDateTimeFromPostedDate(Item item, string fieldName)
        {
            DateField dateField = item.Fields[fieldName];
            return dateField.DateTime;
        }

        private bool ApplyCommentsBusinessLogic(DateTime postedDate)
        {
            var homeItemForSite = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            var commentSettingItem = homeItemForSite.Axes.GetDescendants()
                .FirstOrDefault(x => x.TemplateName == "TripCommentsSettings");

            //var settingsItem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID("{D1468A03-F254-4EDB-91E8-8FA59AB15EF7}"));

            DateField startDate = commentSettingItem.Fields["StartDate"];
            DateField endDate = commentSettingItem.Fields["EndDate"];
            return ((postedDate > startDate.DateTime) && (postedDate > startDate.DateTime));
        }
    }
}