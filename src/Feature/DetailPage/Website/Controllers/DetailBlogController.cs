using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBtc1.Feature.DetailPage.Models;
using Sitecore.Web.UI.WebControls;

namespace AltudoBtc1.Feature.DetailPage.Controllers
{
    public class DetailBlogController : Controller
    {
        // GET: DetailBlog
        public ActionResult Index()
        {
            var context = Sitecore.Context.Item;
            DetailBlogModel detailmod = new DetailBlogModel()
            {
                 DetailBlog = new HtmlString(FieldRenderer.Render(context, "DetailBlog"))
            };

            return View("/Views/Altudo/Detailpage/DetailBlog.cshtml", detailmod);
        }
    }
}