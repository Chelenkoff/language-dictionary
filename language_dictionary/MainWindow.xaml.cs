using language_dictionary.Controller;
using language_dictionary.Utilities;
using MahApps.Metro.Controls;
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
    public partial class MainWindow 
    {
        //Controller declaration
        DictController dictController ;
        public MainWindow()
        {
            InitializeComponent();
            
            //Controller init
            dictController = new DictController(".\\Resources\\data.xml");
            //Populating 'to' and 'from' comboboxes
            defaultPopulateToAndFromComboBoxes();
        }

        //BTN Parse Word
        private void btnTranslate_Click(object sender, RoutedEventArgs e)
        {

            lblTranslatedWord.Content = "";
            lblTranslatedWord.Content = dictController.translateNewWord(txtBoxWordToTranslate.Text, comboBoxFromLang.SelectedValue.ToString(), comboBoxToLang.SelectedValue.ToString());
        }

        //CombBoxes default population
        private void defaultPopulateToAndFromComboBoxes()
        {
            comboBoxFromLang.Items.Clear();
            comboBoxToLang.Items.Clear();

            foreach (KeyValuePair<string, string> entry in dictController.getLanguagesObject().getAllLangs())
            {
                comboBoxFromLang.Items.Add(entry.Value);
                comboBoxToLang.Items.Add(entry.Value);
            }

            comboBoxFromLang.SelectedIndex = 0;
            comboBoxToLang.SelectedIndex = 1;
        }

    }
}
