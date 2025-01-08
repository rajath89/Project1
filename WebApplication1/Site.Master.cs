using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Cast control
                var accountDropdown = (CustomControll.AccountDropdown)FindControl("AccountDropdown1");
                if (accountDropdown != null)
                {
                    // Add accounts
                    accountDropdown.Accounts.Add(new ListItem("Account 1", "1"));
                    accountDropdown.Accounts.Add(new ListItem("Account 2", "2"));
                    accountDropdown.Accounts.Add(new ListItem("Account 3", "3"));
                }
            }

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    // Update PalindromeControl's Text property
        //    PalindromeControl.Text = TextBox1.Text.Trim();
        //}
    }
}