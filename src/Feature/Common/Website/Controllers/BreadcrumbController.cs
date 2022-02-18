using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBtc1.Feature.Common.Models;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
//using AltudoBtc1.Feature.DetailPage.Models;


namespace AltudoBtc1.Feature.Common.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            //List<BreadcrumbNav> navList = new List<BreadcrumbNav>();

            var breadcrumbList = contextItem.Axes.GetAncestors()
                .Select(x => new BreadcrumbNav
                {
                    NavTitle = x.Name,
                    NavURL = LinkManager.GetItemUrl(x,new ItemUrlBuilderOptions { LowercaseUrls = true})
                })
                .ToList()
                .Concat(new List<BreadcrumbNav>() 
                {
                    new BreadcrumbNav 
                    {
                        NavTitle= contextItem.Name, 
                        NavURL = LinkManager.GetItemUrl(contextItem,new ItemUrlBuilderOptions { LowercaseUrls =true})
                    } 
                });

            return View("/Views/Altudo/Common/Breadcrumb.cshtml", breadcrumbList);
        }
    }
}