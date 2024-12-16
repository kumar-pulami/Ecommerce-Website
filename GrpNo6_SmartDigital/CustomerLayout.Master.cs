//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using System;
using System.Web.UI.WebControls;

namespace GrpNo6_SmartDigital
{
    public partial class CustomerLayout : System.Web.UI.MasterPage
    {

        public delegate void CategorySearchChangedHandler(string categoryValue, string searchValue);
        public event CategorySearchChangedHandler CategorySearchChanged;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ddlCategory_DataBound(object sender, EventArgs e)
        {
            //Insert the All Option to dropdown as a default selected value.
            CategoryDropDownList.Items.Insert(0, new ListItem("All", "All"));
            CategoryDropDownList.SelectedValue = "All";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (CategorySearchChanged != null)
            {
                CategorySearchChanged(CategoryDropDownList.SelectedValue, txtSearch.Text);
            }
        }

        protected void CategoryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategorySearchChanged != null)
            {
                CategorySearchChanged(CategoryDropDownList.SelectedValue, txtSearch.Text);
            }
        }
    }
}