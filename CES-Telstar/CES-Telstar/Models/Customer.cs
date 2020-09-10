using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES_Telstar.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}