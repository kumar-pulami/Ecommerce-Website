//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using GrpNo6_SmartDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;

namespace GrpNo6_SmartDigital.Services
{
    //Cart class that handles the CRUD operation of carted items in session
    public class CartService
    {
        private List<SessionCartItem> sessionCartItems;
        private readonly HttpSessionState currentSession;

        public CartService(HttpSessionState currentSession)
        {
            this.currentSession = currentSession;
            this.sessionCartItems = currentSession["cartItems"] as List<SessionCartItem> ?? new List<SessionCartItem>();
        }

        //Add new item to cart session
        //setting default value to 1 if new
        //else increasing by 1 in quantity
        public void AddItem(Guid productId)
        {
            SessionCartItem item = sessionCartItems.FirstOrDefault(x => x.Id == productId);

            if (item == null)
            {
                sessionCartItems.Add(new SessionCartItem
                {
                    Id = productId,
                    Quantity = 1,
                });

            }
            else
            {
                item.Quantity = item.Quantity + 1;
            }

            UpdateListToSession();
        }

        //updating the quantity of the product
        //removes the items if the quantiy is less than 0
        //else updates the quantity of the product
        public void UpdateItem(Guid productId, int quantity)
        {
            if (quantity < 1)
            {
                RemoveItem(productId);
                return;
            }

            SessionCartItem item = sessionCartItems.FirstOrDefault(x => x.Id == productId);

            if (item == null)
                return;

            item.Quantity = quantity;

            UpdateListToSession();
        }

        //getter method to return the items from session
        public List<SessionCartItem> GetSessionCartItems()
        {
            return sessionCartItems;
        }

        //removes the items by id from the session
        public void RemoveItem(Guid productId)
        {
            SessionCartItem item = sessionCartItems.FirstOrDefault(x => x.Id == productId);

            if (item == null)
                return;

            sessionCartItems.Remove(item);

            UpdateListToSession();
        }

        //updates the updated list of cartitems to the session,
        private void UpdateListToSession()
        {
            currentSession["cartItems"] = sessionCartItems;
        }

        //clears all the cart items in the session
        public void ClearCart()
        {
            currentSession["cartItems"] = new List<SessionCartItem>();
        }

    }
}