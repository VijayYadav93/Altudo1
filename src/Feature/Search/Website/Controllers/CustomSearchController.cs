using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;

namespace AltudoBtc1.Feature.Search.Controllers
{
    public class CustomSearchController : ApiController
    {
        [Route("altudoapi/handlesearch")]
        [HttpPost]
        public IHttpActionResult HandleSearch(SearchParam param)
        {

            #region Sample Data
            SearchResult searchResult1 = new SearchResult
            {
                SearchTitle ="Sample Title -1 ",
                SearchBrief = "Sample Description - 1",
                SearchTileUrl = "http://http://altudoapp.dev.local/"
            };
            SearchResult searchResult2 = new SearchResult
            {
                SearchTitle = "Sample Title -2 ",
                SearchBrief = "Sample Description-2",
                SearchTileUrl = "http://http://altudoapp.dev.local/"
            };
            List<SearchResult> searchResults = new List<SearchResult>();
            searchResults.Add(searchResult1);
            searchResults.Add(searchResult2);
            #endregion

            var contextDB = Sitecore.Context.Database;
            //get index instance
            ISearchIndex searchIndex = ContentSearchManager.GetIndex($"sitecore_{contextDB.Name}_index");

            using(IProviderSearchContext searchContext = searchIndex.CreateSearchContext())
            {
                var searchResultFormSolr = searchContext.GetQueryable<SearchResultItem>()
                                            .Where(x => x.TemplateName == "HealthArticle")
                                            .Where(x => x.Content.Contains(param.searchKeyword))
                                            .Select(x => new SearchResult
                                            {
                                                SearchTitle = Convert.ToString(x.Fields["title_t"]),
                                                SearchBrief = Convert.ToString(x.Fields["brief_t"]),
                                            }).ToList();
                searchResults = searchResultFormSolr;
            }
            //create search context

            //do query


            return Json(searchResults);
        }
    }
    public class SearchResult
    {
        public string SearchTitle { get; set; }
        public string SearchBrief { get; set; }
        public string SearchTileUrl { get; set; }
    }
    public class SearchParam
    {
        public string searchKeyword { get; set; }
    }



}