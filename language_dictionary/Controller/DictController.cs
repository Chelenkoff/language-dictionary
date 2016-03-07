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

        //Available Languages 
        public HashSet<Language> getAvailLangs()
        {
            return availLangs;
        }

        //Constructor
        public DictController(string fileUrl)
        {
            //Parsing available languages from XML
            availLangs = parseXML(fileUrl);
           
        }

        //LINQ XML Language parsing
        private HashSet<Language> parseXML(string fileUrl)
        {
            HashSet<Language> langs = new HashSet<Language>();

            XDocument doc = XDocument.Parse(File.ReadAllText(fileUrl));

            var data = from item in doc.Descendants("language")
                       select new
                       {
                           name = item.Element("name").Value.ToString(),
                           descriptor = item.Element("descriptor").Value.ToString(),
                       };

            foreach (var item in data)
            {
                Language lang = new Language(item.name,item.descriptor);
                langs.Add(lang);
            }
            return langs;
        }



    }
}
