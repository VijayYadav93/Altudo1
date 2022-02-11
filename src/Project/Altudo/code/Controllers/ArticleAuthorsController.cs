using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBtc1.Project.Altudo.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;

namespace AltudoBtc1.Project.Altudo.Controllers
{
    public class ArticleAuthorsController : Controller
    {
        // GET: ArticleAuthors
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            List<Author> authors = new List<Author>();
            MultilistField authoredby = contextItem.Fields["AuthoreBy"];

          authors =   authoredby.GetItems()
                .Select(X => new Author
                {
                    Name = X.Fields["TraineeName"].Value,
                    Url = LinkManager.GetItemUrl(X)
                }).ToList();

            return View("/Views/Altudo/ArticleAuthors.cshtml",authors);
        }
    }
}