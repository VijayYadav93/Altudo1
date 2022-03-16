using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Pipelines.HttpRequest;

namespace AltudoBtc1.Feature.Common.Pipelines
{
    public class PageNotFoundResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            /*If the URL start with SiteCore it is ignoring it and if the URL having the file
            Path and that is resolving your system file directly it is ignoring it
             and if URL equivalent to the any API it ig ignoring it*/
            if (args.Url.FilePath.Contains("/sitecore") || File.Exists(args.Url.FilePath) || args.Url.FilePath.Contains("altudoapi"))
                return;

            //Fetch the contextItem
            var contextItem = Sitecore.Context.Item;
            //Check contextItem if null
            if (contextItem is null)
            {
                //if null fetch pagenotfound Item 
                var pageNotFountItem = Sitecore.Context.Database.GetItem(new ID("{8B08CCAC-6EB5-497B-893A-386789EAE6C5}"));
                //Set contextItem with pagenotfoundItem
                Sitecore.Context.Item = pageNotFountItem;
            }
        }
    }
}