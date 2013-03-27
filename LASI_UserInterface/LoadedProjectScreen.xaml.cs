﻿using LASI.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace LASI.UserInterface
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoadedProjectScreen : Window
    {
        public LoadedProjectScreen()
        {
            InitializeComponent();
            var titleText = WindowManager.CreateProjectScreen.LastLoadedProjectName;
            if (titleText != null)
                Title = titleText;
            BindEventHandlers();

        }



        public void LoadDocumentPreviews()
        {

            foreach (var textfile in FileManager.TextFiles)
            {
                using (StreamReader reader = new StreamReader(textfile.FullPath))
                {

                    var docu = reader.ReadToEnd();
                   docu = docu.Replace("\r\n\r\n", "");
                   docu = docu.Replace("<paragraph>", "\n");
                   docu = docu.Replace("</paragraph>", "");
                   
                    var item = new TabItem
                    {
                        Header = textfile.NameSansExt,
                        Content = new TextBox
                        {
                            IsReadOnly = true,
                            VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                            TextWrapping = TextWrapping.Wrap,
                            Text = docu


                        },
                        Focusable = true
                    };
                    DocumentPreview.Items.Add(item);
                }


            }
            DocumentPreview.SelectedIndex = 0;
            

        }



        private void BindEventHandlers()
        {

            this.Closing += (s, e) => Application.Current.Shutdown();

        }
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.InProgressScreen.PositionAt(this.Left, this.Top);
            WindowManager.InProgressScreen.SetTitle(WindowManager.CreateProjectScreen.LastLoadedProjectName + " - L.A.S.I.");
            WindowManager.InProgressScreen.Show();
            this.Hide();
            await FileManager.TagTextFilesAsync();
            
            
            
        }

        private void backButton_Click_1(object sender, RoutedEventArgs e)
        {
            WindowManager.CreateProjectScreen.PositionAt(this.Left, this.Top);
            WindowManager.CreateProjectScreen.Show();
            this.Hide();
        }

        private void forwardButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.forwardButton.IsManipulationEnabled = false;
            this.backButton.IsManipulationEnabled = true;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
