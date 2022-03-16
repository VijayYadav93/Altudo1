using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AltudoBtc1.Feature.Search.Models;
using Sitecore.ContentSearch;

namespace AltudoBtc1.Feature.Search.Controllers
{
    public class StandardController : ApiController
    {
        [Route("altudoapi/StandardResult")]
        [HttpPost]
        public IHttpActionResult GetStandardSearchResult(SearchParam param)
        {
            var contextDB = Sitecore.Context.Database;
            List<StandardSearchResult> serachResults = new List<StandardSearchResult>();
            ISearchIndex searchIndex = ContentSearchManager.GetIndex($"sitecore_{contextDB.Name}_index");
            using (IProviderSearchContext searchContext = searchIndex.CreateSearchContext())
            {
                serachResults = searchContext.GetQueryable<SearchOutputModel>()
                                    .Where(x => x.TemplateName == "HealthArticle")
                                    .Where(x => x.ArticleTitle.Contains(param.searchKeyword) || x.ArticleBrief.Contains(param.searchKeyword))
                                    //.Where(x => x.ArticleBrief.Contains(param.searchKeyword))
                                    .Select(x => new StandardSearchResult
                                    {
                                        SearchTitle = x.ArticleTitle,
                                        SerachBrief = x.ArticleBrief,
                                        SearchTileUrl =x.ArticleUrl,
                                        SearchImageUrl =x.ArticleImageUrl,
                                        SearchSpeciality = x.Articlespeciality
                                    }).ToList();
            }
            return Json(serachResults);
        }
    }
}
