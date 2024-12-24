using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CustomControll
{
    [DefaultProperty("Percentage")]
    [ToolboxData("<{0}:ProgressBar runat=server></{0}:ProgressBar>")]
    public class ProgressBar : WebControl
    {
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("The percentage of progress to display (0 to 100).")]
        public int Percentage
        {
            get
            {
                object val = ViewState["Percentage"];
                return val == null ? 0 : (int)val;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Percentage", "Value must be between 0 and 100.");
                ViewState["Percentage"] = value;
            }
        }

        [Category("Appearance")]
        [DefaultValue("#4caf50")]
        [Description("The color of the progress bar.")]
        public string BarColor
        {
            get => (string)(ViewState["BarColor"] ?? "#4caf50");
            set => ViewState["BarColor"] = value;
        }

        [Category("Appearance")]
        [DefaultValue("#000000")]
        [Description("The border color of the progress bar.")]
        public string BorderColor
        {
            get => (string)(ViewState["BorderColor"] ?? "#000000");
            set => ViewState["BorderColor"] = value;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            // Outer container (border)
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");
            //writer.AddStyleAttribute(HtmlTextWriterStyle.Border, $"1px solid {BorderColor}");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "20px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "relative");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            // Inner progress bar
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, $"{Percentage}%");
            writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, BarColor);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "100%");
            writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "#fff");
            //writer.AddStyleAttribute(HtmlTextWriterStyle.LineHeight, "20px");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            // Display percentage text
            writer.Write($"{Percentage}%");

            // End inner progress bar
            writer.RenderEndTag();

            // End outer container
            writer.RenderEndTag();
        }
    }
}
