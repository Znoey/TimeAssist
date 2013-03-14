using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using TimeAssist.Data.Property;

namespace TimeAssist
{
    [Serializable()]
    public class Record : ISerializable, IXmlSerializable, IComparable<Record>
    {
        /// <summary>
        /// Returns the duration of time this task was worked on.
        /// </summary>
        public float Duration { get { return Math.Abs((float)(start - finish).TotalHours); } }

        /// <summary>
        /// get or set the value for when this task was started.
        /// </summary>
        public DateTime Start { get { return start; } set { start = value; } }

        /// <summary>
        /// get or set the value for when this task was finished.
        /// </summary>
        public DateTime Finish { get { return finish; } set { finish = value; } }

        /// <summary>
        /// Get or Set the string value for a task to represent this record as.
        /// </summary>
        public string Task { get { return task; } set{ task = value; }}

        /// <summary>
        /// Get or set a comment to go with a task.
        /// </summary>
        public string Comment { get { return comment; } set { comment = value;}}

        #region Constructors
        
        public Record(string _task)
            : this(_task, "")
        {
            start = finish = DateTime.Now;
        }

        public Record(string _task, string _comment)
        {
            start = finish = DateTime.Now;
            task = _task;
            comment = _comment;
        }

        #endregion

        #region ISerializable Interface

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Start", Start);
            info.AddValue("Finish", Finish);
            info.AddValue("Task", Task);
            info.AddValue("Comment", Comment);
        }

        protected Record(SerializationInfo info, StreamingContext context)
        {

            int i = info.MemberCount;
            var e = info.GetEnumerator();
            while(e.MoveNext())
            {
                try
                {
                    if (e.Name == "Start")
                    {
                        properties.Add(new StartTimeProperty(DateTime.Parse(e.Value as string)));
                    }
                    else if (e.Name == "Finish")
                    {
                        properties.Add(new FinishTimeProperty(DateTime.Parse(e.Value as string)));
                    }
                    else if (e.Name == "Task")
                    {
                        properties.Add(new TaskProperty(e.Value as string));
                    }
                    else if (e.Name == "Comment")
                    {
                        properties.Add(new CommentProperty(e.Value as string));
                    }
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            start = info.GetDateTime("Start");
            finish = info.GetDateTime("Finish");
            task = info.GetString("Task");
            comment = info.GetString("Comment");
        }


        #endregion

        #region IXmlSerializable Interface

        /// <summary>
        /// Constructs a record.
        /// Required for the IXmlSerializable interface.
        /// </summary>
        public Record()
        {
            start = finish = DateTime.Now;
            task = "";
            comment = "";
            properties = new List<AProperty>();
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;    // docs say to return null here. @.@
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            var tree = reader.ReadSubtree();
            //Console.WriteLine("Record reading xml");
            if (reader.HasAttributes)
            {
                start = DateTime.Parse(reader.GetAttribute("start"));
                properties.Add(new StartTimeProperty(start));
                finish = DateTime.Parse(reader.GetAttribute("finish"));
                properties.Add(new FinishTimeProperty(finish));
            }
            reader.ReadStartElement();
            task = reader.ReadElementString("task");
            properties.Add(new TaskProperty(task));
            comment = reader.ReadElementString("comment");
            properties.Add(new CommentProperty(comment));
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            //Console.WriteLine("Record writing xml");
            writer.WriteStartElement("record");
            writer.WriteAttributeString("start", Start.ToString());
            writer.WriteAttributeString("finish", Finish.ToString());
            writer.WriteAttributeString("duration", (Start - Finish).ToString());
            if (properties.Count > 0)
            {
                foreach (var item in properties)
                {
                    writer.WriteElementString(item.GetType().ToString(), item.ToString());
                }
            }
            writer.WriteElementString("task", task);
            writer.WriteElementString("comment", comment);
            writer.WriteEndElement();
        }

        #endregion

        private DateTime start;
        private DateTime finish;
        private string task;
        private string comment;

        public List<AProperty> properties;


        public int CompareTo(Record other)
        {
            if (this.GetHashCode() == other.GetHashCode())
                return 0;
            var x = (this.start - other.start).Duration().TotalMilliseconds;
            if (double.Epsilon + x >= 0 || double.Epsilon - x <= 0)
                return 0;
            if (x > 0)
                return 1;
            else
                return -1;
        }
    }
}
