﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LASI.UserInterface.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogToProcedeToResults.xaml
    /// </summary>
    public partial class DialogToProcedeToResults : Window
    {
        public DialogToProcedeToResults() {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
            if (this.Owner == WindowManager.InProgressScreen) {
                WindowManager.ResultsScreen.AutoExport = true;
            }
        }
    }
}