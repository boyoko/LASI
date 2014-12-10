﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LASI.Content
{
    /// <summary>
    /// A strongly typed wrapper that encapsulates a tagged file (.tagged), a file with embedded syntactic annotations.
    /// </summary>
    public sealed class TaggedFile : InputFile, ITaggedTextSource
    {
        /// <summary>
        /// Initializes a new instance of the TaggedFile class for the given path.
        /// </summary>
        /// <param name="path">The path to a .tagged file.</param>
        /// <exception cref="FileTypeWrapperMismatchException">Thrown if the provided path does not end in the .tagged extension.</exception>
        public TaggedFile(string path)
            : base(path) {
            if (!Ext.Equals(".tagged", StringComparison.OrdinalIgnoreCase))
                throw new FileTypeWrapperMismatchException(GetType().ToString(), Ext);
        }
        /// <summary>
        /// Gets a single string containing all of the text in the TaggedFile.
        /// </summary>
        /// <returns>A single string containing all of the text in the TaggedFile.</returns>
        public override string GetText() {
            using (var reader = new StreamReader(
                new FileStream(FullPath,
                    FileMode.Open,
                    FileAccess.Read, FileShare.Read,
                    1024, FileOptions.Asynchronous),
                Encoding.UTF8, false, 1024, false)) {
                return reader.ReadToEnd();
            }
        }
        /// <summary>
        /// Asynchronously gets a single string containing all of the text in the TaggedFile.
        /// </summary>
        /// <returns>A single string containing all of the text in the TaggedFile.</returns>
        public override async Task<string> GetTextAsync() {
            using (var reader = new StreamReader(
                  new FileStream(FullPath,
                      FileMode.Open,
                      FileAccess.Read, FileShare.Read,
                      1024, FileOptions.Asynchronous),
                  Encoding.UTF8, false, 1024, false)) {
                var result = string.Empty;
                var line = await reader.ReadLineAsync();
                while (line != null) {
                    line = await reader.ReadLineAsync();
                    result += line;
                }
                return result;
            }
        }
        /// <summary>
        /// The file extension, in lower case excluding a '.', of the file type an instance of the class wraps.
        /// </summary>
        public const string EXTENSION = "tagged";
    }
}
