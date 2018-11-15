using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogin.Model
{
    class UserListModel
    {
        public class Datum
        {
            public int id { get; set; }
            public string username { get; set; }
            public string fullname { get; set; }
            public string email { get; set; }
            public string group_id { get; set; }
            public int tenant_id { get; set; }
        }

        public class RootObject
        {
            public List<Datum> data { get; set; }
        }
    }
}
