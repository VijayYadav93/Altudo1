using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.Data.Fields;

namespace AltudoBtc1.Feature.Common.Controllers
{
    public class ArticlesController : ApiController
    {
        [Route("altudoapi/GetArticles")]
        public IHttpActionResult GetArticles()
        {
            var contextItem = Sitecore.Configuration.Factory.GetDatabase("master")
                .GetItem(new Sitecore.Data.ID("{C7D0D959-1B1F-4B13-9C0E-57EEF9EFDEDC}"));

            var listofArticles = contextItem.GetChildren()
                .Select(x => new JsonArticle
                {

                    Name = x.Name,
                    Title = x.Fields["Title"].Value,
                    Brief = x.Fields["Brief"].Value,
                    ImageUrl = getImageUrl(x)

                }).ToList();
            return Json(listofArticles);
            //return Json(listofArticles);
        }
        private string getImageUrl(Item item)
        {
            ImageField image = item.Fields["ArticleImage"];
            return MediaManager.GetMediaUrl(image.MediaItem);
        }

        [Route("altudoapi/GetCarouselImage")]
        public IHttpActionResult GetCarouselImage()
        {
            var contextItem = Sitecore.Configuration.Factory.GetDatabase("master")
                .GetItem(new Sitecore.Data.ID("{C7D0D959-1B1F-4B13-9C0E-57EEF9EFDEDC}"));

            var listofCarouselImage = contextItem.GetChildren()
                .Select(x => new JsonArticle
                {
                    Name = x.Name,
                    Title = x.Fields["Title"].Value,
                    Brief = x.Fields["Brief"].Value,
                    ImageUrl = getImageUrl(x)

                }).ToList();
            return Json(listofCarouselImage);
            //return Json(listofArticles);
        }
    }

    
    public class JsonArticle {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }

        public string ImageUrl { get; set; }
    }    
}
