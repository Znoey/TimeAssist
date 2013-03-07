using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace TimeAssist
{
    [Serializable]
    public class Person : IXmlSerializable, ISerializable
    {
        public string Name { get { return name; } }
        public string Password { get { return password; } }
        public string FileName { get { return recordFileName; } }
        public Dictionary<string, List<Record>> Records { get { return records; } }
        public List<Record> TodaysRecords 
        { 
            get 
            {
                if (records.ContainsKey(DateTime.Now.ToString("d")))
                    return records[DateTime.Today.ToString("d")];
                else
                    return null;
            } 
        }


        public Person()
        {
            name = null;
            password = null;
            recordFileName = null;
            records = new Dictionary<string, List<Record>>();
        }

        public Person(string _name, string _password)
        {
            name = _name;
            password = _password;
            recordFileName = name + "_Records.xml";
            records = new Dictionary<string, List<Record>>();
        }

        #region Save / Load file

        public void Load()
        {
            // TODO: Put the serialization loading back in.

            if (!File.Exists(recordFileName))
            {
                return;
            }

            //using (Stream stream = File.OpenRead(recordFileName))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    Person p = (Person)bf.Deserialize(stream);
            //    this.name = p.name;
            //    this.password = p.password;
            //    this.records = p.records;
            //}

            
            using (TextReader stream = new StreamReader(File.OpenRead(recordFileName)))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Person));
                Person p = (Person)xml.Deserialize(stream);
                this.name = p.name;
                this.password = p.password;
                this.records = p.records;
            }
             
        }

        public void Save()
        {
            //using (Stream stream = File.OpenWrite(recordFileName))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(stream, this);
            //}
            
            using (FileStream fs = File.Open(recordFileName, FileMode.Create ))
            {
                XmlSerializer xml = new XmlSerializer(this.GetType());
                xml.Serialize(fs, this);
            }
        }
        #endregion


        public void AddRecord(Record recordToAdd)
        {
            string key = DateTime.Today.ToString("d");
            if (!records.ContainsKey(key))
            {
                records.Add(key, new List<Record>());
            }

            records[key].Add(recordToAdd);
            records[key].Sort((Record a, Record b) =>
            {
                return a.Start.CompareTo(b.Start);
            });
        }

        #region IXmlSerializable interface

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return (null);
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            name = reader.GetAttribute("name");
            password = reader.GetAttribute("password");
            recordFileName = reader.GetAttribute("filename");
            records = new Dictionary<string, List<Record>>();
            reader.ReadStartElement(); // "history" node
            DateTime stackTime = DateTime.Today;
            while (!reader.EOF)
            {
                var node = reader.MoveToContent();
                if (node == System.Xml.XmlNodeType.EndElement)
                {
                    reader.ReadEndElement();
                }
                else if (reader.Name == "history")
                {
                    reader.ReadStartElement();
                }
                else if (reader.Name == "recordstack" || reader.Name == "recordlist")
                {
                    stackTime = DateTime.Parse(reader.GetAttribute("date"));
                    records.Add(stackTime.ToString("d"), new List<Record>());
                    reader.ReadStartElement();
                }
                else if (reader.Name == "record")
                {
                    Record r = new Record();
                    r.ReadXml(reader);
                    records[stackTime.ToString("d")].Add(r);
                    records[stackTime.ToString("d")].Sort((Record a, Record b) =>
                    {
                        return a.Start.CompareTo(b.Start);
                    });
                    //reader.ReadEndElement();
                }
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            // TODO: Test saving to xml and see what the output is.
            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("password", password);
            writer.WriteAttributeString("filename", recordFileName);
            writer.WriteStartElement("history");
            foreach (var date in records.Keys)
            {
                writer.WriteStartElement("recordlist");
                writer.WriteAttributeString("date", date);
                foreach(var record in records[date])
                {
                    record.WriteXml(writer);
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        #endregion

        private string name;
        private string password;
        private string recordFileName;
        private Dictionary<string, List<Record>> records;

        #region ISerializabel Interface

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("Name");
            password = info.GetString("Password");
            recordFileName = info.GetString("RecordFileName");

            records = new Dictionary<string, List<Record>>();
        }
        

        protected Person(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("Name");
            password = info.GetString("Password");
            recordFileName = info.GetString("RecordFileName");

            records = new Dictionary<string, List<Record>>();
        }

        #endregion
    }
}
