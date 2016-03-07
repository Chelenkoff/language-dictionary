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

        //Available Languages 
        public HashSet<Language> getAvailLangs()
        {
            return availLangs;
        }

        //Constructor
        public DictController(string fileUrl)
        {
            //Parsing available languages from XML
            availLangs = XMLParserLINQ.parseLanguagesFromXML(fileUrl);
           
        }
        
    }
}
