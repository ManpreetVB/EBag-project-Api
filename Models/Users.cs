﻿using System.Globalization;

namespace EBags.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName {get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public int IsActive  { get; set; }
    }
}
