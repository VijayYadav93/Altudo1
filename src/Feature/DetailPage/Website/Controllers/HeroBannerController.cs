using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBtc1.Feature.DetailPage.Models;
using Sitecore.Web.UI.WebControls;

namespace AltudoBtc1.Feature.DetailPage.Controllers
{
    public class HeroBannerController : Controller
    {
        // GET: HeroBanner
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            HeroBanner herobanner = new HeroBanner();
            herobanner.HeroImage = new HtmlString(FieldRenderer.Render(contextItem, "HeroImage"));
            return View("/Views/Altudo/Detailpage/HeroBanner.cshtml", herobanner);
        }
    }
}