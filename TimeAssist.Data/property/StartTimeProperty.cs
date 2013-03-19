using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeAssist.Data.Property
{
    public class StartTimeProperty : GenericProperty<DateTime>
    {
        public StartTimeProperty()
        {

        }
        public StartTimeProperty(DateTime startTime)
            : base(startTime)
        { }

        public override string ToString()
        {
            return Data.ToString();
        }

        public override AProperty FromString(string s)
        {
            Data = DateTime.Parse(s);
            return this;
        }
    }
}
