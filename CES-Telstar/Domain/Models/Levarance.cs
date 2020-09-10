using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Levarance
    {
        public int ID { get; set; }
        public Route Route { get; set; }
        public int Time { get; set; }
        public float Price { get; set; }
        public bool Recommended { get; set; }
        public Package Package { get; set; }
        public Tracking Tracking { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
    }
}