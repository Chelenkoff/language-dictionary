using language_dictionary;
using language_dictionary.Model;
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

        //Creating 'Languages' Object containing languages dict from XML
        public Languages parseNewLanguagesFromXML()
        {
            Languages allLangs = new Languages();

            var data = from item in doc.Descendants("language")
                       select new
                       {
                           name = item.Element("name").Value.ToString(),
                           descriptor = item.Element("descriptor").Value.ToString(),
                       };

            foreach (var item in data)
            {
                allLangs.addDescriptorAsKeyAnLangAsValue(item.descriptor, item.name);
            }
            return allLangs;
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
