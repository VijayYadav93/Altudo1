using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBtc1.Project.Altudo.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace AltudoBtc1.Project.Altudo.Controllers
{
    public class ListOfLeadersController : Controller
    {
        // GET: ListOfLeaders
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            List<LeadershipDetails> listofleader = new List<LeadershipDetails>();

            MultilistField leaders = contextItem.Fields["Leaders"];

            listofleader = leaders.GetItems()
                .Select(x => new LeadershipDetails
                {
                    Name = new HtmlString(FieldRenderer.Render(x, "Name")),
                    Designation = new HtmlString(FieldRenderer.Render(x, "Designation")),
                    ContactNumber = new HtmlString(FieldRenderer.Render(x, "ContactNumber")),
                    ProfileBrief = new HtmlString(FieldRenderer.Render(x, "ProfileBrief")),
                    ProfilePicture = new HtmlString(FieldRenderer.Render(x, "ProfilePicture")),
                    //SuggestedArticleUrl = LinkManager.GetItemUrl(targetItem),
                    //SuggestedArticlText = targetItem.Fields["Title"].Value
                }).ToList();
            return View("/Views/Altudo/ListOfLeaders.cshtml", listofleader);
            
        }
    }
}