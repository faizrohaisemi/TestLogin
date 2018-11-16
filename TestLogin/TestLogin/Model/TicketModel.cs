using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogin.Model
{
    class TicketModel
    {
        public class Ticket
        {
            public int id { get; set; }
            public int tenant_id { get; set; }
            public string requester { get; set; }
            public string mesra_link_log_no { get; set; }
            public string title { get; set; }
            public DateTime date_created { get; set; }
            public DateTime time_created { get; set; }
            public int created_by { get; set; }
        }

        public class RootObject
        {
            public List<Ticket> tickets { get; set; }
        }
    }
}
