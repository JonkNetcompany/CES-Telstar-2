using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES_Telstar.Models
{
    public class Route
    {
        public int ID { get; set; }
        public IEnumerable<Segment> Segments { get; set; }
    }
}