using System;

namespace name
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonDef person = new PersonDef();
            person.firstName = "Tarikul";
            person.middleName = "Islam";
            person.lastName = "Khan";
            string FullName = person.GetfullName();
            Console.WriteLine(FullName);
        }
    }
}
