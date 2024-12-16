//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using System;

namespace GrpNo6_SmartDigital.Models
{
    //Model Class to represent the cart items that is going to be stored in session.
    public class SessionCartItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}