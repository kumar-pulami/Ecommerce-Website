//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using GrpNo6_SmartDigital.DataService;
using GrpNo6_SmartDigital.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GrpNo6_SmartDigital
{
    public partial class HomePage : System.Web.UI.Page
    {

        private DataRepository dataRepository;
        private CartService cartService;

        //Initializing the DataRepository and cartservice on page initializing
        protected void Page_Init(object sender, EventArgs e)
        {
            dataRepository = new DataRepository();
            cartService = new CartService(Session);

            //Mapping the search and category selected event to fetchproducts method.
            //calling the fetch product method with empty string.
            Master.CategorySearchChanged += FetchProducts;
            FetchProducts(string.Empty, string.Empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        //Fetch the products based on selected category and searched.
        private void FetchProducts(string categoryFilter, string searchValue)
        {
            //building the dynamic sql query using string builder
            StringBuilder sqlQuery = new StringBuilder("SELECT * FROM Product");
            Dictionary<string, object> dbParameters = new Dictionary<string, object>();

            bool hasCategoryFilter = !string.IsNullOrEmpty(categoryFilter) && !categoryFilter.Equals("All");

            //if category has been selected
            //adding where clause for the category selected
            if (hasCategoryFilter)
            {
                sqlQuery.Append(" WHERE Category = @Category");
                dbParameters.Add("@Category", categoryFilter);
            }

            //if search has been done
            //adding where cluse for the searched value on name and description of the products
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                if (hasCategoryFilter)
                {
                    sqlQuery.Append(" AND (Name LIKE @SearchValue OR Description LIKE @SearchValue)");
                }
                else
                {
                    sqlQuery.Append(" WHERE Name LIKE @SearchValue OR Description LIKE @SearchValue");
                }

                dbParameters.Add("@SearchValue", "%" + searchValue + "%");
            }

            //executing the query with the db parameter
            //using db parameter to avid sql injection
            DataTable dtProducts = dataRepository.ExecuteSelectQueryWithParams(sqlQuery.ToString(), dbParameters);

            //binding the data to product repeater
            ProductRepeater.DataSource = dtProducts;
            ProductRepeater.DataBind();
        }


        //Executes when addtocart event is raised inside the repeater
        //basically by clicking cart icon
        //Adding product to the cart
        protected void ProductRepeater_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                var productId = Guid.Parse(e.CommandArgument.ToString());

                cartService.AddItem(productId);
                Response.Redirect("CartPage.aspx");
            }
        }
    }
}