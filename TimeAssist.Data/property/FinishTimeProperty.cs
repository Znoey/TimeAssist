using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeAssist.Data.Property
{
    public class FinishTimeProperty : GenericProperty<DateTime>
    {
        public FinishTimeProperty()
        {

        }
        public FinishTimeProperty(DateTime finishTime)
            : base(finishTime)
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
