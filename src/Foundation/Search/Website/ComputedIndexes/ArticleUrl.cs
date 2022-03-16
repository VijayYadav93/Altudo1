using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using Sitecore.Sites;

namespace Altudobtc1.Foundation.Search.ComputedIndexes
{
    public class ArticleUrl : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item sitecoreItem = indexable as SitecoreIndexableItem;
            if (sitecoreItem == null)
                return null;

            if (sitecoreItem.TemplateID != Templates.Articles.ArticleTemplate)
                return null;

            var siteContext = SiteContextFactory.GetSiteContext("altudoapp");
            Sitecore.Context.Site = siteContext;
            Sitecore.Context.Item = sitecoreItem;

            ItemUrlBuilderOptions itemUrlBuilder = new ItemUrlBuilderOptions
            {
                SiteResolving = true,
                AlwaysIncludeServerUrl = false,
                LowercaseUrls = true
            };
          var articleurl = LinkManager.GetItemUrl(sitecoreItem , itemUrlBuilder);
            return articleurl;

        }
    }
}