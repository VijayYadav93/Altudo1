using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace AltudoBtc1.Feature.Common.ContentEditorCustom
{
    public class DisplayName : Command
    {
        public override void Execute(CommandContext context)
        {
            Item contextItem = context.Items[0];

            SheerResponse.Alert("Display Name of Item is -"+contextItem.DisplayName);
        }
    }
}