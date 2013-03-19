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
        public float Duration { 
            get
            {
                StartTimeProperty stp = null;
                FinishTimeProperty ftp = null;
                foreach (var p in properties)
                {
                    if (p.GetType() == typeof(StartTimeProperty))
                        stp = p as StartTimeProperty;
                    if (p.GetType() == typeof(FinishTimeProperty))
                        ftp = p as FinishTimeProperty;
                }
                if (stp != null && ftp != null)
                {
                    return Math.Abs((float)(stp.Data - ftp.Data).TotalHours);
                }
                else if (stp != null && ftp == null)
                {
                    return Math.Abs((float)(stp.Data - DateTime.Now).TotalHours);
                }
                else
                {
                    return 0;
                }
            } 
        }

        /// <summary>
        /// get or set the value for when this task was started.
        /// </summary>
        public DateTime Start
        {
            get
            {
                foreach (var p in properties)
                {
                    if (p.GetType() == typeof(StartTimeProperty))
                    {
                        StartTimeProperty stp = p as StartTimeProperty;
                        return stp.Data;
                    }
                } 
                return DateTime.Now;
            }
            set { start = value; }
        }

        /// <summary>
        /// get or set the value for when this task was finished.
        /// </summary>
        public DateTime Finish
        {
            get
            {
                foreach (var p in properties)
                {
                    if (p.GetType() == typeof(FinishTimeProperty))
                    {
                        FinishTimeProperty stp = p as FinishTimeProperty;
                        return stp.Data;
                    }
                }
                return DateTime.Now;
            }
            set { finish = value; }
        }

        /// <summary>
        /// Get or Set the string value for a task to represent this record as.
        /// </summary>
        public string Task 
        { 
            get
            {
                string s = "";
                foreach (var p in properties)
                {
                    if (p.GetType() == typeof(TaskProperty))
                        s += p.Data;
                }
                return s; 
            } 
            set{ task = value; }
        }

        /// <summary>
        /// Get or set a comment to go with a task.
        /// </summary>
        public string Comment 
        { 
            get
            {
                string s = "";
                foreach (var p in properties)
                {
                    if (p.GetType() == typeof(CommentProperty))
                        s += p.Data + "  ";
                }
                return s; 
            } 
            set { comment = value;}
        }

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
            //Console.WriteLine("Record reading xml");
            bool bOldStyle = reader.HasAttributes;

            if (bOldStyle)
            {
                start = DateTime.Parse(reader.GetAttribute("start"));
                properties.Add(new StartTimeProperty(start));
                finish = DateTime.Parse(reader.GetAttribute("finish"));
                properties.Add(new FinishTimeProperty(finish));
                reader.ReadStartElement();
                task = reader.ReadElementString("task");
                properties.Add(new TaskProperty(task));
                comment = reader.ReadElementString("comment");
                properties.Add(new CommentProperty(comment));
                reader.ReadEndElement();
            }
            else
            {
                while (reader.Read())
                {
                    if (reader.Name == "record" && reader.NodeType == System.Xml.XmlNodeType.EndElement)
                    {
                        break;
                    }
                    if (reader.Name == "StartTimeProperty" && reader.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        properties.Add(ReadProperty<StartTimeProperty>(reader));
                    }
                    if (reader.Name == "FinishTimeProperty" && reader.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        properties.Add(ReadProperty<FinishTimeProperty>(reader));
                    }
                    if (reader.Name == "TaskProperty" && reader.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        properties.Add(ReadProperty<TaskProperty>(reader));
                    }
                    if (reader.Name == "CommentProperty" && reader.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        properties.Add(ReadProperty<CommentProperty>(reader));
                    }
                }
            }
        }

        public T ReadProperty<T>(System.Xml.XmlReader reader) where T :  AProperty, new()
        {
            if (reader.Name == typeof(T).Name && reader.NodeType == System.Xml.XmlNodeType.Element)
            {
                T prop = new T();
                reader.Read();
                prop.FromString(reader.Value);
                reader.Read();
                return prop;
            }
            return null;
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            //Console.WriteLine("Record writing xml");
            writer.WriteStartElement("record");
            if (properties.Count > 0)
            {
                foreach (var item in properties)
                {
                    writer.WriteElementString(item.GetType().Name, item.ToString());
                }
            }
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
