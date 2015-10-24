﻿using LASI.App.Properties;
using LASI.Content;
using System;
using System.Windows;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.IO;
using LASI.Utilities.Configuration;

namespace LASI.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// A global structure containing dynamic application configuration.
        /// </summary>
        public static IConfig Config { get; private set; }

        /// <summary>
        /// Initializes a new instances of the <see cref="App"/> class
        /// </summary>
        public App()
        {
            LoadPerformancePreference();
            var configPath = File.Exists(@"App.config") ? "App.config" : @"..\..\App.config";
            Config = ParseConfig(configPath);
            Interop.Configuration.Initialize(Config);
        }

        private static IConfig ParseConfig(string configPath) => new XmlConfig(new XElement(
                    name: "configuration",
                    content: from element in XElement.Load(configPath).Element("appSettings").Elements()
                             let name = element.Attribute("key")
                             let content = element.Attribute("value")
                             where name != null && content != null
                             select new XElement(name: name.Value,
                                 content: name.Value == "ResourcesDirectory" || name.Value == "LicencesDirectory" ? Directory.GetCurrentDirectory() + @"\" : content.Value
                             )));

        private static void LoadPerformancePreference()
        {
            Interop.PerformanceProfile performanceProfile;
            if (Enum.TryParse(Settings.Default.PerformanceLevel, out performanceProfile))
            {
                Interop.ResourceUsageManager.SetPerformanceLevel(performanceProfile);
            }
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (Settings.Default.AutoCleanProjectFiles && FileManager.Initialized)
            {
                FileManager.DecimateProject();
            }
        }

    }
}
