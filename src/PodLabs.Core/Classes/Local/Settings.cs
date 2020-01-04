using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PodLabs.Core.Classes.Local
{
    public class Settings
    {
        public string ConnectionString { get; set; }

        public Settings GetSettings()
        {
            if (!File.Exists("settings.json"))
            {
                var file = File.Create("settings.json");
                file.Close();
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(new Settings { }).ToString());
                throw new Exception("Settings file didn't exist, one has been created but will need some configuring.");
            }

            using (StreamReader reader = new StreamReader("settings.json", Encoding.UTF8))
            {
                return JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
            }
        }

        public static Settings ReadSettings()
        {
            var settings = new Settings();
            settings = settings.GetSettings();

            return settings;
        }
    }
}
