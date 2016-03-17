using language_dictionary.Controller;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace language_dictionary
{
    /// <summary>
    /// Interaction logic for SettingsGrid.xaml
    /// </summary>
    public partial class SettingsUserControl : UserControl
    {

        //SettingsUserControl constructor
        public SettingsUserControl()
        {
            InitializeComponent();
        }

        //Load btn Click event
        private void btnLoadNewData_Click(object sender, RoutedEventArgs e)
        {

            loadNewFile();
        }


        //Loading new file method
        private void loadNewFile()
        {
            string filePath = "";

            // Create OpenFileDialog 
            OpenFileDialog dlg = new OpenFileDialog();



            //Set filter for file extension and default file extension 
            dlg.DefaultExt = "xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Getting document filepath 
                filePath = dlg.FileName;

            }
            else
                return;

            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.reinstantiateController(filePath);
        }
    }
}
