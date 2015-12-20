﻿using System;
using System.Threading.Tasks;
using System.Xml;

namespace LASI.Content
{
    /// <summary>
    /// A strongly typed wrapper that encapsulates an XML document (.xml).
    /// </summary>
    sealed class XmlFile : InputFile
    {
        /// <summary>
        /// Initializes a new instance of the GenericXMLFile class for the given path.
        /// </summary>
        /// <param name="path">The path to a .xml file.</param>
        /// <exception cref="FileTypeWrapperMismatchException">Thrown if the provided path does not end in the .xml extension.</exception>
        public XmlFile(string path)
            : base(path)
        {
            if (!Extension.Equals(".xml", StringComparison.OrdinalIgnoreCase))
                throw new FileTypeWrapperMismatchException<XmlFile>(Extension);

        }

        /// <summary>
        /// Returns a single string containing all of the text in the PdfFile.
        /// </summary>
        /// <returns>A string containing all of the text in the PdfFile.</returns>
        public override string LoadText()
        {
            using (var reader = XmlReader.Create(new System.IO.StreamReader(new System.IO.FileStream(
                FullPath,
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read,
                System.IO.FileShare.Read, 1024, System.IO.FileOptions.Asynchronous)), new XmlReaderSettings { Async = true, IgnoreWhitespace = true }))
            {
                return reader.ReadContentAsString();
            }
        }
        /// <summary>
        /// Returns a Task&lt;string&gt; which when awaited yields all of the text in the PdfFile.
        /// </summary>
        /// <returns>A Task&lt;string&gt; which when awaited yields all of the text in the PdfFile.</returns>
        public override async Task<string> LoadTextAsync()
        {
            using (var reader = XmlReader.Create(new System.IO.StreamReader(new System.IO.FileStream(
                  FullPath,
                  System.IO.FileMode.Open,
                  System.IO.FileAccess.Read,
                  System.IO.FileShare.Read, 1024, System.IO.FileOptions.Asynchronous)), new XmlReaderSettings { Async = true, IgnoreWhitespace = true }))
            {
                return await reader.ReadContentAsStringAsync();
            }
        }
    }
}