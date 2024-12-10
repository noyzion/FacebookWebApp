using System.IO;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    public class AppSettings
    {
        public string AppID { get; set; }
        public string[] Permissions { get; set; }
        public bool RememberUser { get; set; }
        public string LastAccessToken { get; set; }
        public WishlistManager m_WishlistManager { get; set; }
        public WorkoutManager WorkoutManager { get; set; }
        public AppSettings()
        {
            RememberUser = false;
            LastAccessToken = null;
            Permissions = null;
            AppID = null;
            m_WishlistManager = null;
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