using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Altudobtc1.Foundation.Search
{
    public static class Templates
    {
        public struct Articles
        {
            public static readonly ID ArticleTemplate = new ID("{7C45EF97-EB33-4BA0-9F82-F6D5A3AF226F}");

            public struct Fields
            {
                public static readonly ID SpecialityName = new ID("{56A237B5-22BF-40F8-8359-B852CCB15DAE}");            
            }

        }
        public struct SpecialityMaster
        {
            public static readonly ID SpecialityMasterTemplet = new ID("{853CFE2E-BE78-4558-B69A-94716D443C27}");

            public struct Fields
            {
                public static readonly ID SpecialityNameFromMaster = new ID("{ECF1BFC9-3E08-4C03-B2CB-8F02A86A5421}");
            }
        }

    }
}