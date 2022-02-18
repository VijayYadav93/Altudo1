using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBtc1.Feature.DetailPage.Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Publishing;
using Sitecore.SecurityModel;

namespace AltudoBtc1.Feature.DetailPage.Controllers
{
    public class ReviewFormController : Controller
    {
        // GET: ReviewForm
        [HttpGet]
        public ActionResult Index()
        {
            ReviewComment review = new ReviewComment();  
            return View("/Views/Altudo/DetailPage/ReviewForm.cshtml", review);
        }

        [HttpPost]
        public ActionResult Index(ReviewComment review)
        {
            var contextItem = Sitecore.Context.Item;

            //Get my db to create item
            var masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
            var webDB = Sitecore.Configuration.Factory.GetDatabase("web");

            //Get my Parent item
            var parentItem = masterDb.GetItem(contextItem.ID);

            //Get my templete
            ID templateID = new ID("{E6D9F1C5-949B-44E4-8B5D-821BA708DA35}");
            TemplateItem commentTemplate = masterDb.GetTemplate(templateID);

            //create my Item 
            using (new SecurityDisabler())
            {
                Item newCommentItem = parentItem.Add(review.Name, commentTemplate);
                newCommentItem.Editing.BeginEdit();
                newCommentItem["Name"] = review.Name;
                newCommentItem["EmailId"] = review.EmailId;
                newCommentItem["Rating"] = review.Rating.ToString();
                newCommentItem["Comment"] = review.Comment;
                newCommentItem.Editing.EndEdit();

                //publishing the newly created item
                PublishOptions publishOptions = new PublishOptions(masterDb, webDB, PublishMode.SingleItem, Sitecore.Context.Language, DateTime.Now);
                Publisher publisher = new Publisher(publishOptions);
                publisher.Options.RootItem = newCommentItem;
                publisher.Options.Deep = true;
                publisher.Options.Mode = PublishMode.SingleItem;
                publisher.Publish();
            };
                

            return View("/Views/Altudo/DetailPage/ThankYou.cshtml");
        }
    }
}