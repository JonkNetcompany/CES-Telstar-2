using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Levarance
    {
        public int ID { get; set; }
        public virtual Route Route { get; set; }
        public double Time { get; set; }
        public double Price { get; set; }
        public bool Recommended { get; set; }
        public virtual Package Package { get; set; }
        public virtual Tracking Tracking { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}