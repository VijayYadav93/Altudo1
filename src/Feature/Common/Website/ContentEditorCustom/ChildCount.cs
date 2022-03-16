using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace AltudoBtc1.Feature.Common.ContentEditorCustom
{
    public class ChildCount : Command
    {
        public override void Execute(CommandContext context)
        {
            Item contextItem = context.Items[0];
            if (!(contextItem is null))
            {
                if (contextItem.HasChildren)
                    SheerResponse.Alert($"Child count is {contextItem.GetChildren().Count}");
                else
                {
                    SheerResponse.Alert($"Child Item is not avilable");
                }
            }
            

        }
    }
}