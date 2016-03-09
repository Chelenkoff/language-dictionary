using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace language_dictionary
{
    class Language
    {
        private string name;
        private string descriptor;

        //Constructor
        public Language(string name, string descriptor)
        {
            this.name = name;
            this.descriptor = descriptor;
        }

        //name getter
        public string getName()
        {
            return name;
        }

        //descriptor getter
        public string getDescriptor()
        {
            return descriptor;
        }
        
    }
}
