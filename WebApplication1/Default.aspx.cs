using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Optionally set properties dynamically
                WelcomeLabel1.Text = "Welcome";
                WelcomeLabel1.DefaultUserName = "Visitor";
                //ProgressBar2.Percentage = 20; // Set initial value dynamically

                var data = new List<Person>
                {
                    new Person { Id = 1, Name = "John Doe", Age = 25 },
                    new Person { Id = 2, Name = "Jane Smith", Age = 30 },
                    new Person { Id = 3, Name = "Sam Wilson", Age = 28 },
                    new Person { Id = 4, Name = "Alice Johnson", Age = 35 },
                    new Person { Id = 5, Name = "Bob Brown", Age = 40 },
                    new Person { Id = 6, Name = "Chris Evans", Age = 22 },
                    new Person { Id = 7, Name = "Emma Watson", Age = 29 },
                    new Person { Id = 8, Name = "David Beckham", Age = 38 },
                    new Person { Id = 9, Name = "Kate Winslet", Age = 33 },
                    new Person { Id = 10, Name = "Will Smith", Age = 50 }
                };

                //var accountDropdown = (CustomControll.AccountDropdown)FindControl("AccountDropdown1");
                //if (accountDropdown != null)
                //{
                //    // Add accounts
                //    accountDropdown.Accounts.Add(new ListItem("Account 1", "1"));
                //    accountDropdown.Accounts.Add(new ListItem("Account 2", "2"));
                //    accountDropdown.Accounts.Add(new ListItem("Account 3", "3"));
                //}

                //DynamicGrid1.DataSource = data;
            }

            //Calendar.HighlightedDates = new List<DateTime>
            //{
            //     new DateTime(2024, 12, 25), // Christmas
            //    new DateTime(2024, 1, 1),  // New Year
            //};


        }

        //protected void btnIncrease_Click(object sender, EventArgs e)
        //{
        //    // Increment progress dynamically
        //    ProgressBar2.Percentage = Math.Min(ProgressBar2.Percentage + 10, 100);
        //}




        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}