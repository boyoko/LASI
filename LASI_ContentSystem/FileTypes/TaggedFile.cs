﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LASI.ContentSystem
{
    /// <summary>
    /// A strongly typed wrapper that encapsulates a tagged file (.tagged), a file with embedded syntactic annotations.
    /// </summary>
    public sealed class TaggedFile : InputFile, Algorithm.ITaggedTextSource
    {
        /// <summary>
        /// Initializes a new instance of the TaggedFile class for the given path.
        /// </summary>
        /// <param name="filePath">The path to a .tagged file.</param>
        /// <exception cref="FileTypeWrapperMismatchException">Thrown if the provided path does not end in the .tagged extension.</exception>
        public TaggedFile(string filePath)
            : base(filePath) {
            if (!this.Ext.Equals(".tagged", StringComparison.OrdinalIgnoreCase))
                throw new LASI.ContentSystem.FileTypeWrapperMismatchException(GetType().ToString(), Ext);
        }
        /// <summary>
        /// Gets a single string containing all of the text in the TaggedFile.
        /// </summary>
        /// <returns>A single string containing all of the text in the TaggedFile.</returns>
        public string GetText() {
            using (var reader = new System.IO.StreamReader(this.FullPath)) {
                return reader.ReadToEnd();
            }
        }
        /// <summary>
        /// Asynchronously gets a single string containing all of the text in the TaggedFile.
        /// </summary>
        /// <returns>A single string containing all of the text in the TaggedFile.</returns>
        public async Task<string> GetTextAsync() {
            using (var reader = new System.IO.StreamReader(new System.IO.FileStream(this.FullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))) { return await reader.ReadToEndAsync(); }
        }
        /// <summary>
        /// Gets the simple name of the TaggedFile.
        /// </summary>
        public string Name {
            get { return NameSansExt; }
        }
    }
}
