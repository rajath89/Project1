using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CustomControll
{
    public class CalendarControl : WebControl, INamingContainer
    {
        public List<DateTime> HighlightedDates { get; set; } = new List<DateTime>();

        public DateTime CurrentDate { get; set; } = DateTime.Today;

        protected override void CreateChildControls()
        {
            // Add month navigation
            Button prevButton = new Button { Text = "<< Previous", CommandName = "Prev" };
            prevButton.Command += Navigation_Command;
            Controls.Add(prevButton);

            Button nextButton = new Button { Text = "Next >>", CommandName = "Next" };
            nextButton.Command += Navigation_Command;
            Controls.Add(nextButton);

            // Add calendar table
            Table calendarTable = new Table { CssClass = "calendar-table" };
            calendarTable.Rows.Add(CreateHeaderRow());

            DateTime startDate = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            startDate = startDate.AddDays(-(int)startDate.DayOfWeek);

            for (int i = 0; i < 6; i++) // Maximum 6 weeks in a month view
            {
                calendarTable.Rows.Add(CreateWeekRow(startDate));
                startDate = startDate.AddDays(7);
            }

            Controls.Add(calendarTable);
        }

        private TableRow CreateHeaderRow()
        {
            TableRow headerRow = new TableRow();
            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            foreach (var day in days)
            {
                TableCell cell = new TableCell { Text = day, CssClass = "calendar-header" };
                headerRow.Cells.Add(cell);
            }

            return headerRow;
        }

        private TableRow CreateWeekRow(DateTime startDate)
        {
            TableRow weekRow = new TableRow();

            for (int i = 0; i < 7; i++)
            {
                TableCell cell = new TableCell { CssClass = "calendar-cell" };
                DateTime currentDate = startDate.AddDays(i);

                if (currentDate.Month == CurrentDate.Month)
                {
                    cell.Text = currentDate.Day.ToString();

                    if (HighlightedDates.Contains(currentDate))
                    {
                        cell.CssClass += " highlighted";
                    }
                }
                else
                {
                    cell.CssClass += " other-month";
                }

                weekRow.Cells.Add(cell);
            }

            return weekRow;
        }

        private void Navigation_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Prev")
                CurrentDate = CurrentDate.AddMonths(-1);
            else if (e.CommandName == "Next")
                CurrentDate = CurrentDate.AddMonths(1);

            Controls.Clear();
            ChildControlsCreated = false;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();
            base.Render(writer);
        }
    }
}
