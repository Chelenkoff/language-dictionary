using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace language_dictionary
{
    class Word
    {
        //Map ex:(en:dog) (bg:куче) (de:der Hund)
        private Dictionary<String, String> wordInAllLangs = new Dictionary<string,string>();

        //Mapping 'descriptor' to 'word'  ex: (en:dog) (bg:куче) (de:der Hund)
        public void addDescriptorAsKeyAndWordAsValue(string descriptor, string word)
        {
            wordInAllLangs.Add(descriptor, word);
        }

        //Get WORD from WORD Dict by given lang DESCR
        public string getWordByDescriptor(string descr)
        {
            string availWord = "";
            wordInAllLangs.TryGetValue(descr, out availWord);
            return availWord;
        }
    }
}
