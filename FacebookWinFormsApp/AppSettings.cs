using BasicFacebookFeatures.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    public class AppSettings
    {
        public string s_AppID {  get; set; }
        public string[] s_Permissions { get; set; }

        public bool RememberUser { get; set; }
        public string LastAccessToken { get; set; }

       public WishlistManager Tab2Manager { get; set; }

       public WorkoutManager WorkoutManager { get; set; }

        public AppSettings()
        { 
            RememberUser = false;
            LastAccessToken = null;
            s_Permissions = null;
            s_AppID = null;
            Tab2Manager = null;
            WorkoutManager = null;
        }

        public void SaveToFile()
        {
            using (Stream stream = new FileStream(@"C:\Users\noyzi\OneDrive\Documents\appSettings.xml", FileMode.Truncate))
            {
                XmlSerializer serilaizer = new XmlSerializer(this.GetType());
                serilaizer.Serialize(stream, this);
            }
        }

        public static AppSettings LoadFromFile() 
        {
            AppSettings settings = new AppSettings();
            if (File.Exists(@"C:\Users\noyzi\OneDrive\Documents\appSettings.xml"))
            {
                using (Stream stream = new FileStream(@"C:\Users\noyzi\OneDrive\Documents\appSettings.xml", FileMode.Open))
                {
                    XmlSerializer deserilaizer = new XmlSerializer(typeof(AppSettings));
                    settings = deserilaizer.Deserialize(stream) as AppSettings;
                }
            }

            return settings;
        }
    }
}
