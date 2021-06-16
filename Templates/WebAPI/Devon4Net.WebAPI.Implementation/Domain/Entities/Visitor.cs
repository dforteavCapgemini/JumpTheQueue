using System;
using System.Collections.Generic;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Domain.Entities
{
    public class Visitor
    {
        public int VisitorId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber  { get; set; }
        public bool AcceptedCommercial { get; set; }
        public bool AcceptedTerms { get; set; }
        public bool UserType{ get; set; }

        public AccessCode AccessCode { get; set; }
    }
}
