using language_dictionary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace language_dictionary.Utilities
{
    class XMLParserLINQ
    {
        //Creating document
        XDocument doc = new XDocument();

        //Parser constructor
        public XMLParserLINQ(String filePath)
        {
            doc = XDocument.Parse(File.ReadAllText(filePath));
        }
        //Creating LANGUAGE set from XML
        public  HashSet<Language> parseLanguagesFromXML()
        {
            HashSet<Language> langs = new HashSet<Language>();

            var data = from item in doc.Descendants("language")
                       select new
                       {
                           name = item.Element("name").Value.ToString(),
                           descriptor = item.Element("descriptor").Value.ToString(),
                       };

            foreach (var item in data)
            {
                Language lang = new Language(item.name, item.descriptor);
                langs.Add(lang);
            }
            return langs;
        }

        //Creating WORD set from XML
        public  HashSet<Word> parseWordsFromXML()
        {
            HashSet<Word> words = new HashSet<Word>();

            var data = from item in doc.Descendants("word")
                       select item;      

            foreach (var item in data)
            {
                Word word = new Word();
                foreach(var wordInLanguage in item.Elements())
                {
                    word.addDescriptorAsKeyAndWordAsValue(wordInLanguage.Name.ToString(), wordInLanguage.Value);
                }
                words.Add(word);
                
            }
            return words;
        }
    }
}
