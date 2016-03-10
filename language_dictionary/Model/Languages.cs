using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace language_dictionary.Model
{
    class Languages
    {
        //Map language(value) to descriptor(key) ex:(en:English) (de:Deutsch) (bg:Български)
        private Dictionary<String, String> allLangs = new Dictionary<string, string>();
        
        public void addDescriptorAsKeyAnLangAsValue(string descriptor, string lang)
        {
            allLangs.Add(descriptor, lang);
        }

        //Get Lang Descriptor from Lang Name
        public string getLangDescriptorByName(string langName)
        {
            return allLangs.FirstOrDefault(x => x.Value == langName).Key;
        }

        public  Dictionary<String, String> getAllLangs()
        {
            return allLangs;
        }
    }
}
