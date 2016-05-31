using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gifts_project.Model
{
    public class Event
    {
        public string name { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public List<WantedGift> wantedGifts { get; set; }
    }
}
