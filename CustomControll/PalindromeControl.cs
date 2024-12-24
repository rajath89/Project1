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
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:PalindromeControl runat=server></{0}:PalindromeControl>")]
    public class PalindromeControl : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? string.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            if (string.IsNullOrEmpty(Text))
            {
                // Don't render anything if Text is empty
                output.Write("Enter a word above and click 'Check Palindrome'.");
                return;
            }

            if (IsPalindrome())
            {
                output.Write("This is a palindrome: <br />");
                output.Write("<FONT size=5 color=Blue>");
                output.Write("<B>");
                output.Write(Text);
                output.Write("</B>");
                output.Write("</FONT>");
            }
            else
            {
                output.Write("This is not a palindrome: <br />");
                output.Write("<FONT size=5 color=red>");
                output.Write("<B>");
                output.Write(Text);
                output.Write("</B>");
                output.Write("</FONT>");
            }
        }

        private bool IsPalindrome()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                string upperText = Text.ToUpper();
                char[] reversedChars = upperText.ToCharArray();
                Array.Reverse(reversedChars);
                string reversedText = new string(reversedChars);

                return upperText == reversedText;
            }

            return false;
        }
    }
}
