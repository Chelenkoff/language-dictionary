using language_dictionary.Controller;
using language_dictionary.Utilities;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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
            string translatedWord = dictController.translateNewWord(txtBoxWordToTranslate.Text, splitBtnLangFrom.SelectedItem.ToString(), splitBtnLangTo.SelectedItem.ToString());
            switch (translatedWord)
            {
                case "NOT_FOUND":
                    this.ShowMessageAsync(String.Format("The Word \"{0}\" was not found", txtBoxWordToTranslate.Text), "The specified word does not exist in the current data file or in the specified language");
                    break;
                case "EMPTY_FIELD":
                    this.ShowMessageAsync("No word inserted", "The word field is blank. Please insert a word");
                    txtBoxWordToTranslate.Text = "";
                    break;
                default:
                    lblTranslatedWord.Content = dictController.translateNewWord(txtBoxWordToTranslate.Text, splitBtnLangFrom.SelectedItem.ToString(), splitBtnLangTo.SelectedItem.ToString());
                    dictController.addToRecentlyTranslated(txtBoxWordToTranslate.Text, splitBtnLangFrom.SelectedItem.ToString(), splitBtnLangTo.SelectedItem.ToString(), DateTime.Now);
                    break;
            }
            

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


        //Exchange languages Button_click
        private void btnExchangeLangs_Click(object sender, RoutedEventArgs e)
        {
            object selectedToLang = splitBtnLangTo.SelectedItem;

            splitBtnLangTo.SelectedItem = splitBtnLangFrom.SelectedItem;
            splitBtnLangFrom.SelectedItem = selectedToLang;

            lblTranslatedWord.Content = "";
            
        }

        //System event - Metro generated
        private void MetroTabControl_TabItemClosingEvent(object sender, BaseMetroTabControl.TabItemClosingEventArgs e)
        {
            if (e.ClosingTabItem.Header.ToString().StartsWith("sizes"))
                e.Cancel = true;
        }


        //Changig tabs 
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //tabItemRecentlyTranslated checked test
            if (tabItemRecentlyTranslated.IsSelected)
            {
                //Getting execution folder location
                string executableLocation = System.IO.Path.GetDirectoryName(
                                            Assembly.GetExecutingAssembly().Location);
                string xmlLocation = System.IO.Path.Combine(executableLocation, "recently_translated.xml");

                //Checking file existence
                if (!File.Exists(xmlLocation))
                {
                    this.ShowMessageAsync("Words not available", "There are no translated words yet");
                    return;
                }

                //Populating dataGrid
                XElement wordList = XElement.Load(xmlLocation);
                dataGridPreviouslyTranslated.DataContext = wordList;       
                
            }
        }

    }
}
