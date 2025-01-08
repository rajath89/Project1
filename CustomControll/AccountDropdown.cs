using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CustomControll
{
    public class AccountDropdown : CompositeControl
    {
        private DropDownList _dropdown;
        private Label _selectedAccountLabel;

        // Public property to expose selected value
        public string SelectedAccount
        {
            get => _dropdown?.SelectedValue ?? string.Empty;
            set
            {
                EnsureChildControls();
                if (_dropdown.Items.FindByValue(value) != null)
                {
                    _dropdown.SelectedValue = value;
                }
            }
        }

        // Property to bind list of accounts
        public ListItemCollection Accounts
        {
            get
            {
                EnsureChildControls();
                return _dropdown.Items;
            }
        }

        protected override void CreateChildControls()
        {
            // Clear existing controls
            Controls.Clear();

            // Create dropdown
            _dropdown = new DropDownList
            {
                ID = "ddlAccounts",
                AutoPostBack = true
            };
            _dropdown.SelectedIndexChanged += Dropdown_SelectedIndexChanged;

            // Create label
            _selectedAccountLabel = new Label
            {
                ID = "lblSelectedAccount",
                Text = "Selected Account: None",
                CssClass = "selected-account-label"
            };

            // Add controls to composite control
            Controls.Add(_dropdown);
            Controls.Add(new LiteralControl("<br/>"));
            Controls.Add(_selectedAccountLabel);
        }

        private void Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedAccountLabel.Text = "Selected Account: " + _dropdown.SelectedValue;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();
            base.Render(writer);
        }
    }
}
