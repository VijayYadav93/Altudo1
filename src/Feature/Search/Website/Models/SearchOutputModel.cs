using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace AltudoBtc1.Feature.Search.Models
{
    public class SearchOutputModel : SearchResultItem
    {
        [IndexField("title_t")]
        public string ArticleTitle { get; set; }

        [IndexField("brief_t")]
        public string ArticleBrief { get; set; }

        [IndexField("articleurl_s")]
        public string ArticleUrl { get; set; }

        [IndexField("articleimage_s")]
        public string ArticleImageUrl { get; set; }

        [IndexField("articlespeciality_s")]
        public string Articlespeciality { get; set; }
    }
}