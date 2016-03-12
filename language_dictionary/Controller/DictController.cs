using language_dictionary;
using language_dictionary.Model;
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
        private Languages availLangs = new Languages();
        private HashSet<Word> allWords = new HashSet<Word>();
        private XMLParserLINQ xmlParser;


        //Gets all available words
        public HashSet<Word> getAllWords()
        {
            return allWords;
        }


        //Gets Languages object
        public Languages getLanguagesObject()
        {
            return availLangs;
        }

        //Constructor
        public DictController(string fileUrl)
        {
            //Creating and initializing parser
            xmlParser = new XMLParserLINQ(fileUrl);
            //Parsing available languages from XML
            availLangs = xmlParser.parseNewLanguagesFromXML();
            //Parsing available words from XML
            allWords = xmlParser.parseWordsFromXML();
           
        }


        //Word translation method
        public string translateNewWord(string word, string langNameFrom, string langNameTo)
        {
            string translatedWord = "";
            string langNameDescrFrom = availLangs.getLangDescriptorByName(langNameFrom);
            string langNameDescrTo = availLangs.getLangDescriptorByName(langNameTo);


            if (String.IsNullOrWhiteSpace(word))
                return "EMPTY_FIELD";

            foreach (Word wd in getAllWords())
            {
                if (wd.getWordByDescriptor(langNameDescrFrom).Equals(word, StringComparison.InvariantCultureIgnoreCase))
                    return wd.getWordByDescriptor(langNameDescrTo).ToUpperInvariant();
            }

            
             return "NOT_FOUND";

        }
    }
}
