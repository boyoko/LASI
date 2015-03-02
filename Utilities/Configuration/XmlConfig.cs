﻿using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LASI.Utilities.Configuration
{
    /// <summary>
    /// An XML Based configuration source.
    /// </summary>
    public class XmlConfig : ConfigBase
    {
        private XElement XElement;
        /// <summary>
        /// Initializes a new instance of the XmlConfig class from the specified XML file.
        /// </summary>
        /// <param name="filePath">The location of the XML file from which to retrieve configuration information to construct the XmlConfig instance.</param>
        public XmlConfig(string filePath) : base(filePath)
        {
            XElement = XElement.Parse(RawConfigData);
        }
        /// <summary>
        /// Initializes a new instance of the XmlConfig class from the XML data located at the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="uri">The Uri from which to retrieve configuration information to construct the XmlConfig instance.</param>
        public XmlConfig(Uri uri) : base(uri)
        {
            XElement = XElement.Parse(RawConfigData);
        }
        /// <summary>
        /// Initializes a new instance of the XmlConfig class from the specified <see cref="XElement"/>.
        /// </summary>
        /// <param name="xElement">The XElement from which to construct the XmlConfig instance.</param>
        public XmlConfig(XElement xElement) : base(xElement)
        {
            XElement = xElement;
        }
        /// <summary>Gets the value with the specified name.</summary>
        /// <param name="name">The name of the value to retrieve.</param>
        /// <returns>The value with the specified name.</returns>
        public override string this[string name] => this[name, StringComparison.Ordinal];
        /// <summary>
        /// Gets the value with the specified name, matching based on the specified <see cref="System.StringComparison" />.
        /// </summary>
        /// <param name="name">The name of the value to retrieve.</param>
        /// <param name="stringComparison">The string comparison to use for matching the name.</param>
        /// <returns>The value with the specified name, in the context of the <see cref="System.StringComparison" />.</returns>
        public override string this[string name, StringComparison stringComparison] => (
            from element in XElement.Descendants()
            where element.Name.ToString().Equals(name, stringComparison)
            select element.Value).FirstOrDefault();
    }
}