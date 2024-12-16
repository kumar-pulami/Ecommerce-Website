//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using System;

namespace GrpNo6_SmartDigital
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string loggedUserId = Session["LoggedUserId"] as string;

            if (string.IsNullOrEmpty(loggedUserId))
                Response.Redirect("HomePage.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}