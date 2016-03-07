using language_dictionary.Controller;
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
using System.Xml.Linq;

namespace language_dictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DictController dictController;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dictController = new DictController(".\\Resources\\data.xml");
            defaultPopulateToAndFromComboBoxes();
            
        }

        private void defaultPopulateToAndFromComboBoxes()
        {
            comboBoxFromLang.Items.Clear();
            comboBoxToLang.Items.Clear();
            foreach (Language lang in dictController.getAvailLangs())
            {
                comboBoxFromLang.Items.Add(lang.getName());
                comboBoxToLang.Items.Add(lang.getName());

            }
            comboBoxFromLang.SelectedIndex = 0;
            comboBoxToLang.SelectedIndex = 1;
        }


    }
}
