using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using Sitecore.Mvc.Presentation;

namespace AltudoBtc1.Feature.Common.Resolvers
{
    public class PatientRecordsResolver : RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            //access your context item
            //create json object of your item fields. 
            //use process items method to populate your json object and return

            var contextItem = GetContextItem(rendering, renderingConfig);
            MultilistField patirntRecord = contextItem.Fields["records"];

            JObject jobject = new JObject() {
                ["records"]= (JToken)new JArray()
            };
            var patientRecordItems = patirntRecord
                .GetItems()
                .Select(x=>ExtractRecordFieldFromItem(x)).ToList();

            jobject["records"] = ProcessItems(patientRecordItems, rendering, renderingConfig);
            
            return jobject;
        }

        private Item ExtractRecordFieldFromItem(Item item)
        {
            var fackID = new ID();
            //create an item definition
            var def = new ItemDefinition
                (fackID,
                 item.Name,
                 new ID("{87853827-08EB-4AA4-9A17-293800E644C2}"),
                 ID.Null);

            //extract fields
            var fields = new FieldList();
            fields.Add(new ID("{FE7F1C14-7F50-485B-AB40-A04774E968AF}"),item.Fields["prescription"].Value);
            //assemble the item data
            var data = new ItemData(def, Language.Current, Sitecore.Data.Version.First, fields);

            //instanting using the definition and data
            var resultItem = new Item(fackID,data,Sitecore.Context.Database);
            return resultItem;
        }
    }
}