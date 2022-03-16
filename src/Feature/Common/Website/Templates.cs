using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace AltudoBtc1.Feature.Common
{
    public class Templates
    {
        public struct Article
        {
            public static readonly ID ArticleTemplate = new ID("{7C45EF97-EB33-4BA0-9F82-F6D5A3AF226F}");
            public struct Fields
            {
                public static readonly ID SpecialityCodeArticle = new ID("{8FA05CF8-6E1A-4EE8-BFDC-5939A41A26DE}");
            }
        }
        

        public struct SpecialityMaster
        {
            public static readonly ID SpecialityTemplateID = new ID("{853CFE2E-BE78-4558-B69A-94716D443C27}");
            public struct Fields
            {
                public static readonly ID SpecialityCodeMaster = new ID("{29CA733F-D1E0-4AE9-8AE8-3B9CBA49758A}");
            }
        }
    }
}