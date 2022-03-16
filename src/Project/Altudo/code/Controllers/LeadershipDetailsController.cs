using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBtc1.Project.Altudo.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace AltudoBtc1.Project.Altudo.Controllers
{
    public class LeadershipDetailsController : Controller
    {
        // GET: LeadershipDetails
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            LeadershipDetails leadership;
            var renderingItem = RenderingContext.Current.Rendering.Item;
            if (renderingItem == null)
            {
                renderingItem = RenderingContext.Current.ContextItem;
                leadership = new LeadershipDetails();
            }
            else
            {
                LinkField linkfiled = renderingItem.Fields["SuggestedArticle"];
                var targetItem = linkfiled.TargetItem;

                leadership = new LeadershipDetails
                {
                    // we use FieldRenderer class for making experience editor value
                    Name = new HtmlString(FieldRenderer.Render(renderingItem, "Name")),
                    Designation = new HtmlString(renderingItem.Fields["Designation"].Value),
                    ContactNumber = new HtmlString(FieldRenderer.Render(renderingItem, "ContactNumber")),
                    ProfileBrief = new HtmlString(FieldRenderer.Render(renderingItem, "ProfileBrief")),
                    ProfilePicture = new HtmlString(FieldRenderer.Render(renderingItem, "ProfilePicture")),
                    SuggestedArticleUrl = LinkManager.GetItemUrl(targetItem),
                    SuggestedArticlText = targetItem.Fields["Title"].Value
                };
            }
            return View("/Views/Altudo/LeadershipDetails.cshtml",leadership);
        }
    }
}