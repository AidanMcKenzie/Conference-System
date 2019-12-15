using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    // AUTHOR: Aidan McKenzie
    // DATE LAST MODIFIED: 24/10/2016
    // CLASS DESCRIPTION: Person class is used as Attendee inherits from Person. Attendee takes FirstName and LastName from Person.
    class Person
    {
        // Declaring strings
        private string firstName;
        private string lastName;

        // Public setters and getters
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
