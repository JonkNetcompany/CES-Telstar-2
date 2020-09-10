using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Segment
    {
        public int ID { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public int Time { get; set; }
        public float Price { get; set; }
    }
}