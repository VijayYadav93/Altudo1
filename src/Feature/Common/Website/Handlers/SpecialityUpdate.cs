using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.SecurityModel;

namespace AltudoBtc1.Feature.Common.Handlers
{
    public class SpecialityUpdate
    {
        public void OnItemSave(object sender, EventArgs args)
        {
            Item savedItem = Event.ExtractParameter(args, 0) as Item;

            if (savedItem == null || !"master".Equals(savedItem.Database?.Name, StringComparison.OrdinalIgnoreCase))
                return;

            if (!savedItem.TemplateID.Equals(Templates.Article.ArticleTemplate))
                return;

            GroupedDroplinkField groupedDroplinkField = savedItem.Fields[Constants.Fields.SpecialtyName];
            var code = groupedDroplinkField.TargetItem.Fields[Templates.SpecialityMaster.Fields.SpecialityCodeMaster].Value;
            using(new SecurityDisabler())
            {
                savedItem.Editing.BeginEdit();
                savedItem.Fields[Templates.Article.Fields.SpecialityCodeArticle].Value = code;
                savedItem.Editing.EndEdit();
            }
        }
    }
}