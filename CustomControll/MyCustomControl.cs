using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace CustomControll
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:MyCustomControl runat=server></{0}:MyCustomControl>")]
    public class MyCustomControl : Control
    {
        [Category("Appearance")]
        [DefaultValue("")]
        [Description("The text to display in the control.")]
        public string Text { get; set; } = "";

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write($"<div style='color:green;'>{Text}</div>");
        }
    }
}
