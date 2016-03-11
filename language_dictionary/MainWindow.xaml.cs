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
            lblTranslatedWord.Content = dictController.translateNewWord(txtBoxWordToTranslate.Text, splitBtnLangFrom.SelectedItem.ToString(), splitBtnLangTo.SelectedItem.ToString());

        }

        //CombBoxes default population
        private void defaultPopulateToAndFromComboBoxes()
        {
            splitBtnLangFrom.Items.Clear();
            splitBtnLangTo.Items.Clear();

            splitBtnLangFrom.ItemsSource = dictController.getLanguagesObject().getAllLangsNames();
            splitBtnLangTo.ItemsSource = splitBtnLangFrom.ItemsSource;

            splitBtnLangFrom.SelectedIndex = 0;
            splitBtnLangTo.SelectedIndex = 1;
        }


        //SplitBtnLangFrom Click
        private void splitBtnLangFrom_Click(object sender, RoutedEventArgs e)
        {
            if(splitBtnLangFrom.IsExpanded)
                splitBtnLangFrom.IsExpanded = false;
            else
                splitBtnLangFrom.IsExpanded = true;
        }

        //SplitBtnLangTo Click
        private void splitBtnLangTo_Click(object sender, RoutedEventArgs e)
        {
            if (splitBtnLangTo.IsExpanded)
                splitBtnLangTo.IsExpanded = false;
            else
                splitBtnLangTo.IsExpanded = true;
        }

       


    }
}
