using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI.WebControls;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using Sitecore.Resources.Media;
using Sitecore.Sites;

namespace Altudobtc1.Foundation.Search.ComputedIndexes
{
    public class ArticleImage : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item sitecoreItem = indexable as SitecoreIndexableItem;
            if (sitecoreItem == null)
                return null;

            if (sitecoreItem.TemplateName != "HealthArticle")
                return null;

            var siteContext = SiteContextFactory.GetSiteContext("altudoapp");
            Sitecore.Context.Site = siteContext;
            Sitecore.Context.Item = sitecoreItem;

            ImageField imageField = sitecoreItem.Fields["ArticleImage"];
            var mediaurl = MediaManager.GetMediaUrl(imageField.MediaItem);
            return mediaurl;

        }
    }
}