//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using GrpNo6_SmartDigital.Services;
using System;

namespace GrpNo6_SmartDigital
{
    public partial class CheckOutPage : System.Web.UI.Page
    {

        private CartService cartService;

        // Initializing the cart service when initializing the page
        protected void Page_Init(object sender, EventArgs e)
        {
            cartService = new CartService(Session);
        }


        //Simulating the order has been place by removing items from cart
        //and redirecting to home page
        protected void OrderButton_Click(object sender, EventArgs e)
        {
            cartService.ClearCart();
            Response.Redirect("HomePage.aspx");
        }
    }
}