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
   public class DictController
    {

        
        private const int maxNumOfRecentlyTranslated = 10;
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

        //Adding word info to recently translated xml file
        public void addToRecentlyTranslated(string word, string langFrom, string langTo, DateTime dt)
        {

            //If file does not exist - creat it
            //if (File.Exists(".\\Resources\\recently_translated.xml") == false)
            if (File.Exists("recently_translated.xml") == false)
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                //using (XmlWriter xmlWriter = XmlWriter.Create(".\\Resources\\recently_translated.xml", xmlWriterSettings))
                using (XmlWriter xmlWriter = XmlWriter.Create("recently_translated.xml", xmlWriterSettings))

                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Words");

                    xmlWriter.WriteStartElement("Word");
                    xmlWriter.WriteElementString("Value", word);
                    xmlWriter.WriteElementString("Lang_From", langFrom);
                    xmlWriter.WriteElementString("Lang_To", langTo);
                    xmlWriter.WriteElementString("DateTime", dt.ToString());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            /*If it exists - Append data... if nodes are more than 'maxNumOfRecentlyTranslated'
            most recently entered will override least recently entered */
            else
            {
                //XDocument xDocument = XDocument.Load(".\\Resources\\recently_translated.xml");
                XDocument xDocument = XDocument.Load("recently_translated.xml");
                XElement root = xDocument.Element("Words");

                
                int count = root.Descendants("Word").Count();
                if (count >= maxNumOfRecentlyTranslated)
                {
                    root.Descendants("Word").LastOrDefault().Remove();
                }

                root.AddFirst(new XElement("Word",
                        new XElement("Value", word),
                        new XElement("Lang_From", langFrom),
                        new XElement("Lang_To", langTo),
                        new XElement("DateTime", dt.ToString())));
                
                //xDocument.Save(".\\Resources\\recently_translated.xml");
                xDocument.Save("recently_translated.xml");

            }
         }
        
    }
}
