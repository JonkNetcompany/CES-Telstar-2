using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.EntityTypes;

namespace Domain.Models
{
    public class Route : Entity
    {
        public virtual ICollection<Segment> Segments { get; set; }
    }
}