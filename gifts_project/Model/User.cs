using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gifts_project.Model
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string isMale { get; set; }
        public string phoneNum { get; set; }
        public string email { get; set; }
        public List<Event> events { get; set; }
    }
}
