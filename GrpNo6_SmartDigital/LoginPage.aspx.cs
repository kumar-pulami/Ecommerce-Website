//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using GrpNo6_SmartDigital.DataService;
using System;
using System.Collections.Generic;
using System.Data;

namespace GrpNo6_SmartDigital
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private DataRepository dataRepository;

        protected void Page_Init(object sender, EventArgs e)
        {
            dataRepository = new DataRepository();
        }

        protected void OnLoginClick(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;

            string sqlQuery = $@"
                            SELECT Id, FirstName, LastName, isAdmin
                            FROM person
                            WHERE
                                EmailAddress = @username
                                AND Password = @password
                                AND isAdmin = '1'
                            ";

            var dbParameters = new Dictionary<string, object>()
            {
                { "@username", username },
                { "@password", password }
            };

            DataTable personDetail = dataRepository.ExecuteSelectQueryWithParams(sqlQuery, dbParameters);

            if (personDetail.Rows.Count == 0)
            {
                ErrorMessageLabel.Visible = true;
                return;
            }

            Session["LoggedUserId"] = personDetail.Rows[0]["Id"].ToString();
            Response.Redirect("ProductPage.aspx");
        }
    }
}