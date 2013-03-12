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
    public class Record : ISerializable, IXmlSerializable
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
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;    // docs say to return null here. @.@
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            //Console.WriteLine("Record reading xml");
            start = DateTime.Parse(reader.GetAttribute("start"));
            finish = DateTime.Parse(reader.GetAttribute("finish"));
            reader.ReadStartElement();
            task = reader.ReadElementString("task");
            comment = reader.ReadElementString("comment");
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            //Console.WriteLine("Record writing xml");
            writer.WriteStartElement("record");
            writer.WriteAttributeString("start", Start.ToString());
            writer.WriteAttributeString("finish", Finish.ToString());
            writer.WriteAttributeString("duration", (Start - Finish).ToString());
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

    }
}
