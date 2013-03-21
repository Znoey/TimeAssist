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
                StartTimeProperty stp = Find<StartTimeProperty>();
                FinishTimeProperty ftp = Find<FinishTimeProperty>();
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
                var stp = Find<StartTimeProperty>();
                if (stp != null)
                    return stp.Data;
                return DateTime.Now;
            }
            set 
            {
                var stp = Find<StartTimeProperty>();
                if (stp != null)
                    stp.Data = value;
                else
                    properties.Add(new StartTimeProperty(value));
            }
        }

        /// <summary>
        /// get or set the value for when this task was finished.
        /// </summary>
        public DateTime Finish
        {
            get
            {
                var ftp = Find<FinishTimeProperty>();
                if (ftp != null)
                    return ftp.Data;
                return DateTime.Now;
            }
            set 
            {
                var ftp = Find<FinishTimeProperty>();
                if (ftp != null)
                    ftp.Data = value;
                else
                    properties.Add(new FinishTimeProperty(value));
            }
        }

        /// <summary>
        /// Get or Set the string value for a task to represent this record as.
        /// </summary>
        public string Task 
        { 
            get
            {
                var task = Find<TaskProperty>();
                if( task != null )
                    return task.Data;
                return "";
            } 
            set
            {
                var task = Find<TaskProperty>();
                if (task != null)
                    task.Data = value;
                else
                    properties.Add(new TaskProperty(value));
            }
        }

        /// <summary>
        /// Get or set a comment to go with a task.
        /// </summary>
        public string Comment 
        { 
            get
            {
                var comments = FindAll<CommentProperty>();

                string s = "";
                foreach (var item in comments)
                    s += item.Data;
                return s; 
            } 
            set
            {
                var comments = FindAll<CommentProperty>();

                string s = "";
                foreach (var item in comments)
                    s += item.Data + "\n";
                int i = s.IndexOf(value);
                if (i != -1 && value.Length != 0 && s.Length != 0)
                    s = s.Remove(i, value.Length + 1);
                s += value;

                properties.RemoveAll(a => a.GetType() == typeof(CommentProperty));
                properties.Add(new CommentProperty(s));
            }
        }

        #region Constructors
        
        public Record(string _task)
            : this(_task, "")
        {
            Start = Finish = DateTime.Now;
        }

        public Record(string _task, string _comment)
        {
            Start = Finish = DateTime.Now;
            Task = _task;
            Comment = _comment;
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
            properties = new List<AProperty>();
        }

        //public Record(Record other)
        //{
        //    properties = new List<AProperty>();
        //    foreach (var item in other.properties)
        //    {
        //        this.properties.Add(item);
        //    }
        //}

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
                properties.Add(new StartTimeProperty().FromString(reader.GetAttribute("start")));
                properties.Add(new FinishTimeProperty().FromString(reader.GetAttribute("finish")));
                reader.ReadStartElement();
                properties.Add(new TaskProperty(reader.ReadElementString("task")));
                properties.Add(new CommentProperty(reader.ReadElementString("comment")));
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

        /// <summary>
        /// Retrieves a proprty of type T in the list.  Null if not found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Find<T>() where T : AProperty, new()
        {
            foreach (var property in properties)
            {
                if (property.GetType().IsAssignableFrom(typeof(T)))
                {
                    return property as T;
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves all properties of type T in the list.  Empty list if none found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> FindAll<T>() where T : AProperty, new()
        {
            List<T> all = new List<T>();
            foreach (var property in properties)
            {
                if (property.GetType().IsAssignableFrom(typeof(T)))
                {
                    all.Add(property as T);
                }
            }
            return all;
        }

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
