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

        //Creating Languages set from XML
        public static HashSet<Language> parseLanguagesFromXML(String url)
        {
            HashSet<Language> langs = new HashSet<Language>();

            XDocument doc = XDocument.Parse(File.ReadAllText(url));

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

        //Finding translated word
        public static string parseTranslatedWordFromWordAndUrl(string word, string langDescriptorFrom, string langDescriptorTo, string url)
        {
            string translatedWord = "";

            XDocument doc = XDocument.Parse(File.ReadAllText(url));




            var data = from item in doc.Descendants("word")
                       where item.Element(langDescriptorFrom).Value.ToString() == word
                       select new
                       {

                           newWord = item.Element(langDescriptorTo).Value.ToString(),
                       };
            foreach (var item in data)
            {
                translatedWord = item.newWord;
                break;
            }
            return translatedWord;
            
        }

    }
}
