using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBtc1.Feature.DetailPage.Models;
using Sitecore.Web.UI.WebControls;

namespace AltudoBtc1.Feature.DetailPage.Controllers
{
    public class DetailPageController : Controller
    {
        // GET: DetailPage
        public ActionResult Index()
        {
            var context = Sitecore.Context.Item;
            Details details = new Details()
            {
                Title = new HtmlString(FieldRenderer.Render(context, "Title")),
                Description = new HtmlString(FieldRenderer.Render(context, "Description")),
                CardImage = new HtmlString(FieldRenderer.Render(context, "CardImage")),
            };
            return View("/Views/Altudo/Detailpage/Details.cshtml", details);
        }
    }
}