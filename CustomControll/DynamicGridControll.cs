using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CustomControll
{

    [DefaultProperty("DataSource")]
    [ToolboxData("<{0}:DynamicGrid runat=server></{0}:DynamicGrid>")]
    public class DynamicGridControll : CompositeControl
    {
        private GridView gridView;

        [Category("Data")]
        [Description("The data source to bind to the grid.")]
        public IEnumerable DataSource { get; set; }

        [Category("Appearance")]
        [Description("The number of items to display per page.")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;

        [Browsable(false)]
        public int CurrentPageIndex
        {
            get => ViewState["CurrentPageIndex"] != null ? (int)ViewState["CurrentPageIndex"] : 0;
            set => ViewState["CurrentPageIndex"] = value;
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();

            // Create the GridView
            gridView = new GridView
            {
                AllowSorting = true,
                AutoGenerateColumns = true,
                CssClass = "dynamic-grid",
                AllowPaging = true,
                PageSize = PageSize,
                PagerSettings = { Mode = PagerButtons.Numeric }
            };

            gridView.Sorting += GridView_Sorting;
            gridView.PageIndexChanging += GridView_PageIndexChanging;

            Controls.Add(gridView);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (DataSource != null)
            {
                // Paginate the data source manually
                var pagedData = PaginateData(DataSource);
                gridView.DataSource = pagedData;
                gridView.DataBind();
            }
        }

        private void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (DataSource is IList list)
            {
                var dataView = ((IEnumerable)list).Cast<object>().AsQueryable();
                DataSource = e.SortDirection == SortDirection.Ascending
                    ? dataView.OrderBy(x => DataBinder.GetPropertyValue(x, e.SortExpression))
                    : dataView.OrderByDescending(x => DataBinder.GetPropertyValue(x, e.SortExpression));
                gridView.DataSource = PaginateData(DataSource);
                gridView.DataBind();
            }
        }

        private void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CurrentPageIndex = e.NewPageIndex;
            gridView.DataSource = PaginateData(DataSource);
            gridView.DataBind();
        }

        private IEnumerable PaginateData(IEnumerable data)
        {
            if (data is IList list)
            {
                return list.Cast<object>().Skip(CurrentPageIndex * PageSize).Take(PageSize).ToList();
            }

            return data;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            RenderChildren(writer);
        }
    }
}
