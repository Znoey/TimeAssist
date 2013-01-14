using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeAssist.Data.Property
{
    public class CommentProperty : GenericProperty<string>
    {
        public CommentProperty(string comment)
            : base(comment)
        { }

        public override string ToString()
        {
            return "<comment>" + Data + "</comment>";
        }

        public override AProperty FromString(string s)
        {
            Data = s;
            return this;
        }
    }
}
