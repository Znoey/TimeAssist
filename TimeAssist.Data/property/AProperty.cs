﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeAssist.Data.Property
{
    public abstract class AProperty
    {
        public AProperty()
        {
            Data = null;
        }
        public object Data { get; set; }

        public AProperty(object Data)
        {
            this.Data = Data;
        }

        public abstract AProperty FromString(string s);
    }

    public abstract class GenericProperty<T> : AProperty
    {
        public GenericProperty()
        {
            Data = default(T);
        }
        new public T Data
        {
            get { return (T)base.Data; }
            set { base.Data = (T)value; }
        }

        public GenericProperty(T data)
            : base(data)
        { }
    }
}
