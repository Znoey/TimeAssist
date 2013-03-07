using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TimeAssist
{
    [System.Serializable]
    public class AppSettings
    {

        public static AppSettings _instance = null;
        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppSettings();
                return _instance;
            }
        }

        public bool rememberLastLogin = false;
        public string loginName;
        public string loginPassword;
        private string dataString = "private data!";

        public AppSettings()
        {
            ReadFile();
        }

        public void ReadFile()
        {
            if (File.Exists("settings.txt"))
            {
                var fields = GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);

                string text = File.ReadAllText("settings.txt");
                List<string> list = new List<string>(text.Split('\n'));
                string[] line;
                string[] equals = { " = " };
                foreach (var item in list)
                {
                    line = item.Split(equals, StringSplitOptions.None);
                    foreach (var field in fields)
                    {
                        if (field.Name == line[0])
                        {
                            try
                            {
                                var method = field.FieldType.GetMethod("Parse");
                                if (method == null)
                                {
                                    field.SetValue(this, line[1] );
                                }
                                else
                                {
                                    field.SetValue(this, method.Invoke(this, new object[] { line[1] }));
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Could not parse method for type. Exception: " + e.Message);
                            }
                        }
                    }
                    //if (line[0] == "rememberLastLogin")
                    //    rememberLastLogin = bool.Parse(line[1]);
                    //else if (line[0] == "loginName")
                    //    loginName = line[1];
                    //else if (line[0] == "loginPassword")
                    //    loginPassword = line[1];
                }
            }
        }

        public void SaveFile()
        {
            var fields = typeof(AppSettings).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            foreach (var item in fields)
            {
                sb.Append(item.Name + " = " + item.GetValue(this).ToString() + "\n");
            }

            File.WriteAllText("settings.txt", sb.ToString());
        }
    }
}
