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
    public class ReviewCommentController : Controller
    {
        // GET: ReviewComment
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            var listOfComment = contextItem.GetChildren()
                .Where(x => x.TemplateName=="ReviewComment")
                .Select(x => new ReviewComment
                {
                    Name = x.Fields["Name"].Value,
                    EmailId = x.Fields["EmailId"].Value,
                    Rating = Convert.ToInt32(x.Fields["Rating"].Value),
                    Comment = x.Fields["Comment"].Value,
                    PostedDate = GetDateTimeFromPostedDate(x, "PostedDate")
                })
                .ToList()
                .OrderByDescending(x=>x.PostedDate);

            return View("/Views/Altudo/DetailPage/ReviewComment.cshtml", listOfComment);
        }

        private DateTime GetDateTimeFromPostedDate(Item item,string fieldName)
        {
            DateField dateField = item.Fields[fieldName];
            return dateField.DateTime;
        }
    }
}