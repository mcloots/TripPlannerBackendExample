using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlannerBackend.DAL.Entity
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
