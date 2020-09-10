using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public enum TransportationType
    {
        car,
        plane,
        boat
    }

    public class Segment
    {
        public int ID { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public double Time { get; set; }
        public double Price { get; set; }
        public virtual TransportationType TransportationType { get; set; }
    }
}