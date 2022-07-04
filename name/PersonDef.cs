using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name
{
    class PersonDef
    {
        public string firstName;
        public string middleName;
        public string lastName;

        public string GetfullName()
        {
            string FullName = firstName+" "+middleName+" "+lastName;

            return FullName;
        }
    }
}
