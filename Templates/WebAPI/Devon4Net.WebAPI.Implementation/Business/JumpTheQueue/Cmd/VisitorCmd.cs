using System;
using System.Collections.Generic;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Cmd
{
    public class VisitorCmd
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool AcceptedCommercial { get; set; }
        public bool AcceptedTerms { get; set; }
        public bool UserType { get; set; }
    }
}
