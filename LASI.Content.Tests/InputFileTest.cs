﻿using System.Threading.Tasks;
using Xunit;
using TestMethod = Xunit.FactAttribute;


namespace LASI.Content.Tests
{


    /// <summary>
    ///This is a test class for InputFileTest and is intended
    ///to contain all InputFileTest Unit Tests
    /// </summary>
    public class InputFileTest
    {
        const string TestTextFilePath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.txt";

        internal virtual InputFile CreateInputFile() => new TxtFile(TestTextFilePath);

        /// <summary>
        ///A test for Equals
        /// </summary>
        [TestMethod]
        public void EqualsTest()
        {
            var relativePath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.docx";
            InputFile target = new DocXFile(relativePath);
            object obj = null;
            bool expected = false;
            bool actual;
            actual = target.Equals(obj);
            Assert.Equal(expected, actual);
            obj = new DocXFile(relativePath);
            expected = true;
            actual = target.Equals(obj);
            Assert.Equal(expected, actual);
            TxtFile other = new TxtFile(@"..\..\MockUserFiles\Draft_Environmental_Assessment.txt");
            expected = false;
            actual = target.Equals(other);
            InputFile other1 = new DocXFile(@"..\..\MockUserFiles\Draft_Environmental_Assessment.docx");
            expected = true;
            actual = target.Equals(other1);
            DocXFile other2 = new DocXFile(@"..\..\MockUserFiles\Draft_Environmental_Assessment.docx");
            expected = true;
            actual = target.Equals(other2);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for GetHashCode
        /// </summary>
        [TestMethod]
        public void GetHashCodeTest()
        {
            var relativePath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.docx";
            InputFile target = new DocXFile(relativePath);
            int expected = new DocXFile(relativePath).GetHashCode();
            int actual;
            actual = target.GetHashCode();
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for LoadText
        /// </summary>
        [TestMethod]
        public void LoadTextTest()
        {
            InputFile target = CreateInputFile();
            string expected = string.Empty;
            using (var reader = new System.IO.StreamReader(target.FullPath))
            {
                expected = reader.ReadToEnd();
            }
            string actual;
            actual = target.LoadText();
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for LoadTextAsync
        /// </summary>
        [TestMethod]
        public void LoadTextAsyncTest()
        {
            InputFile target = CreateInputFile();
            string expected = string.Empty;
            string actual = null;
            Task.WaitAll(Task.Run(
                async () => expected = await new System.IO.StreamReader(target.FullPath).ReadToEndAsync()),
                Task.Run(async () => actual = await target.LoadTextAsync())
            );
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            InputFile target = CreateInputFile(); // TODO: Initialize to an appropriate value
            string expected = string.Format("{0}: {1} in: {2}", target.GetType(), target.FileName, target.Directory);
            string actual;
            actual = target.ToString();
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for op_Equality
        /// </summary>
        [TestMethod]
        public void op_EqualityTest()
        {
            InputFile left = new TxtFile(TestTextFilePath);
            InputFile right = null;
            bool expected = false;
            bool actual;
            actual = (left == right);
            Assert.Equal(expected, actual);

            right = new DocXFile(@"..\..\MockUserFiles\Draft_Environmental_Assessment.docx");
            expected = false;
            actual = (left == right);
            Assert.Equal(expected, actual);
            right = new TxtFile(TestTextFilePath);
            expected = true;
            actual = (left == right);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for op_Inequality
        /// </summary>
        [TestMethod]
        public void op_InequalityTest()
        {
            InputFile left = new TxtFile(TestTextFilePath);
            InputFile right = null;
            bool expected = true;
            bool actual;
            actual = (left != right);
            Assert.Equal(expected, actual);

            right = new DocXFile(@"..\..\MockUserFiles\Draft_Environmental_Assessment.docx");
            expected = true;
            actual = (left != right);
            Assert.Equal(expected, actual);
            right = new TxtFile(TestTextFilePath);
            expected = false;
            actual = (left != right);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for Directory
        /// </summary>
        [TestMethod]
        public void DirectoryTest()
        {
            var relativePath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.docx";
            InputFile target = new DocXFile(relativePath);
            string expected = new System.IO.FileInfo(relativePath).Directory.FullName + "\\";
            string actual;
            actual = target.Directory;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for Extension
        /// </summary>
        [TestMethod]
        public void ExtTest()
        {
            var fullPath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.docx";
            InputFile target = new DocXFile(fullPath);
            string expected = ".docx";
            string actual;
            actual = target.Extension;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for FileName
        /// </summary>
        [TestMethod]
        public void FileNameTest()
        {
            var relativePath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.pdf";
            InputFile target = new PdfFile(relativePath);
            string expected = "Draft_Environmental_Assessment.pdf";
            string actual;
            actual = target.FileName;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for FullPath
        /// </summary>
        [TestMethod]
        public void FullPathTest()
        {
            var relativePath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.docx";
            InputFile target = new DocXFile(relativePath);
            string actual;
            actual = target.FullPath;
            Assert.Equal(System.IO.Path.GetFullPath(relativePath), actual);
        }        /// <summary>
                 ///A test for FullPath
                 /// </summary>
        [TestMethod]
        public void FullPathTest1()
        {
            var relativePath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.docx";
            InputFile target = new DocXFile(relativePath);
            string actual;
            actual = target.FullPath;
            Assert.Equal(System.IO.Path.GetFullPath(relativePath), actual);
        }

        /// <summary>
        ///A test for Name
        /// </summary>
        [TestMethod]
        public void NameTest()
        {
            var relativePath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.doc";
            InputFile target = new DocFile(relativePath);
            string expected = "Draft_Environmental_Assessment";
            string actual;
            actual = target.Name;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for NameSansExt
        /// </summary>
        [TestMethod]
        public void NameSansExtTest()
        {
            var relativePath = @"..\..\MockUserFiles\Draft_Environmental_Assessment.txt";
            InputFile target = new TxtFile(relativePath);
            string expected = "Draft_Environmental_Assessment";
            string actual;
            actual = target.Name;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for PathSansExt
        /// </summary>
        [TestMethod]
        public void PathSansExtTest()
        {
            var absolutePath = System.IO.Path.GetFullPath(@"..\..\MockUserFiles\Draft_Environmental_Assessment.pdf");
            InputFile target = new PdfFile(absolutePath);
            string expected = System.IO.Path.GetDirectoryName(absolutePath) + @"\Draft_Environmental_Assessment";
            string actual;
            actual = target.PathSansExt;
            Assert.Equal(expected, actual);
        }
    }
}
