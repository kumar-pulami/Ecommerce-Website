//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using GrpNo6_SmartDigital.DataService;
using GrpNo6_SmartDigital.Models;
using GrpNo6_SmartDigital.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace GrpNo6_SmartDigital
{
    public partial class CartPage : System.Web.UI.Page
    {
        private CartService cartService;
        private DataRepository dataRepository;
        public decimal totalPrice = 0.00m;


        //Initializing the cart service and data repository when initializing the page.
        protected void Page_Init(object sender, EventArgs e)
        {
            cartService = new CartService(Session);
            this.dataRepository = new DataRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeaterDataSource();
            }
        }


        //Calculates the total price for the specific product
        public string CalculateSubTotal(object quantity, object price)
        {
            decimal subTotal = int.Parse(quantity.ToString()) * decimal.Parse(price.ToString());

            return subTotal.ToString("N2");
        }


        //Binds the data from session to the repeater control.
        //Gets the data from session stored
        //Convert the data into view model by getting its respective price and images from the data
        //Then bind the data.
        private void BindRepeaterDataSource()
        {
            var sessionCartItems = cartService.GetSessionCartItems();
            CartItemRepeater.DataSource = MapSessionCartToCartItem(sessionCartItems);
            CartItemRepeater.DataBind();
        }


        //Converts the SessionCartItems into CartItem
        //Fetch the necessary data from product table based on id.
        private CartItem[] MapSessionCartToCartItem(IEnumerable<SessionCartItem> sessionCartItems)
        {
            //hides the total row 
            //shows the no data row
            if (!sessionCartItems.Any())
            {
                noDataRow.Visible = true;
                totalDataRow.Visible = false;
                return Array.Empty<CartItem>();
            }

            //getting all the ids of the items that are in cart.
            Guid[] productIds = sessionCartItems.Select(x => x.Id).ToArray();

            //sql to get product detail from the product table.
            //looping each product id and join all as single string to build where clause for Id
            string sqlQuery = $@"
                            SELECT 
                                Id,
                                Name,
                                Price,
                                ImagePath
                            FROM 
                                Product
                            WHERE 
                                Id IN ({string.Join(",", productIds.Select(id => $"'{id}'"))});
                        ";

            //Executing the sql query. 
            DataTable productDetails = dataRepository.ExecuteSelectQuery(sqlQuery);

            totalPrice = 0m;

            var cartItems = sessionCartItems.Select(sessionItem =>
            {
                // Find the corresponding product in the result table using the session item ID
                var productRow = productDetails
                                            .AsEnumerable()
                                            .FirstOrDefault(row => row.Field<Guid>("Id") == sessionItem.Id);

                if (productRow != null)
                {
                    totalPrice = totalPrice + productRow.Field<decimal>("Price") * sessionItem.Quantity;

                    // Create a CartItem and populate its properties
                    return new CartItem
                    {
                        Id = sessionItem.Id,
                        Name = productRow.Field<string>("Name"),
                        Price = productRow.Field<decimal>("Price"),
                        Quantity = sessionItem.Quantity,
                        ImagePath = productRow.Field<string>("ImagePath")
                    };
                }
                else
                {
                    // If no product found for this ID, you can handle it accordingly (throw exception, return null, etc.)
                    return null;
                }
            }).Where(cartItem => cartItem != null).ToArray();


            //if has items
            //show the total row
            // hide the no data row
            if (cartItems.Any())
            {
                totalDataRow.Visible = true;
                noDataRow.Visible = false;
            }

            return cartItems;
        }

        // Set the min attribute of the text box to 1
        // user can input less than 1 through ups and down key.
        protected void QuantityTxt_DataBinding(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            textBox.Attributes["min"] = "1";
        }


        // Updates the quantity of the cart items.
        // calculate the item total cost.
        // update it to the session
        // binds the new data to repeater control
        protected void QuantityTxt_TextChanged(object sender, EventArgs e)
        {
            //getting the textbox
            TextBox quantityTxt = (TextBox)sender;

            //getting the repeater cart item
            RepeaterItem item = (RepeaterItem)quantityTxt.NamingContainer;

            //getting id from the hiddennId field
            HiddenField itemIdField = (HiddenField)item.FindControl("Id");

            string quantity = quantityTxt.Text;
            Guid itemId = Guid.Parse(itemIdField.Value);

            bool success = int.TryParse(quantity, out int intQuantity);

            // if the quantity is not valid and less than 1
            // setting default to 1
            if (!success || intQuantity <= 0)
            {
                intQuantity = 1;
                quantityTxt.Text = "1";
            }

            cartService.UpdateItem(itemId, intQuantity);
            BindRepeaterDataSource();
        }

        //removing the cart item from session
        //binding the datasource of the repeater
        protected void CartItemRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "RemoveItem")
            {
                var productId = Guid.Parse(e.CommandArgument.ToString());

                cartService.RemoveItem(productId);
                BindRepeaterDataSource();
            }
        }


        //redirecting to checkout page on click checkout button.
        protected void CheckOutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOutPage.aspx");
        }
    }
}