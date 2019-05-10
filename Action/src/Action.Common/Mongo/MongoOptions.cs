using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Common.Mongo
{
    public class MongoOptions
    {
        public string  Connectionstring { get; set; }
        public string Database { get; set; }
        public bool Send { get; set; }
    }
}
