using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Model
{
    public class Request
    {
        public int ID { get; set; }

        public virtual Employee Employee { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        public RequestStates Status { get; set; }
    }
}
