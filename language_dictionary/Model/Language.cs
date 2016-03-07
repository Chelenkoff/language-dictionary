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
        Language(string name, string descriptor)
        {
            this.name = name;
            this.descriptor = descriptor;
        }

        //'Name' getter
        public string getName()
        {
            return name;
        }
        //'Descriptor' getter
        public string getDescriptor()
        {
            return descriptor;
        }
    }
}
