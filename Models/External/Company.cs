﻿using System;

namespace Models.External
{
    public class Company
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public bool IsPolicyActive { get; set; }
    }
}
