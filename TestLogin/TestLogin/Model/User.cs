using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogin.Model
{
    class User
    {
        public class Data
        {
            public string token { get; set; }
        }

        public class RootObject
        {
            public Data data { get; set; }
        }
    }
}
