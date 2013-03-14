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
            return Data;
        }

        public override AProperty FromString(string s)
        {
            Data = s;
            return this;
        }

        public static implicit operator CommentProperty (string s)
        {
            return new CommentProperty(s);
        }
        public static implicit operator string( CommentProperty cp)
        {
            return cp.ToString();
        }
    }
}
