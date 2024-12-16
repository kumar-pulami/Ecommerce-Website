//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276
using System;

namespace GrpNo6_SmartDigital.Models
{
    //Model Class to represent the cart items to be displayed in cart page
    public class CartItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}