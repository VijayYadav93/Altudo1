using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AltudoBtc1.Feature.Search.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;

namespace AltudoBtc1.Feature.Search.Controllers
{
    public class SearchWithPredicateController : ApiController
    {
        [Route("altudoapi/GetSearchResultForPredicate")]
        public IHttpActionResult GetSearchResultForPredicate(SearchParam param)
        {
            List<StandardSearchResult> searchResult = new List<StandardSearchResult>();
            var contextDB = Sitecore.Context.Database;
            ISearchIndex searchIndex = ContentSearchManager.GetIndex($"sitecore_{contextDB.Name}_index");
            var searchPredicate = GetSearchPredicate(param.searchKeyword);
            using (IProviderSearchContext searchContext = searchIndex.CreateSearchContext())
            {
                searchResult = searchContext.GetQueryable<SearchOutputModel>()
                                .Where(searchPredicate)
                               .Select(x => new StandardSearchResult
                               {
                                   SearchTitle = x.ArticleTitle,
                                   SerachBrief = x.ArticleBrief
                               }).ToList();
            }
            return Json(searchResult);
        }

        public static Expression<Func<SearchOutputModel,bool>> GetSearchPredicate(string searchTerm)
        {
            var predicate = PredicateBuilder.True<SearchOutputModel>();
            predicate = predicate.Or(x => x.TemplateName == "HealthArticle");
            predicate = predicate.Or(x => x.ArticleTitle.Contains(searchTerm));
            predicate = predicate.Or(x => x.ArticleBrief.Contains(searchTerm));
            return predicate;
        }        
    }
}
