using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace CustomControll
{
    public class WelcomeLabel : Label
    {
        [Category("Behavior")]
        [DefaultValue("Guest")]
        [Description("The default user name to display when the user is not logged in.")]
        public string DefaultUserName { get; set; } = "Guest";

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            // Get the logged-in user's name if available
            string userName = Context?.User?.Identity?.IsAuthenticated == true
                ? Context.User.Identity.Name
                : DefaultUserName;

            // Append the user name to the text property
            Text = $"{Text}, {userName}!";

            // Call the base class's Render method
            base.Render(writer);
        }
    }
}
