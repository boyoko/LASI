﻿using System;

namespace LASI.Utilities.Configuration
{
    public static class ConfigBuilder
    {
        public static IConfig FromJson(string filePath) => new JsonConfig(filePath);
        public static IConfig FromJson(Uri uri) => new JsonConfig(uri);
        public static IConfig FromJson(Newtonsoft.Json.Linq.JObject jObject) => new JsonConfig(jObject);
        public static IConfig FromXml(string filePath) => new XmlConfig(filePath);
        public static IConfig FromXml(Uri uri) => new XmlConfig(uri);
    }
}
