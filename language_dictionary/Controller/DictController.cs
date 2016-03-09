using language_dictionary;
using language_dictionary.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace language_dictionary.Controller
{
    class DictController
    {
        private HashSet<Language> availLangs = new HashSet<Language>();
        private HashSet<Word> allWords = new HashSet<Word>();
        private XMLParserLINQ xmlParser;


        //Gets all available words
        public HashSet<Word> getAllWords()
        {
            return allWords;
        }
        //Gets all available Languages 
        public HashSet<Language> getAvailLangs()
        {
            return availLangs;
        }

        //Constructor
        public DictController(string fileUrl)
        {
            //Creating and initializing parser
            xmlParser = new XMLParserLINQ(fileUrl);
            //Parsing available languages from XML
            availLangs = xmlParser.parseLanguagesFromXML();
            //Parsing available words from XML
            allWords = xmlParser.parseWordsFromXML();
           
        }


        //Word translation method
        public string translateWord(string word, string langDescriptorFrom, string langDescriptorTo)
        {
            string translatedWord = "";
            foreach (Word wd in getAllWords())
            {
                if (wd.getWordByDescriptor(langDescriptorFrom).Equals(word, StringComparison.InvariantCultureIgnoreCase))
                {
                    translatedWord = wd.getWordByDescriptor(langDescriptorTo);
                    break;
                }

            }
            return translatedWord;
        }    
    }
}
