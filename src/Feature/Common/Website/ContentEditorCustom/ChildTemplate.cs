using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;

namespace AltudoBtc1.Feature.Common.ContentEditorCustom
{
    public class ChildTemplate : Command
    {
        public override void Execute(CommandContext context)
        {
            Item contextItem = context.Items[0];

           // contextItem.GetChildren().Count;
        }
    }
}